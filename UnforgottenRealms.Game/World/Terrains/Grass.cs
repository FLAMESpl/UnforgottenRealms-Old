using UnforgottenRealms.Common.Definitions.Entity;
using UnforgottenRealms.Game.Graphics;

namespace UnforgottenRealms.Game.World.Terrains
{
    public class Grass : Terrain
    {
        public static TerrainFactory Factory => (location) => new Grass(location);

        public override EntityId Id => TerrainDefinitions.Grass;
        public override int MovementCost => 1;
        public override string Name => "GRASS";
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
