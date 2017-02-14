using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnforgottenRealms.Game.World.Coordinates;

namespace UnforgottenRealms.Game.World.Terrain
{
    public abstract class Field : Drawable
    {
        protected VertexArray vertex;

        public AxialCoordinates Position { get; set; }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(vertex, states);
        }
    }
}
