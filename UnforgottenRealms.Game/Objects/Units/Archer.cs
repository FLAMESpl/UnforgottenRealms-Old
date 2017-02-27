using UnforgottenRealms.Game.Graphics;
using UnforgottenRealms.Game.Objects.Abilities;
using UnforgottenRealms.Game.Players;
using UnforgottenRealms.Game.World;

namespace UnforgottenRealms.Game.Objects.Units
{
    public class Archer : Unit
    {
        public static UnitFactory Factory => (location, owner) => new Archer(location, owner);

        public override int Combats => 1;
        public override int Health => 100;
        public override int Movement => 2;
        public override UnitType Type => UnitType.Military;
        public override string Name => "ARCHER";
        public override float Strength => 7;

        private RangedAttack rangedAttack;

        public Archer(Field location, Player owner) :
            base(
                location: location,
                textureDescriptor: location.World.Resources.Get<GameTilesets>().Units.Archer,
                owner: owner
            )
        {
            rangedAttack = (RangedAttack)GrantAbility(RangedAttack.Factory(this));
        }

        protected override void Attack(Field target)
        {
            if (MovementLeft == 0 || CombatsLeft == 0)
                return;

            var foe = target.Units.StrongestOpponent(this);

            if (foe.Type != UnitType.Civil)
                rangedAttack.Perform(foe);
            else
            {
                foe.Destroy();
                Move(target);
            }
        }
    }
}
