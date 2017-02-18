using SFML.Graphics;
using System.Collections.Generic;
using UnforgottenRealms.Game.Objects.Units;
using UnforgottenRealms.Game.World.Terrains;
using System.Linq;
using UnforgottenRealms.Game.Objects.Improvements;
using UnforgottenRealms.Game.World.Coordinates;
using UnforgottenRealms.Game.Players;

namespace UnforgottenRealms.Game.World
{
    public class Field : Drawable
    {
        private List<Unit> units = new List<Unit>();

        public Improvement Improvement { get; private set; }
        public Terrain Terrain { get; private set; }
        public IEnumerable<Unit> Units => units;

        public AxialCoordinates Position { get; private set; }
        public Map World { get; private set; }

        public Field(Map world, AxialCoordinates position)
        {
            Position = position;
            World = world;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(Terrain, states);

            if (Improvement != null)
                target.Draw(Improvement, states);

            var unit = Units.FirstOrDefault();
            if (unit != null)
                target.Draw(unit, states);
        }

        public void Create(TerrainFactory factory)
        {
            Terrain = factory.Invoke(
                location: this,
                model: World.Model,
                resources: World.Resources
            );
        }

        public void Create(UnitFactory factory, Player owner)
        {
            units.Add(factory.Invoke(
                location: this,
                model: World.Model,
                owner: owner,
                resources: World.Resources
            ));
        }

        public void Create(ImprovementFactory factory, Player owner)
        {
            Improvement = factory.Invoke(
                location: this,
                model: World.Model,
                owner: owner,
                resources: World.Resources
            );
        }

        public void Move(Unit unit)
        {
            unit.Location.units.Remove(unit);
            units.Add(unit);
        }

        public void Move(Improvement improvement)
        {
            improvement.Location.Improvement = improvement;
        }
    }
}
