using System;
using System.Collections.Generic;
using UnforgottenRealms.Common.Messaging;
using UnforgottenRealms.Gui.Components.Events;
using UnforgottenRealms.Gui.Components.Model;

namespace UnforgottenRealms.Gui.Components.Container
{
    public static class ContainerExtensions
    {
        public static void RegisterComponentEvents(this Bus bus, Func<IEnumerable<IComponent>> componentsProvider)
        {
            bus.MouseClick += (s, e) => Bus.Publish(new MouseClicked { Mouse = e }, componentsProvider.Invoke());
            bus.MouseMove += (s, e) => Bus.Publish(new MouseMoved { Mouse = e }, componentsProvider.Invoke());
            bus.TextEnter += (s, e) => Bus.Publish(new TextEntered { Text = e }, componentsProvider.Invoke());
        }
    }
}
