using UnforgottenRealms.Common.Resources;
using UnforgottenRealms.Game.Graphics;
using UnforgottenRealms.Game.World.Geometry;

namespace UnforgottenRealms.Game.World.Terrains
{
    public class Desert : Terrain
    {
        public static TerrainFactory Factory => (location, model, resources) => new Desert(location, model, resources);

        public Desert(Field location, HexModel model, ResourceManager resources) : 
            base(
                model: model,
                movementCost: 2,
                location: location,
                textureDescriptor: resources.Get<GameTilesets>().Terrain.Desert,
                type: TerrainType.Land
            )
        {

        }
    }
}
