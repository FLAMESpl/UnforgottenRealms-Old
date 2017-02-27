using UnforgottenRealms.Common.Definitions.Entity;
using UnforgottenRealms.Game.Graphics;
using UnforgottenRealms.Game.Players;
using UnforgottenRealms.Game.World;

namespace UnforgottenRealms.Game.Objects.Units
{
    public class Swordsman : Unit
    {
        public static UnitFactory Factory => (location, owner) => new Swordsman(location, owner);

        public override EntityId Id => UnitsDefinitions.Swordsman;
        public override int Combats => 1;
        public override string Name => "SWORDSMAN";
        public override UnitType Type => UnitType.Military;
        public override float Strength => 9;
        public override int Health => 100;
        public override int Movement => 2;


        public Swordsman(Field location, Player owner) :
            base(
                location: location,
                textureDescriptor: location.World.Resources.Get<GameTilesets>().Units.Swordsman,
                owner: owner
            )
        {
        }
    }
}
