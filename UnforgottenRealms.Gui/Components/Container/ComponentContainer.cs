using SFML.Graphics;
using SFML.Window;
using System.Collections.Generic;
using UnforgottenRealms.Common.Messaging;
using UnforgottenRealms.Common.Window;
using UnforgottenRealms.Gui.Components.Events;
using UnforgottenRealms.Gui.Components.Model;
using System.Collections;
using UnforgottenRealms.Common.Utils;
using System;

namespace UnforgottenRealms.Gui.Components.Container
{
    public class ComponentContainer : Drawable,
        IComponentContainer, IComponentEventHandler

    {
        protected List<IComponent> _components = new List<IComponent>();
        protected Vector2f _position;
        protected GameWindow _window = null;

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

        public virtual void Add(IComponent component)
        {
            component.Container = this;
            _components.Add(component);
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

        public void Register(GameWindow window)
        {
            _window = window;
            _window.MouseButtonPressed += (s, e) => Handle(new MouseClicked { Mouse = e });
            _window.MouseMoved += (s, e) => Handle(new MouseMoved { Mouse = e });
            _window.TextEntered += (s, e) => Handle(new TextEntered { Text = e });
        }

        public virtual void Handle(MouseClicked @event)
        {
            if (Enabled) Bus.Publish(@event, _components);
        } 

        public virtual void Handle(MouseMoved @event)
        {
            if (Enabled) Bus.Publish(@event, _components);
        }

        public virtual void Handle(TextEntered @event)
        {
            if (Enabled) Bus.Publish(@event, _components);
        }

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