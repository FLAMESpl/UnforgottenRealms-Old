using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnforgottenRealms.Game.World.Coordinates;
using UnforgottenRealms.Game.World.Geometry;
using UnforgottenRealms.Game.World.Terrain;

namespace UnforgottenRealms.Game.World
{
    public class Map : Drawable
    {
        private List<List<Field>> fields;

        public bool ShowGrid { get; set; }
        public Vector2i Size { get; protected set; }

        public Field this[int column, int row]
        {
            get { return fields[column][row]; }
            set { fields[column][row] = value; }
        }

        public Field this[OffsetCoordinates position]
        {
            get { return fields[position.Column][position.Row]; }
            set { fields[position.Column][position.Row] = value; }
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            for (int i = 0; i < Size.X; i++)
            {
                for (int j = 0; j < Size.Y; j++)
                {
                    fields[i][j].Draw(target, states);
                }
            }
        }

        public void MockMap()
        {
            var model = new HexModel(60);
            Size = new Vector2i(10, 10);
            fields = new List<List<Field>>();
            for (int i = 0; i < Size.X; i++)
            {
                fields.Add(new List<Field>());
                for (int j = 0; j < Size.Y; j++)
                {
                    fields[i].Add(new Grass(new OffsetCoordinates(i, j), model));
                }
            }
        }
    }
}
