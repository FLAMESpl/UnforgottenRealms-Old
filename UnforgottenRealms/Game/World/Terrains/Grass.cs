using UnforgottenRealms.Common.Resources;
using UnforgottenRealms.Game.Graphics;
using UnforgottenRealms.Game.World.Geometry;

namespace UnforgottenRealms.Game.World.Terrains
{
    public class Grass : Terrain
    {
        public static TerrainFactory Factory => (location, model, resources) => new Grass(location, model, resources);

        public Grass(Field location, HexModel model, ResourceManager resources) :
            base(
                location: location, 
                model: model,
                movementCost: 1,
                textureDescriptor: resources.Get<GameTilesets>().Terrain.Grass,
                type: TerrainType.Land
            )
        { 
        }
    }
}
