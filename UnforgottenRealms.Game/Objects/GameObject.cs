using SFML.Graphics;
using System.Collections.Generic;
using UnforgottenRealms.Game.Events;
using UnforgottenRealms.Game.Players;
using UnforgottenRealms.Game.World;
using UnforgottenRealms.Game.Gui.ContextPreview;
using UnforgottenRealms.Game.Objects.Abilities;

namespace UnforgottenRealms.Game.Objects
{
    public abstract class GameObject : Drawable, IContextInfoSubject
    {
        private List<Ability> abilities = new List<Ability>();

        public abstract string Name { get; }

        public IEnumerable<Ability> Abilities => abilities;
        public Field Location { get; protected set; }
        public Player Owner { get; protected set; }

        public GameObject(Field location, Player owner)
        {
            Location = location;
            Owner = owner;

            Location.World.TurnCycle.RoundChanged += Refresh;
        }

        public abstract void Draw(RenderTarget target, RenderStates states);

        public abstract IEnumerable<ContextInfoContent> GetContextInfoContent();

        public abstract void PerformPrimaryAction(Field target);

        public abstract void Select(bool isSelected);

        public Ability GrantAbility(AbilityFactory factory)
        {
            var ability = factory.Create(Location.World.Resources);
            abilities.Add(ability);
            return ability;
        } 

        protected virtual void Refresh(object sender, RoundChangedEventArgs e)
        {
        }

        protected virtual void Destroyed()
        {
            Location.World.TurnCycle.RoundChanged -= Refresh;
        }
    }
}
