using SFML.Graphics;
using System.Collections.Generic;
using UnforgottenRealms.Common.Geometry.Coordinates;

namespace UnforgottenRealms.Editor.Level
{
    public class Field : Drawable
    {
        public Deposit Deposit { get; private set; }
        public Improvement Improvement { get; private set; }
        public Terrain Terrain { get; private set; }
        public Unit Unit { get; private set; }

        public AxialCoordinates Position { get; }
        public Map World { get; }

        public Field(AxialCoordinates position, Map world)
        {
            Position = position;
            World = world;
        }

        public void Create(DepositFactory factory)
        {
            Deposit = factory.Invoke(this);
        }

        public void Create(ImprovementFactory factory, int ownerId)
        {
            Improvement = factory.Invoke(this, ownerId);
        }

        public void Create(TerrainMetadata metadata) => Terrain = new Terrain(this, metadata);

        public void Create(UnitFactory factory, int ownerId)
        {
            Unit = factory.Invoke(this, ownerId);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            if (Terrain != null)
                target.Draw(Terrain, states);
            if (Deposit != null)
                target.Draw(Deposit, states);
            if (Improvement != null)
                target.Draw(Improvement, states);
            if (Unit != null)
                target.Draw(Unit, states);
        }
    }
}
