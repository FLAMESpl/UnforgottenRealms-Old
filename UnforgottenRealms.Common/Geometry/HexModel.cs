using SFML.Audio;
using SFML.Window;
using System;
using UnforgottenRealms.Common.Geometry.Coordinates;

namespace UnforgottenRealms.Common.Geometry
{
    public class HexModel
    {
        private static Vector2i[] neighbours = {
            new Vector2i(0, -1),
            new Vector2i(1, -1),
            new Vector2i(1, 0),
            new Vector2i(0, 1),
            new Vector2i(-1, 1),
            new Vector2i(-1, 0)
        };

        public Vector2f[] ApexesOffsets { get; private set; }
        public Vector2f Size => new Vector2f(HorizontalSize, VerticalSize);
        public float EdgeLength { get; private set; }
        public float HorizontalSize { get; private set; }
        public float VerticalSize { get; private set; }

        public Vector2i[] Neighbours => neighbours;

        public HexModel(float edgeLength)
        {
            EdgeLength = edgeLength;
            HorizontalSize = edgeLength * (float)Math.Sqrt(3);
            VerticalSize = edgeLength * 2;

            var centringOffset = (edgeLength * 2 - HorizontalSize) / 2;
            ApexesOffsets = new Vector2f[] {
                new Vector2f(0 , edgeLength / 2),
                new Vector2f(HorizontalSize / 2, 0),
                new Vector2f(HorizontalSize, edgeLength / 2),
                new Vector2f(HorizontalSize, edgeLength * 1.5f),
                new Vector2f(HorizontalSize / 2, VerticalSize),
                new Vector2f(0, edgeLength * 1.5f)
            };
        }

        public Vector2f GetCenter(Vector2f topLeftCorner) => new Vector2f(HorizontalSize / 2, VerticalSize / 2) + topLeftCorner;

        public Vector2f GetTopLeftCorner(AxialCoordinates position)
        {
            OffsetCoordinates offsetCoords = position;
            return new Vector2f(
                (offsetCoords.Row & 1) * HorizontalSize / 2 + HorizontalSize * offsetCoords.Column,
                offsetCoords.Row * (VerticalSize - EdgeLength / 2)
            );
        }

        public Vector2f GetShiftedTopLeftCenter(AxialCoordinates position, Vector2f objectSize)
        {
            var topLeftCorner = GetTopLeftCorner(position);
            var offset = new Vector2f(HorizontalSize / 2 - objectSize.X / 2, VerticalSize / 2 - objectSize.Y / 2);
            return topLeftCorner += offset;
        }

        public Vector2f[] GetApexesPositions(Vector2f topLeftCorner)
        {
            var result = new Vector2f[6];
            for (int i = 0; i < 6; i++)
            {
                result[i] = new Vector2f(topLeftCorner.X, topLeftCorner.Y) + ApexesOffsets[i];
            }
            return result;
        }

        public CubicCoordinates FindHex(Vector2f pixelCoordinates)
        {
            pixelCoordinates.X -= HorizontalSize / 2;
            pixelCoordinates.Y -= VerticalSize / 2;

            var position = new Vector2f(
                (pixelCoordinates.X * (float)Math.Sqrt(3) / 3f - pixelCoordinates.Y / 3f) / EdgeLength,
                pixelCoordinates.Y * 2 / 3 / EdgeLength
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
