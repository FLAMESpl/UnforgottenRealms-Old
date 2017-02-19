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
using UnforgottenRealms.Gui.ContextPreview;

namespace UnforgottenRealms.Game.Objects.Units
{
    public delegate Unit UnitFactory(Field location, Player owner);

    public abstract class Unit : GameObject
    {
        private Vector2f unitSize;

        private Sprite unitSprite;
        private Sprite emblemSprite;

        public abstract int Movement { get; }
        public abstract float Strength { get; }
        public abstract float Health { get; }

        private int movementLeft;
        public int MovementLeft
        {
            get { return movementLeft; }
            set { movementLeft = value > 0 ? value : 0; }
        }

        public float HealthLeft { get; protected set; }

        public Unit(Field location, TextureDescriptor textureDescriptor, Player owner) : 
            base(
                  location: location,
                  owner: owner
            )
        {
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

        protected override void Destroyed()
        {
            Location.World.TurnCycle.RoundChanged -= Refresh;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(emblemSprite, states);
            target.Draw(unitSprite, states);
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

        public override void PerformPrimaryAction(Field target) => Move(target);

        public virtual int MovementCost(Field from, Field to)
        {
            if (to.Units.Any())
                return Pathfinding.Unreachable;

            switch (to.Terrain.Type)
            {
                default:
                case TerrainType.Impassable:
                case TerrainType.Water:
                    return Pathfinding.Unreachable;
                case TerrainType.Land:
                    return to.Terrain.MovementCost;
            }
        }

        protected virtual void Move(Field target)
        {
            if (MovementLeft == 0)
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

                    MovementLeft -= MovementCost(current, step);
                    current = step;
                }

                current.Move(this);
                Location = current;
                emblemSprite.Position = hexModel.GetTopLeftCorner(current.Position);
                unitSprite.Position = hexModel.GetShiftedTopLeftCenter(current.Position, unitSize);
            }
        }

        protected override void Refresh(object sender, RoundChangedEventArgs e)
        {
            MovementLeft = Movement;
        }

        public override IEnumerable<ContextInfoContent> GetContextViewContent()
        {
            yield return new ContextInfoContent(GetContextViewLines());
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
