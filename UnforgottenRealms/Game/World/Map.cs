﻿using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnforgottenRealms.Common.Resources;
using UnforgottenRealms.Game.World.Coordinates;
using UnforgottenRealms.Game.World.Geometry;
using UnforgottenRealms.Game.World.Terrain;

namespace UnforgottenRealms.Game.World
{
    public class Map : Drawable
    {
        private List<List<Field>> fields;
        private List<List<VertexArray>> grid;
        private ResourceManager resources;
        private HexModel model;

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

        public Map(ResourceManager resources)
        {
            this.resources = resources;
            this.model = new HexModel(60);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            for (int i = 0; i < Size.X; i++)
            {
                for (int j = 0; j < Size.Y; j++)
                {
                    fields[i][j].Draw(target, states);
                    grid[i][j].Draw(target, states);
                }
            }
        }

        public void MockMap()
        {
            Size = new Vector2i(10, 10);
            fields = new List<List<Field>>();
            grid = new List<List<VertexArray>>();
            for (int i = 0; i < Size.X; i++)
            {
                fields.Add(new List<Field>());
                grid.Add(new List<VertexArray>()); 
                for (int j = 0; j < Size.Y; j++)
                {
                    Field field = null;
                    var position = new OffsetCoordinates(i, j);
                    if (i >= 3 && i <= 7 && j >= 2 && j <= 3)
                        field = new Water(position, model, resources);
                    else if (i >= 4 && i <= 6 && j >= 4 && j <= 5)
                        field = new Desert(position, model, resources);
                    else
                        field = new Grass(position, model, resources);
                    fields[i].Add(field);

                    var apexes = model.GetApexesPositions(new Vector2f(
                        position.Column * model.HorizontalSize + (model.HorizontalSize * 0.5f * (position.Row & 1)),
                        position.Row * (model.VerticalSize - model.EdgeLength / 2)
                    ));
                    var vertex = new VertexArray(PrimitiveType.LinesStrip);
                    var color = Color.Red;
                    for (uint k = 0; k < apexes.Length; k++)
                        vertex.Append(new Vertex(apexes[k], color));
                    vertex.Append(new Vertex(apexes[0], color));
                    grid[i].Add(vertex);
                }
            }
        }
    }
}
