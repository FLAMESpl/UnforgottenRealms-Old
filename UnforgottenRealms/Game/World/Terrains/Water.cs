using UnforgottenRealms.Game.Graphics;

namespace UnforgottenRealms.Game.World.Terrains
{
    public class Water : Terrain
    {
        public static TerrainFactory Factory => (location) => new Water(location);

        public override int MovementCost => 1;
        public override TerrainType Type => TerrainType.Water;

        public Water(Field location) :
            base(
                location: location,
                textureDescriptor: location.World.Resources.Get<GameTilesets>().Terrain.Water
            )
        {
        }
    }
}
