using UnforgottenRealms.Common.Resources;
using UnforgottenRealms.Game.Graphics;
using UnforgottenRealms.Game.World.Coordinates;
using UnforgottenRealms.Game.World.Geometry;

namespace UnforgottenRealms.Game.World.Terrain
{
    public class Desert : Field
    {
        public Desert(OffsetCoordinates position, HexModel model, ResourceManager resources) : 
            base(
                model: model,
                movementCost: 2,
                position: position,
                textureDescriptor: resources.Get<GameTilesets>().Terrain.Desert,
                type: TerrainType.Land
            )
        {

        }
    }
}
