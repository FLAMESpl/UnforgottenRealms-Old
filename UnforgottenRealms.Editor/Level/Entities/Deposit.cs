using SFML.Graphics;
using UnforgottenRealms.Common.Definitions.Entity;
using UnforgottenRealms.Editor.Level.Entities.Metadata;

namespace UnforgottenRealms.Editor.Level.Entities
{
    public class Deposit : IDeposit, Drawable
    {
        private Sprite sprite = null;

        public EntityId Id { get; }
        public DepositMetadata Metadata { get; }

        public Deposit(Field location, DepositMetadata metadata)
        {
            Metadata = metadata;

            if (!metadata.IsEmpty)
            {
                var model = location.World.Model;
                sprite = new Sprite
                {
                    Position = model.GetTopLeftCorner(location.Position),
                    Texture = metadata.Tile.Texture,
                    TextureRect = metadata.Tile.Bounds,
                    Scale = metadata.Tile.Scale(model.Size)
                };
            }
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            if (sprite != null)
                target.Draw(sprite, states);
        }
    }
}
