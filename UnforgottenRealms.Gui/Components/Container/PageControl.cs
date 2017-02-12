using System.Collections.Generic;
using UnforgottenRealms.Common.Messaging;

namespace UnforgottenRealms.Gui.Components.Container
{
    public class PageControl : IEventDispatcher
    {
        private List<IComponentContainer> _pages;

        public Bus Bus { get; private set; }
        public IComponentContainer Active { get; protected set; }
        public IEnumerable<IComponentContainer> Pages => _pages;

        public PageControl()
        {
            _pages = new List<IComponentContainer>();
            Bus = new Bus();
            Bus.MouseClick += (s, e) => Active?.Bus.Forward(s, e);
            Bus.MouseMove += (s, e) => Active?.Bus.Forward(s, e);
            Bus.TextEnter += (s, e) => Active?.Bus.Forward(s, e);
        }

        public void Add(params IComponentContainer[] items)
        {
            foreach (var item in items)
                item.Enabled = false;
            _pages.AddRange(items);
        }

        public void Remove(params IComponentContainer[] items)
        {
            foreach (var item in items)
                _pages.Remove(item);
        }

        public void Set(IComponentContainer container)
        {
            if (_pages.Contains(container))
            {
                if (Active != null)
                {
                    Active.Enabled = false;
                    Active.SetFocus(null);
                }
                container.Enabled = true;
                Active = container;
            }
        }
        
        public bool Acknowledge() => true;
    }
}
