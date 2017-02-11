using System.Collections.Generic;

namespace UnforgottenRealms.Gui.Components.Container
{
    public class PageControl
    {
        private List<IComponentContainer> _pages;

        public IComponentContainer Active { get; protected set; }
        public IEnumerable<IComponentContainer> Pages => _pages;

        public PageControl()
        {
            _pages = new List<IComponentContainer>();
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
    }
}
