using System.Collections.Generic;
using SFML.Graphics;
using UnforgottenRealms.Game.Gui.ContextPreview;
using UnforgottenRealms.Common.Graphics;

namespace UnforgottenRealms.Game.World.Terrains
{
    public delegate Terrain TerrainFactory(Field location);

    public abstract class Terrain : Drawable, IContextInfoSubject
    {
        protected VertexArray vertex;
        private Texture texture;

        public Field Location { get; }

        public abstract int MovementCost { get; }
        public abstract string Name { get; }
        public abstract TerrainType Type { get; }

        public Terrain(Field location, TerrainTextureDescriptor textureDescriptor)
        {
            Location = location;
            texture = textureDescriptor.Texture;
            InitializeVertex(textureDescriptor);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Texture = texture;
            target.Draw(vertex, states);
        }

        private void InitializeVertex(TerrainTextureDescriptor textureDescriptor)
        {
            var model = Location.World.Model;
            var topLeftCorner = model.GetTopLeftCorner(Location.Position);
            
            var apexes = model.GetApexesPositions(topLeftCorner);
            var hexCenter = model.GetCenter(topLeftCorner);

            vertex = new VertexArray(PrimitiveType.TrianglesFan);

            vertex.Append(new Vertex(hexCenter, textureDescriptor.Center));
            for (uint i = 0; i<  6; i++)
            {
                vertex.Append(new Vertex(apexes[i], textureDescriptor.Apexes[i]));
            }
            vertex.Append(new Vertex(apexes[0], textureDescriptor.Apexes[0]));
        }

        public IEnumerable<ContextInfoContent> GetContextInfoContent()
        {
            yield return new ContextInfoContent(GetContextInfoLines());
        }

        protected virtual IEnumerable<ContextInfoLine> GetContextInfoLines()
        {
            yield return new ContextInfoLine(Color.Black, Name);
        }
    }
}
