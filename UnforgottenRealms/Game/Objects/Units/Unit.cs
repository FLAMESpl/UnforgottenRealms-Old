using System;
using SFML.Graphics;
using SFML.Window;
using UnforgottenRealms.Common.Resources;
using UnforgottenRealms.Common.Utils;
using UnforgottenRealms.Game.Graphics;
using UnforgottenRealms.Game.Players;
using UnforgottenRealms.Game.World;
using UnforgottenRealms.Game.World.Coordinates;
using UnforgottenRealms.Game.World.Geometry;
using System.Linq;

namespace UnforgottenRealms.Game.Objects.Units
{
    public abstract class Unit : GameObject
    {
        private Vector2f unitSize;

        private Sprite unitSprite;
        private Sprite emblemSprite;

        public int Movement { get; private set; }
        public int MovementLeft { get; private set; }

        public Unit(AxialCoordinates position, HexModel hexModel, TextureDescriptor textureDescriptor, ResourceManager resources, Player owner, int movement) : 
            base(
                  position: position,
                  hexModel: hexModel,
                  owner: owner
            )
        {
            unitSize = hexModel.Size / 2;

            Movement = movement;
            MovementLeft = movement;

            var emblemTexure = resources.Get<GameTilesets>().Miscellaneous.Emblem;
            emblemSprite = new Sprite
            {
                Color = owner.Colour.ToRGB(),
                Position = hexModel.GetTopLeftCorner(position),
                Scale = Scale(emblemTexure.TileSize, hexModel.Size),
                Texture = emblemTexure.Texture,
                TextureRect = emblemTexure.Bounds
            };

            unitSprite = new Sprite
            {
                Position = hexModel.GetShiftedTopLeftCenter(position, unitSize),
                Scale = Scale(textureDescriptor.TileSize, unitSize),
                Texture = textureDescriptor.Texture,
                TextureRect = textureDescriptor.Bounds
            };
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

        public override void PerformPrimaryAction(Map map, AxialCoordinates targetPosition) => Move(map, targetPosition);

        protected virtual void Move(Map map, AxialCoordinates targetPosition)
        {
            var targetedUnit = map[targetPosition].Units.FirstOrDefault();
            if (targetedUnit == null)
            {
                map[Position].Units.Remove(this);
                map[targetPosition].Units.Add(this);
                emblemSprite.Position = HexModel.GetTopLeftCorner(targetPosition);
                unitSprite.Position = HexModel.GetShiftedTopLeftCenter(targetPosition, unitSize);
                Position = targetPosition;
            }
        }

        protected Vector2f Scale(Vector2i original, Vector2f template)
        {
            return new Vector2f(template.X / original.X, template.Y / original.Y);
        }

    }
}
