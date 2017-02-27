using UnforgottenRealms.Common.Definitions.Entity;
using UnforgottenRealms.Game.Graphics;
using UnforgottenRealms.Game.Players;
using UnforgottenRealms.Game.World;

namespace UnforgottenRealms.Game.Objects.Units
{
    public class Worker : Unit
    {
        public static UnitFactory Factory => (location, owner) => new Worker(location, owner);

        public override EntityId Id => UnitsDefinitions.Worker;
        public override int Combats => 1;
        public override int Health => 100;
        public override int Movement => 2;
        public override string Name => "WORKER";
        public override float Strength => 0;
        public override UnitType Type => UnitType.Civil;

        public Worker(Field location, Player owner) :
            base(
                location: location,
                textureDescriptor: location.World.Resources.Get<GameTilesets>().Units.Worker,
                owner: owner
            )
        {
        }

        public override void PerformPrimaryAction(Field target)
        {
            if (target.ContainsOpponent(this))
                return;

            base.PerformPrimaryAction(target);
        }
    }
}
