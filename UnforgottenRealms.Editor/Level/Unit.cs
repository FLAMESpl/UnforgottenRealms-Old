using SFML.Graphics;
using UnforgottenRealms.Common.Definitions.Entity;
using UnforgottenRealms.Common.Utils;
using UnforgottenRealms.Editor.Graphics;

namespace UnforgottenRealms.Editor.Level
{
    public class Unit : IUnit, Drawable
    {
        private Sprite unitSprite;
        private Sprite emblemSprite;

        public EntityId Id { get; }
        public UnitMetadata Metadata { get; }

        public Unit(Field location, UnitMetadata metadata)
        {
            Metadata = metadata;
            Id = metadata.EntityId;

            if (metadata.IsEmpty)
                return;

            var model = location.World.Model;
            var position = location.Position;
            var hexModel = location.World.Model;
            var resources = location.World.Resources;
            var emblemTexture = resources.Get<EditorTilesets>().Miscellaneous.Emblem;

            var unitSize = hexModel.Size / 2;

            emblemSprite = new Sprite
            {
                Color = metadata.Owner.Value.ToRGB(),
                Position = hexModel.GetTopLeftCorner(position),
                Scale = emblemTexture.Scale(hexModel.Size),
                Texture = emblemTexture.Texture,
                TextureRect = emblemTexture.Bounds
            };

            unitSprite = new Sprite
            {
                Position = hexModel.GetShiftedTopLeftCenter(position, unitSize),
                Scale = metadata.Tile.Scale(unitSize),
                Texture = metadata.Tile.Texture,
                TextureRect = metadata.Tile.Bounds
            };
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            if (!Metadata.IsEmpty)
            {
                target.Draw(emblemSprite, states);
                target.Draw(unitSprite, states);
            }
        }
    }
}
