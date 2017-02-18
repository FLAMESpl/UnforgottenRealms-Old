using SFML.Graphics;
using System.Collections.Generic;
using UnforgottenRealms.Game.Objects.Units;
using UnforgottenRealms.Game.World.Terrain;
using System.Linq;
using UnforgottenRealms.Game.Objects.Improvements;

namespace UnforgottenRealms.Game.World
{
    public class Field : Drawable
    {
        public Improvement Improvement { get; set; }
        public AbstractTerrain Terrain { get; set; }
        public IList<Unit> Units { get; set; }

        public Field(AbstractTerrain terrain, IList<Unit> units = null, Improvement improvement = null)
        {
            Improvement = improvement;
            Terrain = terrain;
            Units = units ?? new List<Unit>();
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
    }
}
