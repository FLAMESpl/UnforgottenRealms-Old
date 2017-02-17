using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using UnforgottenRealms.Common.Messaging;

namespace UnforgottenRealms.Common.Window
{
    public class GameWindow : RenderWindow, IEventDispatcher
    {
        public List<Action> cycleActions = new List<Action>();

        public Bus Bus { get; }

        public bool Acknowledge() => true;

        public GameWindow(VideoMode video, string title, Styles styles, ContextSettings settings) 
            : base(video, title, styles, settings)
        {
            Closed += (s, e) => Close();
            Bus = new Bus();
            Bus.Subscribe(this);
        }

        public void Cycle() => cycleActions.ForEach(c => c.Invoke());

        public void EnsureClosed()
        {
            if (IsOpen()) Close();
        }

        public void OnKeyPress(Keyboard.Key key, Action action)
        {
            KeyPressed += (s, e) =>
            {
                if (e.Code == key)
                    action.Invoke();
            };
        }

        public void OnKeyHold(Keyboard.Key key, Action action)
        {
            cycleActions.Add(() =>
            {
                if (Keyboard.IsKeyPressed(key))
                    action.Invoke();
            });
        }
    }
}
