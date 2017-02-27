using UnforgottenRealms.Common.Definitions.Entity;
using UnforgottenRealms.Game.Graphics;

namespace UnforgottenRealms.Game.World.Terrains
{
    public class Forest : Terrain
    {
        public static TerrainFactory Factory => location => new Forest(location);

        public override EntityId Id => TerrainDefinitions.Forest;
        public override int MovementCost => 2;
        public override string Name => "FOREST";
        public override TerrainType Type => TerrainType.Land;

        public Forest(Field location) :
            base(
                location: location,
                textureDescriptor: location.World.Resources.Get<GameTilesets>().Terrain.Forest
            )
        {
        }
    }
}
