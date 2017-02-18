using UnforgottenRealms.Common.Resources;
using UnforgottenRealms.Game.Graphics;
using UnforgottenRealms.Game.World.Geometry;

namespace UnforgottenRealms.Game.World.Terrains
{
    public class Water : Terrain
    {
        public static TerrainFactory Factory => (location, model, resources) => new Water(location, model, resources);

        public Water(Field location, HexModel model, ResourceManager resources) :
            base(
                model: model,
                movementCost: 1,
                location: location,
                textureDescriptor: resources.Get<GameTilesets>().Terrain.Water,
                type: TerrainType.Water
            )
        {
        }
    }
}
