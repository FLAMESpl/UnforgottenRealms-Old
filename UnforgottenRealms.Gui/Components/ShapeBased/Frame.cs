using System.Linq;
using SFML.Graphics;
using UnforgottenRealms.Common.Messaging;
using UnforgottenRealms.Gui.Components.Container;
using UnforgottenRealms.Gui.Components.Events;
using UnforgottenRealms.Gui.Components.Model;
using SFML.Window;

namespace UnforgottenRealms.Gui.Components.ShapeBased
{
    public class Frame : ShapeComponentBase, IComponentEventHandler
    {
        public ComponentContainer Components { get; set; } = new ComponentContainer();
        public override Vector2f Position
        {
            get
            {
                return base.Position;
            }
            set
            {
                base.Position = value;
                Components.Position = value;
            }
        }

        public Frame() { }

        public override void Handle(MouseClicked @event) => Bus.Publish(@event, Components);

        public override void Handle(MouseMoved @event) => Bus.Publish(@event, Components);

        public virtual void Handle(TextEntered @event) => Bus.Publish(@event, Components);

        public override void SetFocus(bool focused) => Components.FirstOrDefault()?.SetFocus(focused);

        public override void Draw(RenderTarget target, RenderStates states)
        {
            base.Draw(target, states);
            target.Draw(Components, states);
        }
    }
}
