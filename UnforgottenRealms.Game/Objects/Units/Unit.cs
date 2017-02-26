using SFML.Graphics;
using SFML.Window;
using UnforgottenRealms.Common.Utils;
using UnforgottenRealms.Game.Graphics;
using UnforgottenRealms.Game.Players;
using UnforgottenRealms.Game.World;
using System.Linq;
using UnforgottenRealms.Game.Events;
using UnforgottenRealms.Game.World.Geometry;
using System;
using System.Collections.Generic;
using UnforgottenRealms.Game.Gui.ContextPreview;
using UnforgottenRealms.Common.Graphics;

namespace UnforgottenRealms.Game.Objects.Units
{
    public delegate Unit UnitFactory(Field location, Player owner);

    public abstract class Unit : GameObject
    {
        private Vector2f unitSize;

        private Sprite unitSprite;
        private Sprite emblemSprite;
        
        public abstract int Combats { get; }
        public abstract int Movement { get; }
        public abstract float Strength { get; }
        public abstract float Health { get; }

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

        public Unit(Field location, TextureDescriptor textureDescriptor, Player owner) : 
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

        public virtual float EffectiveStrengthAgainst(Unit against) => Strength * HealthLeft / Health;

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
        }

        protected virtual void Attack(Field target)
        {
            if (MovementLeft == 0 || CombatsLeft == 0 || MovementAvailability(Location, target).Type == MovementType.Unreachable)
                return;

            CombatsLeft--;

            var foe = target.Units.MaxBy(u => u.EffectiveStrengthAgainst(this));
            var strengthRatio = EffectiveStrengthAgainst(foe) / EffectiveStrengthAgainst(this);
            var damage = Damage(strengthRatio);
            var counterDamage = CounterDamage(strengthRatio, damage);

            if (strengthRatio >= 1)
            {
                HealthLeft -= counterDamage;
                foe.HealthLeft -= damage;
            }
            else
            {
                HealthLeft -= damage;
                foe.HealthLeft -= counterDamage;
            }

            if (foe.HealthLeft == 0)
            {
                foe.Destroy();
                Move(target);
                if (HealthLeft == 0)
                    HealthLeft = 1;
            }
            else if (HealthLeft == 0)
            {
                this.Destroy();
            }
            else
            {
                MovementLeft -= MovementAvailability(Location, target).Cost;
            }
        }

        protected virtual float CounterDamage(float strengthRatio, float damage) => damage / ((float)Math.Pow(strengthRatio, 2) * 2 - strengthRatio * 4 + 3);

        protected virtual float Damage(float strengthRatio) => (float)Math.Pow(strengthRatio, 2) * 10 - strengthRatio * 10 + 30;

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

                    MovementLeft -= MovementAvailability(current, step).Cost;
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
