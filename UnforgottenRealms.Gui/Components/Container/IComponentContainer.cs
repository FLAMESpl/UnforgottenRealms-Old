using SFML.Graphics;
using SFML.Window;
using System.Collections.Generic;
using UnforgottenRealms.Common.Messaging;
using UnforgottenRealms.Common.Window;
using UnforgottenRealms.Gui.Components.Model;

namespace UnforgottenRealms.Gui.Components.Container
{
    public interface IComponentContainer : Drawable, IEnumerable<IComponent>, IEventDispatcher
    {
        Vector2f Position { get; set; }
        bool Enabled { get; set; }
        IComponent Focused { get; }

        void Add(IComponent component);
        void Clear();
        void Remove(IComponent component);
        void SetFocus(IComponent component);
    }
}
