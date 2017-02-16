using SFML.Window;

namespace UnforgottenRealms.Game.World.Coordinates
{
    public class OffsetCoordinates
    {
        public int Column { get; set; }
        public int Row { get; set; }

        public OffsetCoordinates()
        {
        }

        public OffsetCoordinates(int column, int row)
        {
            Column = column;
            Row = row;
        }

        public static implicit operator AxialCoordinates(OffsetCoordinates position)
        {
            return new AxialCoordinates(position.Column - (position.Row - (position.Row & 1)) / 2, position.Row);
        }

        public static implicit operator Vector2f(OffsetCoordinates position)
        {
            return new Vector2f(position.Column, position.Row);
        }
    }
}
