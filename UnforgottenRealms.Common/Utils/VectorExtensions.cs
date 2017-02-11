using SFML.Graphics;
using SFML.Window;

namespace UnforgottenRealms.Common.Helper
{
    public static class VectorExtensions
    {
        public static Vector2f Position(this FloatRect rectangle)
            => new Vector2f(rectangle.Left, rectangle.Top);

        public static Vector2f Size(this FloatRect rectangle)
            => new Vector2f(rectangle.Width, rectangle.Height);
    }
}
