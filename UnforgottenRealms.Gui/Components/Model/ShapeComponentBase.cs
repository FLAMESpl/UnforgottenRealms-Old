using System;
using UnforgottenRealms.Gui.Components.Container;
using UnforgottenRealms.Gui.Components.Events;
using UnforgottenRealms.Common.Messaging;
using UnforgottenRealms.Common.Helper;
using UnforgottenRealms.Gui.Components.EventArguments;
using SFML.Window;
using SFML.Graphics;

namespace UnforgottenRealms.Gui.Components.Model
{
    /// <summary>
    /// Base of SFML shape based components
    /// </summary>
    public abstract class ShapeComponentBase : IComponent,
        IEventHandler<FocusGranted>,
        IEventHandler<MouseClicked>,
        IEventHandler<MouseMoved>

    {
        public event EventHandler<FocusChangeEventArgs> FocusChange;
        public event EventHandler<MouseButtonEventArgs> MouseClick;
        public event EventHandler<MouseMoveEventArgs> MouseEnter;
        public event EventHandler<MouseMoveEventArgs> MouseLeave;

        private IComponentContainer _container;
        private Vector2f _position;
        private Vector2f _textPosition;
        private Text _text;
        private Shape _shape;

        public IComponentContainer Container
        {
            get
            {
                return _container;
            }
            set
            {
                _container = value;
                if (Shape != null)
                    Position = _position;
            }
        }
        public bool ContainsCursor { get; protected set; }
        public bool HasFocus { get; protected set; }

        /// <summary>
        /// Relative to component's position
        /// </summary>
        public virtual Vector2f Position
        {
            get
            {
                return _position;
            }
            set
            {
                if (Container != null && Shape != null)
                {
                    Shape.Position = Container.Position + value;
                    TextPosition = _textPosition;
                }
                _position = value;
            }
        }

        /// <summary>
        /// Relative to component's and container's position
        /// </summary>
        public virtual Vector2f TextPosition
        {
            get
            {
                return _textPosition;
            }
            set
            {
                _textPosition = value;
                if (Text != null && Shape != null)
                    Text.Position = value + Shape.Position;
            }
        }
        public Text Text { get; set; }

        /// <summary>
        /// Background shape
        /// </summary>
        public Shape Shape { get; set; }
        public virtual Vector2f Size 
            => Shape != null ? Shape.GetGlobalBounds().Size() : new Vector2f(0, 0);
        
        public virtual void Draw(RenderTarget target, RenderStates states)
        {
            if (Shape != null)
                target.Draw(Shape, states);

            if (Text != null)
                target.Draw(Text, states);
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
            if (Shape.GetGlobalBounds().Contains(@event.Mouse.X, @event.Mouse.Y))
            {
                SetFocus(true);
                OnMouseClick(@event.Mouse);
            }
        }

        public virtual void Handle(MouseMoved @event)
        {
            bool contains = Shape.GetGlobalBounds().Contains(@event.Mouse.X, @event.Mouse.Y);

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
