using SFML.Graphics;
using System;
using System.Collections.Generic;
using UnforgottenRealms.Common.Resources;
using UnforgottenRealms.Game.Graphics;
using UnforgottenRealms.Game.Gui.ContextPreview;
using UnforgottenRealms.Game.Objects.Units;
using UnforgottenRealms.Game.World.Terrains;

namespace UnforgottenRealms.Game.Objects.Abilities
{
    public class RangedAttack : Ability
    {
        private Unit owner;

        public static AbilityFactory Factory(Unit owner) => new RangedAttackFactory(owner);

        public override string Name => "RANGED ATTACK";
        public override AbilityType Type => AbilityType.Passive;

        public RangedAttack(Unit owner, ResourceManager resources) : 
            base(
                tile: resources.Get<GameTilesets>().Abilities.RangedAttack, 
                owner: owner
            )
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

        protected override IEnumerable<ContextInfoLine> GetDescription()
        {
            yield return new ContextInfoLine(Color.Black, "IMMUNE TO COUNTER-ATTACKS");
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
