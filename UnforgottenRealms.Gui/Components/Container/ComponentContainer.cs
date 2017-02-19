using SFML.Graphics;
using SFML.Window;
using System.Collections.Generic;
using UnforgottenRealms.Common.Messaging;
using UnforgottenRealms.Common.Window;
using UnforgottenRealms.Gui.Components.Events;
using UnforgottenRealms.Gui.Components.Model;
using System.Collections;

namespace UnforgottenRealms.Gui.Components.Container
{
    public class ComponentContainer : Drawable, IComponentContainer
    {
        protected List<IComponent> _components = new List<IComponent>();
        protected Vector2f _position;
        protected GameWindow _window = null;

        public Bus Bus { get; private set; } = new Bus();

        public bool Enabled { get; set; } = true;
        public IComponent Focused { get; protected set; }
        public Vector2f Position
        {
            get
            {
                return _position;   
            }
            set
            {
                var offset = value - _position;
                _components.ForEach(c => c.Position += offset);
                _position = value;
            }
        }

        public IEnumerator<IComponent> GetEnumerator() => _components.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public ComponentContainer()
        {
            Bus.RegisterComponentEvents(() => _components);
        }

        public virtual void Add(IComponent component)
        {
            component.Container = this;
            _components.Add(component);
            component.Invalidate();
        }

        public void Clear()
        {
            _components.ForEach(c => c.Container = null);
            _components.Clear();
        }

        public virtual void Draw(RenderTarget target, RenderStates states)
        {
            if (Enabled)
                foreach (var item in _components)
                    target.Draw(item, states);
        }

        public virtual void Remove(IComponent component)
        {
            component.Container = null;
            _components.Remove(component);
        }

        public virtual bool Acknowledge() => Enabled;

        public void SetFocus(IComponent target)
        {
            Focused = target;

            var @event = new FocusGranted
            {
                Target = target
            };

            Bus.Publish(@event, _components);
        }
    }
}