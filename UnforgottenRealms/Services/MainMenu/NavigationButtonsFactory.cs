using SFML.Graphics;
using SFML.Window;
using System;
using UnforgottenRealms.Common.Utils;
using UnforgottenRealms.Gui.Components.ShapeBased;

namespace UnforgottenRealms.Services.MainMenu
{
    public class NavigationButtonsFactory
    {
        public int ExpectedItems { get; set; }
        public float Height { get; set; } = 50;
        public Color HighlightColor { get; set; }
        public Color IdleColor { get; set; }
        public uint FontSize { get; set; }
        public Color TextColor { get; set; }
        public float Width { get; set; }
        public uint WindowHeight { get; set; }

        public Button New(int position, string caption, EventHandler<MouseButtonEventArgs> eventHandler)
        {
            var pxPosition = new Vector2f
            {
                X = 0,
                Y = (WindowHeight - ExpectedItems * Height) / 2 + position * Height
            };

            var button = new Button
            {
                HighlightBackgroundColor = HighlightColor,
                HighlightEnabled = true,
                HighlightTextColor = TextColor,
                IdleBackgroundColor = IdleColor,
                IdleTextColor = TextColor,
                Shape = new RectangleShape
                {
                    FillColor = IdleColor,
                    Size = new Vector2f(Width, Height)
                },
                Text = new Text
                {
                    CharacterSize = FontSize,
                    Color = TextColor,
                    DisplayedString = caption,
                    Font = FontExtensions.Font
                }
            };

            button.Position = pxPosition;
            button.TextPosition = new Vector2f(6, 6);

            button.MouseClick += eventHandler;

            return button;
        }
    }
}
