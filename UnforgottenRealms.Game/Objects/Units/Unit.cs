using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using UnforgottenRealms.Common.Utils;
using UnforgottenRealms.Game.Graphics;
using UnforgottenRealms.Game.Players;
using UnforgottenRealms.Game.World;
using UnforgottenRealms.Game.Events;
using UnforgottenRealms.Game.World.Geometry;
using UnforgottenRealms.Game.Gui.ContextPreview;
using UnforgottenRealms.Common.Graphics;

namespace UnforgottenRealms.Game.Objects.Units
{
    public delegate float StrengthModifier(Unit attacker, Unit foe);
    public delegate Unit UnitFactory(Field location, Player owner);

    public abstract class Unit : GameObject
    {
        private Vector2f unitSize;
        private Sprite unitSprite;
        private Sprite emblemSprite;
        
        public abstract int Combats { get; }
        public abstract float Health { get; }
        public abstract int Movement { get; }
        public abstract float Strength { get; }

        public int CombatsLeft { get; protected set; }

        private float healthLeft;
        public float HealthLeft
        {
            get { return healthLeft; }
            set { healthLeft = value > 0 ? value : 0; }
        }

        private int movementLeft;
        public int MovementLeft
        {
            get { return movementLeft; }
            set { movementLeft = value > 0 ? value : 0; }
        }

        public IList<StrengthModifier> StrengthModifiers { get; } = new List<StrengthModifier>();

        public Unit(Field location, Tile textureDescriptor, Player owner) : 
            base(
                  location: location,
                  owner: owner
            )
        {
            CombatsLeft = Combats;
            MovementLeft = Movement;
            HealthLeft = Health;

            var position = Location.Position;
            var hexModel = Location.World.Model;
            var resources = Location.World.Resources;
            var emblemTexture = resources.Get<GameTilesets>().Miscellaneous.Emblem;

            unitSize = hexModel.Size / 2;

            emblemSprite = new Sprite
            {
                Color = owner.Colour.ToRGB(),
                Position = hexModel.GetTopLeftCorner(position),
                Scale = emblemTexture.Scale(hexModel.Size),
                Texture = emblemTexture.Texture,
                TextureRect = emblemTexture.Bounds
            };

            unitSprite = new Sprite
            {
                Position = hexModel.GetShiftedTopLeftCenter(position, unitSize),
                Scale = textureDescriptor.Scale(unitSize),
                Texture = textureDescriptor.Texture,
                TextureRect = textureDescriptor.Bounds
            };

            Location.World.TurnCycle.RoundChanged += Refresh;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(emblemSprite, states);
            target.Draw(unitSprite, states);
        }

        public override IEnumerable<ContextInfoContent> GetContextInfoContent()
        {
            yield return new ContextInfoContent(GetContextViewLines());
        }

        public virtual float EffectiveStrengthAgainst(Unit against)
        {
            var effective = Strength * HealthLeft / Health;
            foreach (var strengthModifier in StrengthModifiers)
            {
                effective *= strengthModifier.Invoke(this, against);
            }
            return effective;
        }

        public override void PerformPrimaryAction(Field target)
        {
            if (target.Units.Any(u => u.Owner != Owner) && Location.IsNeighbour(target))
                Attack(target);
            else
                Move(target);
        }

        public virtual MovementAvailibility MovementAvailability(Field from, Field to)
        {
            var type = to.Units.Any() ? MovementType.Occupied : MovementType.Free;

            switch (to.Terrain.Type)
            {
                default:
                case TerrainType.Impassable:
                case TerrainType.Water:
                    return new MovementAvailibility(
                        cost: 0,
                        type: MovementType.Unreachable
                    );
                case TerrainType.Land:
                    return new MovementAvailibility(
                        cost: to.Terrain.MovementCost,
                        type: type
                    );
            }
        }

        public override void Select(bool isSelected)
        {
            byte newAlpha;

            if (isSelected)
                newAlpha = 155;
            else
                newAlpha = 255;

            emblemSprite.Color = emblemSprite.Color.SetAlpha(newAlpha);
            unitSprite.Color = unitSprite.Color.SetAlpha(newAlpha);

            base.Select(isSelected);
        }

        protected virtual void Attack(Field target)
        {
            if (MovementLeft == 0 || CombatsLeft == 0 || MovementAvailability(Location, target).Type == MovementType.Unreachable)
                return;

            SpendCombat();

            var foe = target.Units.StrongestOpponent(this);
            var strengthRatio = EffectiveStrengthAgainst(foe) / EffectiveStrengthAgainst(this);
            var damage = DamageAmount(strengthRatio);
            var counterDamage = CounterDamageAmount(strengthRatio, damage);

            int dealtDamage;
            int receivedDamage;

            if (strengthRatio >= 1)
            {
                receivedDamage = (int)counterDamage;
                dealtDamage = (int)damage;
            }
            else
            {
                receivedDamage = (int)damage;
                dealtDamage = (int)counterDamage;
            }

            var enemyDestroyed = foe.Damage(dealtDamage);
            Damage(receivedDamage, enemyDestroyed);

            if (enemyDestroyed)
                Move(target);
            else
                SpendMovement(MovementAvailability(Location, target).Cost);
        }

        public virtual float CounterDamageAmount(float strengthRatio, float damage) => damage / ((float)Math.Pow(strengthRatio, 2) * 2 - strengthRatio * 4 + 3);

        public virtual float DamageAmount(float strengthRatio) => (float)Math.Pow(strengthRatio, 2) * 10 - strengthRatio * 10 + 30;

        public virtual bool Damage(int amount, bool keepAlive = false)
        {
            HealthLeft -= amount;
            var died = HealthLeft == 0;

            if (died)
            {
                if (keepAlive)
                    HealthLeft = 1;
                else
                    this.Destroy();
            }
            return died;
        }

        public virtual void SpendCombat() => CombatsLeft--;

        public virtual void SpendMovement(int amount) => MovementLeft -= amount;

        protected virtual void Move(Field target)
        {
            if (MovementLeft == 0 || MovementAvailability(Location, target).Type != MovementType.Free)
                return;

            var hexModel = Location.World.Model;
            var pathfindingResult = this.FindPath(target);

            if (pathfindingResult.Success)
            {
                var current = Location;
                foreach (var step in pathfindingResult.Path)
                {
                    if (MovementLeft == 0)
                        break;

                    SpendMovement(MovementAvailability(current, step).Cost);
                    current = step;
                }

                current.Move(this);
                Location = current;
                emblemSprite.Position = hexModel.GetTopLeftCorner(current.Position);
                unitSprite.Position = hexModel.GetShiftedTopLeftCenter(current.Position, unitSize);
            }
        }

        protected override void Destroyed()
        {
            Location.World.TurnCycle.RoundChanged -= Refresh;
        }

        protected override void Refresh(object sender, RoundChangedEventArgs e)
        {
            CombatsLeft = Combats;
            MovementLeft = Movement;
        }

        protected virtual IEnumerable<ContextInfoLine> GetContextViewLines()
        {
            yield return new ContextInfoLine(Owner.Colour.ToRGB(), Name);
            yield return new ContextInfoLine(Color.Black, $"HP: {HealthLeft}/{Health}");
            yield return new ContextInfoLine(Color.Black, $"STR: {Strength}");
            yield return new ContextInfoLine(Color.Black, $"MOVE: {MovementLeft}/{Movement}");
        }
    }
}
