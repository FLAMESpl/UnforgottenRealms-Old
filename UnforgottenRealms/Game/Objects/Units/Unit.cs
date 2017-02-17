using SFML.Graphics;
using SFML.Window;
using UnforgottenRealms.Common.Resources;
using UnforgottenRealms.Common.Utils;
using UnforgottenRealms.Game.Graphics;
using UnforgottenRealms.Game.Players;
using UnforgottenRealms.Game.World.Coordinates;
using UnforgottenRealms.Game.World.Geometry;

namespace UnforgottenRealms.Game.Objects.Units
{
    public abstract class Unit : GameObject
    {
        private Sprite unitSprite;
        private Sprite emblemSprite;

        public int Movement { get; private set; }
        public int MovementLeft { get; private set; }

        public Unit(AxialCoordinates position, HexModel model, TextureDescriptor textureDescriptor, ResourceManager resources, Player owner, int movement) : 
            base(
                  position: position,
                  owner: owner
            )
        {
            Movement = movement;
            MovementLeft = movement;

            var emblemTexure = resources.Get<GameTilesets>().Miscellaneous.Emblem;
            emblemSprite = new Sprite
            {
                Color = owner.Colour.ToRGB(),
                Position = model.GetTopLeftCorner(position),
                Scale = Scale(emblemTexure.TileSize, model.Size),
                Texture = emblemTexure.Texture,
                TextureRect = emblemTexure.Bounds
            };

            var unitsSize = model.Size / 2;
            unitSprite = new Sprite
            {
                Position = model.GetShiftedTopLeftCenter(position, unitsSize),
                Scale = Scale(textureDescriptor.TileSize, unitsSize),
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

            emblemSprite.Color.SetAlpha(newAlpha);
        }

        protected Vector2f Scale(Vector2i original, Vector2f template)
        {
            return new Vector2f(template.X / original.X, template.Y / original.Y);
        }

    }
}
