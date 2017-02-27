using SFML.Graphics;
using SFML.Window;
using System;
using UnforgottenRealms.Common.Helper;
using UnforgottenRealms.Common.Messaging;
using UnforgottenRealms.Gui.Components.Container;
using UnforgottenRealms.Gui.Components.EventArguments;
using UnforgottenRealms.Gui.Components.Events;

namespace UnforgottenRealms.Gui.Components.Model
{
    public class ImageComponentBase : IComponent,
        IEventHandler<FocusGranted>,
        IEventHandler<MouseClicked>,
        IEventHandler<MouseMoved>
    {
        public event EventHandler<FocusChangeEventArgs> FocusChange;
        public event EventHandler<MouseButtonEventArgs> MouseClick;
        public event EventHandler<MouseMoveEventArgs> MouseEnter;
        public event EventHandler<MouseMoveEventArgs> MouseLeave;

        private Vector2f _position;

        public IComponentContainer Container { get; set; }
        public bool ContainsCursor { get; protected set; }
        public bool HasFocus { get; protected set; }
        
        public Sprite Image { get; set; }

        public virtual Vector2f Position
        {
            get
            {
                return _position;
            }
            set
            {
                if (Container != null && Image != null)
                {
                    Image.Position = Container.Position + value;
                }
                _position = value;
            }
        }

        public virtual Vector2f Size => Image != null ? Image.GetGlobalBounds().Size() : new Vector2f(0, 0);

        public virtual bool Acknowledged() => true;

        public virtual void Draw(RenderTarget target, RenderStates states)
        {
            if (Image != null)
                target.Draw(Image, states);
        }

        public virtual void Invalidate()
        {
            Position = _position;
        }

        public virtual void Handle(FocusGranted @event)
        {
            bool focus = ReferenceEquals(this, @event.Target);
            if (focus != HasFocus)
            {
                HasFocus = focus;
                OnFocusChange(new FocusChangeEventArgs { Focused = focus });
            }
        }

        public virtual void Handle(MouseClicked @event)
        {
            if (Image.GetGlobalBounds().Contains(@event.Mouse.X, @event.Mouse.Y))
            {
                SetFocus(true);
                OnMouseClick(@event.Mouse);
            }
        }

        public virtual void Handle(MouseMoved @event)
        {
            bool contains = Image.GetGlobalBounds().Contains(@event.Mouse.X, @event.Mouse.Y);

            if (contains != ContainsCursor)
            {
                ContainsCursor = contains;
                if (contains)
                    OnMouseEnter(@event.Mouse);
                else
                    OnMouseLeave(@event.Mouse);
            }
        }

        public virtual void OnFocusChange(FocusChangeEventArgs args) => FocusChange?.Invoke(this, args);

        public virtual void OnMouseClick(MouseButtonEventArgs args) => MouseClick?.Invoke(this, args);

        public virtual void OnMouseEnter(MouseMoveEventArgs args) => MouseEnter?.Invoke(this, args);

        public virtual void OnMouseLeave(MouseMoveEventArgs args) => MouseLeave?.Invoke(this, args);

        public virtual void SetFocus(bool focused) => Container?.SetFocus(focused ? this : null);
    }
}
