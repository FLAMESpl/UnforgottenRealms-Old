using UnforgottenRealms.Game.Graphics;

namespace UnforgottenRealms.Game.World.Terrains
{
    public class Grass : Terrain
    {
        public static TerrainFactory Factory => (location) => new Grass(location);

        public override int MovementCost => 1;
        public override TerrainType Type => TerrainType.Land;

        public Grass(Field location) :
            base(
                location: location,
                textureDescriptor: location.World.Resources.Get<GameTilesets>().Terrain.Grass
            )
        { 
        }
    }
}
