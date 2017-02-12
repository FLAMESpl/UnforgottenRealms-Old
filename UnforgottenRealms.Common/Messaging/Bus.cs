using SFML.Window;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnforgottenRealms.Common.Window;

namespace UnforgottenRealms.Common.Messaging
{
    public class Bus
    {
        public event EventHandler<MouseButtonEventArgs> MouseClick;
        public event EventHandler<MouseMoveEventArgs> MouseMove;
        public event EventHandler<TextEventArgs> TextEnter;
        
        public void Subscribe(GameWindow window)
        {
            window.MouseButtonPressed += MouseClick;
            window.MouseMoved += MouseMove;
            window.TextEntered += TextEnter;
        }

        public void Forward(object sender, MouseButtonEventArgs e) => MouseClick?.Invoke(sender, e);
        public void Forward(object sender, MouseMoveEventArgs e) => MouseMove?.Invoke(sender, e);
        public void Forward(object sender, TextEventArgs e) => TextEnter?.Invoke(sender, e);

        public static void Publish<T>(T @event, IEnumerable observers) where T : IEvent
        {
            foreach (var observer in observers.OfType<IEventHandler<T>>().ToList())
                observer.Handle(@event);
        }
    }
}
