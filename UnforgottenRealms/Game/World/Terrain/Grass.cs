using UnforgottenRealms.Common.Resources;
using UnforgottenRealms.Game.Graphics;
using UnforgottenRealms.Game.World.Coordinates;
using UnforgottenRealms.Game.World.Geometry;

namespace UnforgottenRealms.Game.World.Terrain
{
    public class Grass : AbstractTerrain
    {
        public Grass(OffsetCoordinates position, HexModel model, ResourceManager resources) :
            base(
                position: position, 
                model: model,
                movementCost: 1,
                textureDescriptor: resources.Get<GameTilesets>().Terrain.Grass,
                type: TerrainType.Land
            )
        { 
        }
    }
}
