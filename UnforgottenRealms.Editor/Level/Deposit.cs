using SFML.Graphics;
using UnforgottenRealms.Common.Definitions.Entity;

namespace UnforgottenRealms.Editor.Level
{
    public delegate Deposit DepositFactory(Field location);

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
