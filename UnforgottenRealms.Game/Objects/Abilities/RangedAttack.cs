using UnforgottenRealms.Common.Resources;
using UnforgottenRealms.Game.Objects.Units;
using UnforgottenRealms.Game.World.Terrains;

namespace UnforgottenRealms.Game.Objects.Abilities
{
    public class RangedAttack : Ability
    {
        private Unit owner;

        public static AbilityFactory Factory(Unit owner) => new RangedAttackFactory(owner);

        public override AbilityType Type => AbilityType.Passive;

        public RangedAttack(Unit owner, ResourceManager resources) : base(null, owner)
        {
            this.owner = owner;
        }

        public virtual void Perform(Unit foe)
        {
            var strengthRatio = owner.EffectiveStrengthAgainst(foe) / foe.EffectiveStrengthAgainst(owner);
            var damage = owner.DamageAmount(strengthRatio);
            var dealtDamage = strengthRatio >= 1 ? damage : owner.CounterDamageAmount(strengthRatio, damage);

            if (foe.Location.Terrain is Forest)
                dealtDamage /= 2;

            var enemyDestroyed = foe.Damage((int)dealtDamage);
            owner.SpendCombat();
            owner.SpendMovement(1);
        }
    }

    public class RangedAttackFactory : AbilityFactory
    {
        private Unit owner;

        public RangedAttackFactory(Unit owner)
        {
            this.owner = owner;
        }

        public override Ability Create(ResourceManager resources) => new RangedAttack(owner, resources);
    }
}
