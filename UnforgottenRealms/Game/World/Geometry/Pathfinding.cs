using SFML.Audio;
using SFML.Window;
using System;
using UnforgottenRealms.Game.World.Coordinates;

namespace UnforgottenRealms.Game.World.Geometry
{
    public static class Pathfinding
    {
        public static CubicCoordinates FindHex(this HexModel model, Vector2f pixelCoordinates)
        {
            pixelCoordinates.X -= model.HorizontalSize / 2;
            pixelCoordinates.Y -= model.VerticalSize / 2;

            var position = new Vector2f(
                (pixelCoordinates.X * (float)Math.Sqrt(3) / 3f - pixelCoordinates.Y / 3f) / model.EdgeLength,
                pixelCoordinates.Y * 2 / 3 / model.EdgeLength
            );

            var hexFloatingPoint = new Vector3f(position.X, -position.X - position.Y, position.Y);

            var roundedPosition = new CubicCoordinates(
                (int)Math.Round(hexFloatingPoint.X),
                (int)Math.Round(hexFloatingPoint.Y),
                (int)Math.Round(hexFloatingPoint.Z));

            var differences = new Vector3f(
                Math.Abs(hexFloatingPoint.X - roundedPosition.X),
                Math.Abs(hexFloatingPoint.Y - roundedPosition.Y),
                Math.Abs(hexFloatingPoint.Z - roundedPosition.Z)
            );

            if (differences.X > differences.Y && differences.X > differences.Z)
                roundedPosition.X = -roundedPosition.Y - roundedPosition.Z;
            else if (differences.Y > differences.Z)
                roundedPosition.Y = -roundedPosition.X - roundedPosition.Z;
            else
                roundedPosition.Z = -roundedPosition.X - roundedPosition.Y;

            return roundedPosition;
        }
    }
}
