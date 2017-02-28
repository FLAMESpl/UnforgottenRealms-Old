using System.Collections.Generic;
using UnforgottenRealms.Common.Graphics;
using UnforgottenRealms.Common.Utils;
using UnforgottenRealms.Game.Gui.ContextPreview;

namespace UnforgottenRealms.Game.Objects.Abilities
{
    public abstract class Ability : IContextInfoSubject
    {
        public abstract string Name { get; }
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

        public IEnumerable<ContextInfoContent> GetContextInfoContent()
        {
            yield return new ContextInfoContent(GetContextInfoLines());
        }

        protected abstract IEnumerable<ContextInfoLine> GetDescription();

        private IEnumerable<ContextInfoLine> GetContextInfoLines()
        {
            yield return new ContextInfoLine(Owner.Owner.Colour.ToRGB(), $"{Name} ({Type.ToString().ToUpper()})");
            foreach (var line in GetDescription())
                yield return line;
        }
    }
}
