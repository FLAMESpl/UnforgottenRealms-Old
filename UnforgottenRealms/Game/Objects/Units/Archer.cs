using UnforgottenRealms.Common.Resources;
using UnforgottenRealms.Game.Graphics;
using UnforgottenRealms.Game.Players;
using UnforgottenRealms.Game.World;
using UnforgottenRealms.Game.World.Coordinates;
using UnforgottenRealms.Game.World.Geometry;

namespace UnforgottenRealms.Game.Objects.Units
{
    public class Archer : Unit
    {
        public static UnitFactory Factory => (location, model, resources, owner) => new Archer(location, model, resources, owner);

        public Archer(Field location, HexModel model, ResourceManager resources, Player owner) :
            base(
                location: location,
                hexModel: model,
                movement: 2,
                resources: resources,
                textureDescriptor: resources.Get<GameTilesets>().Units.Archer,
                owner: owner
            )
        {

        }
    }
}
