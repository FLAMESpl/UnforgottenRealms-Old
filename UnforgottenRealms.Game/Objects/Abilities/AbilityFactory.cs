using UnforgottenRealms.Common.Resources;

namespace UnforgottenRealms.Game.Objects.Abilities
{
    public abstract class AbilityFactory
    {
        public abstract Ability Create(ResourceManager resources);
    }
}
