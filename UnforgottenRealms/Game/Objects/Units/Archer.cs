using UnforgottenRealms.Common.Resources;
using UnforgottenRealms.Game.Graphics;
using UnforgottenRealms.Game.Players;
using UnforgottenRealms.Game.World.Coordinates;
using UnforgottenRealms.Game.World.Geometry;

namespace UnforgottenRealms.Game.Objects.Units
{
    public class Archer : Unit
    {
        public Archer(AxialCoordinates position, HexModel model, ResourceManager resources, Player owner) :
            base(
                position: position,
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
