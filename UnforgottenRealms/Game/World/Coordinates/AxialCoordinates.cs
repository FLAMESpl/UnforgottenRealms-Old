namespace UnforgottenRealms.Game.World.Coordinates
{
    public class AxialCoordinates
    {
        public int Q { get; set; }
        public int R { get; set; }

        public AxialCoordinates()
        {
        }

        public AxialCoordinates(int q, int r)
        {
            Q = q;
            R = r;
        }

        public bool IsEqualTo(AxialCoordinates other) => other.Q == Q && other.R == R;

        public static implicit operator CubicCoordinates(AxialCoordinates position)
        {
            return new CubicCoordinates(position.Q, -position.Q - position.R, position.R);
        }

        public static implicit operator OffsetCoordinates(AxialCoordinates position)
        {
            return new OffsetCoordinates(position.Q + (position.R - (position.R & 1)) / 2, position.R);
        }
    }
}
