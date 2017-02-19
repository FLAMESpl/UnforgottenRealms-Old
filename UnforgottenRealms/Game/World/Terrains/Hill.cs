using UnforgottenRealms.Game.Graphics;

namespace UnforgottenRealms.Game.World.Terrains
{
    public class Hill : Terrain
    {
        public static TerrainFactory Factory => location => new Hill(location);

        public override int MovementCost => 2;
        public override string Name => "HILL";
        public override TerrainType Type => TerrainType.Land;

        public Hill(Field location) : 
            base(
                location: location, 
                textureDescriptor: location.World.Resources.Get<GameTilesets>().Terrain.Hill
            )
        {
        }
    }
}
