using SFML.Window;

namespace UnforgottenRealms.Common.Enums
{
    public enum Direction
    {
        Up,
        Right,
        Down,
        Left
    }

    public static class DirectionExtensions
    {
        public static Vector2f AsVector(this Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return new Vector2f(0, -1);
                case Direction.Right:
                    return new Vector2f(1, 0);
                case Direction.Down:
                    return new Vector2f(0, 1);
                case Direction.Left:
                    return new Vector2f(-1, 0);
                default:
                    return new Vector2f(0, 0);
            }
        }
    }
}
