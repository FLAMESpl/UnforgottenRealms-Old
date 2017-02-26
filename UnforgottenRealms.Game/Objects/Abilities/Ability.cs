using UnforgottenRealms.Common.Graphics;

namespace UnforgottenRealms.Game.Objects.Abilities
{ 
    public abstract class Ability
    {
        public abstract AbilityType Type { get; }

        public GameObject Owner { get; }
        public Tile Tile { get; }

        public Ability(Tile tile, GameObject owner)
        {
            Owner = owner;
            Tile = tile;
        }

        public virtual void Remove() { }

        public virtual void Use() { }
    }
}
