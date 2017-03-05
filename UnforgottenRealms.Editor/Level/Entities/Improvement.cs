using SFML.Graphics;
using SFML.Window;
using UnforgottenRealms.Common.Definitions.Entity;
using UnforgottenRealms.Common.Geometry;
using UnforgottenRealms.Common.Utils;
using UnforgottenRealms.Editor.Graphics;
using UnforgottenRealms.Editor.Level.Entities.Metadata;

namespace UnforgottenRealms.Editor.Level.Entities
{
    public class Improvement : IImprovement, Drawable
    {
        private Sprite improvementSprite;
        private Sprite flagSprite;

        public EntityId Id { get; }
        public ImprovementMetadata Metadata { get; }

        public Improvement(Field location, ImprovementMetadata metadata)
        {
            Metadata = metadata;
            Id = metadata.EntityId;

            if (metadata.IsEmpty)
                return;

            var model = location.World.Model;
            var flagTexture = location.World.Resources.Get<EditorTilesets>().Miscellaneous.Flag;
            var improvementTexture = metadata.Tile;

            improvementSprite = new Sprite
            {
                Position = model.GetTopLeftCorner(location.Position),
                Scale = improvementTexture.Scale(model.Size),
                Texture = improvementTexture.Texture,
                TextureRect = improvementTexture.Bounds
            };

            flagSprite = new Sprite
            {
                Color = metadata.Owner.Value.ToRGB(),
                Position = model.GetTopLeftCorner(location.Position) + FlagOffset(model),
                Scale = flagTexture.Scale(model.Size),
                Texture = flagTexture.Texture,
                TextureRect = flagTexture.Bounds
            };
        }

        private Vector2f FlagOffset(HexModel model) => new Vector2f(0, -model.VerticalSize / 2);

        public void Draw(RenderTarget target, RenderStates states)
        {
            if (!Metadata.IsEmpty)
            {
                target.Draw(flagSprite, states);
                target.Draw(improvementSprite, states);
            }
        }
    }
}
