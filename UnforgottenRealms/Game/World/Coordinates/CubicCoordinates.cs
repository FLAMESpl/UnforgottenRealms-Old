namespace UnforgottenRealms.Game.World.Coordinates
{
    public class CubicCoordinates
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public CubicCoordinates()
        {
        }

        public CubicCoordinates(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public bool IsEqualTo(CubicCoordinates other) => other.X == X && other.Y == Y && other.Z == Z;

        public static implicit operator AxialCoordinates(CubicCoordinates position)
        {
            return new AxialCoordinates(position.X, position.Z);
        } 

        public static implicit operator OffsetCoordinates(CubicCoordinates position)
        {
            return new OffsetCoordinates(position.X + (position.Z - (position.Z & 1)) / 2, position.Z);
        }
    }
}
