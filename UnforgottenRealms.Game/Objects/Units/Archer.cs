using UnforgottenRealms.Game.Graphics;
using UnforgottenRealms.Game.Players;
using UnforgottenRealms.Game.World;

namespace UnforgottenRealms.Game.Objects.Units
{
    public class Archer : Unit
    {
        public static UnitFactory Factory => (location, owner) => new Archer(location, owner);

        public override int Combats => 1;
        public override float Health => 100;
        public override int Movement => 2;
        public override string Name => "ARCHER";
        public override float Strength => 7;

        public Archer(Field location, Player owner) :
            base(
                location: location,
                textureDescriptor: location.World.Resources.Get<GameTilesets>().Units.Archer,
                owner: owner
            )
        {

        }
    }
}
