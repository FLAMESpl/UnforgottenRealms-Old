using UnforgottenRealms.Game.Graphics;

namespace UnforgottenRealms.Game.World.Terrains
{
    public class Desert : Terrain
    {
        public static TerrainFactory Factory => (location) => new Desert(location);

        public override int MovementCost => 2;
        public override string Name => "DESERT";
        public override TerrainType Type => TerrainType.Land;

        public Desert(Field location) : 
            base(
                location: location,
                textureDescriptor: location.World.Resources.Get<GameTilesets>().Terrain.Desert
            )
        {
        }
    }
}
