using SFML.Window;
using UnforgottenRealms.Game.Graphics;

namespace UnforgottenRealms.Game.Objects
{
    public static class GameObjectExtensions
    {
        public static Vector2f Scale(this ITextureDescriptor texture, Vector2f template)
        {
            return new Vector2f(template.X / texture.TileSize.X, template.Y / texture.TileSize.Y);
        }
    }
}
