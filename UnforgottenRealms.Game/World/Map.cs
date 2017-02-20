using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using UnforgottenRealms.Common.Resources;
using UnforgottenRealms.Game.Events;
using UnforgottenRealms.Game.Objects.Improvements;
using UnforgottenRealms.Game.Objects.Units;
using UnforgottenRealms.Game.Players;
using UnforgottenRealms.Game.World.Coordinates;
using UnforgottenRealms.Game.World.Deposits;
using UnforgottenRealms.Game.World.Geometry;
using UnforgottenRealms.Game.World.Terrains;

namespace UnforgottenRealms.Game.World
{
    public class Map : Drawable
    {
        public event EventHandler<ObjectCreatedEventArgs> ObjectCreated;
        public event EventHandler<ObjectDestroyedEventArgs> ObjectDestroyed;

        private Field[][] fields;
        private List<List<VertexArray>> grid;

        public HexModel Model { get; protected set; }
        public Vector2f PixelSize => new Vector2f(Size.X * Model.HorizontalSize, Size.Y * Model.VerticalSize);
        public ResourceManager Resources { get; }
        public bool ShowGrid { get; set; }
        public Vector2i Size { get; protected set; }
        public TurnCycle TurnCycle { get; }

        public Map(ResourceManager resources, TurnCycle turnCycle)
        {
            Model = new HexModel(60);
            Resources = resources;
            TurnCycle = turnCycle;
        }

        public void OnObjectCreated(ObjectCreatedEventArgs args) => ObjectCreated?.Invoke(this, args);
        public void OnObjectDestroyed(ObjectDestroyedEventArgs args) => ObjectDestroyed?.Invoke(this, args);

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
                    target.Draw(fields[i][j], states);
                }
            }

            for (int i = 0; i < Size.X; i++)
            {
                for (int j = 0; j < Size.Y; j++)
                {
                    target.Draw(grid[i][j], states);
                }
            }
        }

        private void Place(OffsetCoordinates position, TerrainFactory terrainFactory)
        {
            var field = new Field(
                world: this,
                position: position
            );

            field.Create(terrainFactory);

            this[position] = field;
        }

        public bool Contains(OffsetCoordinates position)
        {
            return position.Column < Size.X && position.Row < Size.Y && position.Column >= 0 && position.Row >= 0;
        }

        public AxialCoordinates Find(Vector2f pixelCoordinates)
        {
            var position = Model.FindHex(pixelCoordinates);
            if (Contains(position))
                return position;
            else
                return null;
        }

        public void Mock(IEnumerable<Player> players)
        {
            Size = new Vector2i(10, 10);
            fields = new Field[Size.X][];
            grid = new List<List<VertexArray>>();

            for (int i = 0; i < Size.X; i++)
            {
                fields[i] = new Field[Size.Y];
                grid.Add(new List<VertexArray>()); 
                for (int j = 0; j < Size.Y; j++)
                {
                    var position = new OffsetCoordinates(i, j);
                    if (i == 8 && j >= 7 && j <= 9)
                        Place(position, Hill.Factory);
                    else if (i == 5 && j == 2)
                        Place(position, Grass.Factory);
                    else if (i >= 3 && i <= 7 && j >= 1 && j <= 3)
                        Place(position, Water.Factory);
                    else if (i >= 4 && i <= 6 && j >= 4 && j <= 5)
                        Place(position, Desert.Factory);
                    else
                        Place(position, Grass.Factory);

                    var apexes = Model.GetApexesPositions(new Vector2f(
                        position.Column * Model.HorizontalSize + (Model.HorizontalSize * 0.5f * (position.Row & 1)),
                        position.Row * (Model.VerticalSize - Model.EdgeLength / 2)
                    ));

                    var vertex = new VertexArray(PrimitiveType.LinesStrip);
                    var color = Color.Red;
                    for (uint k = 0; k < apexes.Length; k++)
                        vertex.Append(new Vertex(apexes[k], color));
                    vertex.Append(new Vertex(apexes[0], color));
                    grid[i].Add(vertex);
                }
            }

            var unitPosition1 = new OffsetCoordinates(7, 7);
            var unitPosition2 = new OffsetCoordinates(5, 7);
            var improvementPosition = new OffsetCoordinates(6, 6);
            var depositPosition = new OffsetCoordinates(8, 8);

            var player1 = players.First();
            var player2 = players.Skip(1).First();

            this[unitPosition1].Create(Archer.Factory, player1);
            this[unitPosition2].Create(Archer.Factory, player2);
            this[improvementPosition].Create(Farm.Factory, player1);
            this[depositPosition].Create(Iron.Factory);
        }
    }
}
