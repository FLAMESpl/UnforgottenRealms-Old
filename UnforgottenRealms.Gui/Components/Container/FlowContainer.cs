﻿using System;
using System.Collections;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.Window;
using UnforgottenRealms.Common.Window;
using UnforgottenRealms.Gui.Components.Model;
using UnforgottenRealms.Gui.Components.Events;
using UnforgottenRealms.Common.Messaging;
using UnforgottenRealms.Common.Utils;

namespace UnforgottenRealms.Gui.Components.Container
{
    /*public class FlowContainer : Drawable, IComponentContainer
    {
        protected GameWindow _window;
        protected List<IComponent> _components = new List<IComponent>();

        public Vector2f Position { get; set; }
        public bool Enabled { get; set; } = true;
        public IComponent Focused { get; protected set; }

        public Bus Bus { get; private set; }

        public FlowContainer() { }

        public IEnumerator<IComponent> GetEnumerator() => _components.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public bool Acknowledged() => Enabled;

        public void Add(IComponent component)
        {
            component.Container = this;
            _components.Add(component);
        }

        public void Clear()
        {
            _components.ForEach(c => c.Container = null);
            _components.Clear();
        }

        public void Remove(IComponent component)
        {
            component.Container = null;
            _components.Remove(component);
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

        public void Register(IEventDispatcher dispatcher)
        {
            Bus = new Bus(dispatcher.Bus);
            Bus.MouseClick += (s, e) => Handle(new MouseClicked { Mouse = e });
            Bus.MouseMove += (s, e) => Handle(new MouseMoved { Mouse = e });
            Bus.TextEnter += (s, e) => Handle(new TextEntered { Text = e });
        }

        public virtual void Handle(MouseClicked @event) => Bus.Publish(@event, _components);

        public virtual void Handle(MouseMoved @event) => Bus.Publish(@event, _components);

        public virtual void Handle(TextEntered @event) => Bus.Publish(@event, _components);

        public void Draw(RenderTarget target, RenderStates states)
        {
            if (Enabled)
                foreach (var item in _components)
                    target.Draw(item, states);
        }
    }*/
}
