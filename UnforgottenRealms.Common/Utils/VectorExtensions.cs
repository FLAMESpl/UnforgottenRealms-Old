using SFML.Graphics;
using SFML.Window;

namespace UnforgottenRealms.Common.Helper
{
    public static class VectorExtensions
    {
        public static Vector2f Position(this FloatRect rectangle) => new Vector2f(rectangle.Left, rectangle.Top);

        public static Vector2f Size(this FloatRect rectangle) => new Vector2f(rectangle.Width, rectangle.Height);

        public static Vector2f ScalarProduct(this Vector2f v1, Vector2f v2)
        {
            v1.X *= v2.X;
            v2.Y *= v2.Y;
            return v1;
        }
    }
}
