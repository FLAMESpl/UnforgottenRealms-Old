using SFML.Graphics;
using UnforgottenRealms.Common.Geometry.Coordinates;
using UnforgottenRealms.Editor.Level.Entities;
using UnforgottenRealms.Editor.Level.Entities.Metadata;

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

            Deposit = new Deposit(this, DepositMetadata.Empty);
            Improvement = new Improvement(this, ImprovementMetadata.Empty);
            Terrain = new Terrain(this, TerrainMetadata.Empty);
            Unit = new Unit(this, UnitMetadata.Empty);
        }

        public void Create(DepositMetadata metadata)
        {
            Deposit = new Deposit(this, metadata);
        }

        public void Create(ImprovementMetadata metadata)
        {
            Improvement = new Improvement(this, metadata);
        }

        public void Create(TerrainMetadata metadata)
        {
            Terrain = new Terrain(this, metadata);
        }

        public void Create(UnitMetadata metadata)
        {
            Unit = new Unit(this, metadata);
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
