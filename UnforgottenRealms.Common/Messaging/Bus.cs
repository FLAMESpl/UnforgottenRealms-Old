using SFML.Window;
using System;
using System.Collections;
using System.Linq;
using UnforgottenRealms.Common.Window;

namespace UnforgottenRealms.Common.Messaging
{
    public class Bus
    {
        public event EventHandler<MouseButtonEventArgs> MouseClick;
        public event EventHandler<MouseMoveEventArgs> MouseMove;
        public event EventHandler<TextEventArgs> TextEnter;

        public Bus(GameWindow window)
        {
            window.MouseButtonPressed += OnMouseClick;
            window.MouseMoved += OnMouseMove;
            window.TextEntered += OnTextEnter;
        }

        public Bus(Bus bus)
        {
            bus.MouseClick += OnMouseClick;
            bus.MouseMove += OnMouseMove;
            bus.TextEnter += OnTextEnter;
        }

        private void OnMouseClick(object sender, MouseButtonEventArgs e) => MouseClick?.Invoke(sender, e);
        private void OnMouseMove(object sender, MouseMoveEventArgs e) => MouseMove?.Invoke(sender, e);
        private void OnTextEnter(object sender, TextEventArgs e) => TextEnter?.Invoke(sender, e);

        public static void Publish<T>(T @event, IEnumerable observers) where T : IEvent
        {
            foreach (var observer in observers.OfType<IEventHandler<T>>().ToList())
                observer.Handle(@event);
        }
    }
}
