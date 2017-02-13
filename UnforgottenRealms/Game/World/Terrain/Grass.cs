using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnforgottenRealms.Game.World.Coordinates;

namespace UnforgottenRealms.Game.World.Terrain
{
    public class Grass : Field
    {
        public Grass(OffsetCoordinates position)
        {
            Position = position;
            rect.Position = new SFML.Window.Vector2f(position.Column * 30, position.Row * 30);
        }
    }
}
