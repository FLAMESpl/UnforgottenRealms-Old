using SFML.Graphics;
using System;
using System.Linq;
using UnforgottenRealms.Common.Messaging;
using UnforgottenRealms.Common.Utils;
using UnforgottenRealms.Gui.Components.EventArguments;
using UnforgottenRealms.Gui.Components.Events;
using UnforgottenRealms.Gui.Components.Model;

namespace UnforgottenRealms.Gui.Components.ShapeBased
{
    public class TextBox : ShapeComponentBase,
        IEventHandler<TextEntered>

    {
        public event EventHandler<TextEnterEventArgs> TextEnter;

        public Color IdleBackgroundColor { get; set; }
        public Color IdleTextColor { get; set; }
        public Color HighlightBackgroundColor { get; set; }
        public Color HighlightTextColor { get; set; }
        public bool HighlightEnabled { get; set; } = true;
        public bool Highlighted { get; protected set; }
        public int MaxLength { get; set; }
        public Func<char, bool> InputValidator { get; set; }

        public TextBox()
        {
            FocusChange += HighlightOn;
            FocusChange += HighlightOff;
        }

        public void HighlightOn(object sender, FocusChangeEventArgs e)
        {
            if (HighlightEnabled && e.Focused)
            {
                if (Shape != null)
                    Shape.FillColor = HighlightBackgroundColor;
                if (Text != null)
                    Text.Color = HighlightTextColor;
            }
        }

        public void HighlightOff(object sender, FocusChangeEventArgs e)
        {
            if (HighlightEnabled && !e.Focused)
            {
                if (Shape != null)
                    Shape.FillColor = IdleBackgroundColor;
                if (Text != null)
                    Text.Color = IdleTextColor;
            }
        }

        public void Handle(TextEntered @event)
        {
            if (HasFocus)
            {
                var eventArgs = new TextEnterEventArgs();
                eventArgs.OldText = Text.DisplayedString;
                TextInput(@event);
                eventArgs.NewText = Text.DisplayedString;
                OnTextEnter(eventArgs);
            }
        }

        public void OnTextEnter(TextEnterEventArgs args) => TextEnter?.Invoke(this, args);

        protected virtual void TextInput(TextEntered @event)
        {
            var inputChar = @event.Text.Unicode.First();
            if (InputValidator != null && !InputValidator(inputChar))
                return;

            if (inputChar == TextEntered.Backspace)
            {
                Text.DisplayedString = Text.DisplayedString.RemoveLast();
            }
            else if (inputChar != TextEntered.CarriageReturn
                && MaxLength > Text.DisplayedString.Length)
            {
                Text.DisplayedString += inputChar;
            }
        }
    }
}
