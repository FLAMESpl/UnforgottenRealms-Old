using SFML.Graphics;
using System.Collections.Generic;
using System.Linq;
using UnforgottenRealms.Game.Objects.Units;
using UnforgottenRealms.Game.World.Terrains;
using UnforgottenRealms.Game.Objects.Improvements;
using UnforgottenRealms.Game.World.Coordinates;
using UnforgottenRealms.Game.Players;
using UnforgottenRealms.Game.Events;
using System;

namespace UnforgottenRealms.Game.World
{
    public class Field : Drawable
    {
        public RectangleShape sh = null;

        private Lazy<List<Field>> neighbours;
        private List<Unit> units = new List<Unit>();

        public Improvement Improvement { get; private set; }
        public Terrain Terrain { get; private set; }
        public IEnumerable<Unit> Units => units;

        public IEnumerable<Field> Neighbours => neighbours.Value;
        public AxialCoordinates Position { get; private set; }
        public Map World { get; private set; }

        public Field(Map world, AxialCoordinates position)
        {
            Position = position;
            World = world;
            
            neighbours = new Lazy<List<Field>>(() =>
            {
                var neighbours = new List<Field>();
                var neighboursOffsets = World.Model.Neighbours;
                for (int i = 0; i < 6; i++)
                {
                    var neighbourPosition = position + neighboursOffsets[i];
                    if (world.Contains(neighbourPosition))
                        neighbours.Add(world[position + neighboursOffsets[i]]);
                }
                return neighbours;
            });
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(Terrain, states);

            if (Improvement != null)
                target.Draw(Improvement, states);

            var unit = Units.FirstOrDefault();
            if (unit != null)
                target.Draw(unit, states);

            if (sh != null)
                target.Draw(sh, states);
        }

        public void Create(TerrainFactory factory)
        {
            Terrain = factory.Invoke(
                location: this
            );
        }

        public void Create(UnitFactory factory, Player owner)
        {
            var unit = factory.Invoke(
                location: this,
                owner: owner
            );

            units.Add(unit);

            World.OnObjectCreated(new ObjectCreatedEventArgs(
                location: this,
                @object: unit
            ));
        }

        public void Create(ImprovementFactory factory, Player owner)
        {
            Improvement = factory.Invoke(
                location: this,
                owner: owner
            );

            World.OnObjectCreated(new ObjectCreatedEventArgs(
                location: this,
                @object: Improvement
            ));
        }

        public void Destroy(Unit unit)
        {
            units.Remove(unit);
            World.OnObjectDestroyed(new ObjectDestroyedEventArgs(
                location: this,
                @object: unit
            ));
        }

        public void Destroy()
        {
            Improvement = null;
            World.OnObjectDestroyed(new ObjectDestroyedEventArgs(
                location: this,
                @object: Improvement
            ));
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
