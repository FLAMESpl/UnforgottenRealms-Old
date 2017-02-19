using SFML.Graphics;
using SFML.Window;
using UnforgottenRealms.Gui.Components.ShapeBased;
using UnforgottenRealms.Common.Utils;
using UnforgottenRealms.Services.Components;
using UnforgottenRealms.Common.Enums;

namespace UnforgottenRealms.Services.MainMenu
{
    public class GameSettingsService
    {
        private const string PLAYER_NAME_TEXT = "PLAYER";
        private const int PLAYER_NAME_MAX_LENGTH = 12;
        private const float PLAYER_NAME_WIDTH = 230;
        private const string PLAYER_NUMBER_CAPTION = "NUMBER OF PLAYERS";
        private const float PLAYER_NUMBER_WIDTH = 280;
        private const int DEFAULT_PLAYER_NUMBER = 2;
        private const float PLAYER_NUMBER_TEXTBOX_WIDTH = 50;
        private const float PLAYER_NUMBER_TEXTBOX_MARGIN = 10;
        private const float PLAYER_NAME_COLOR_BUTTON_MARGIN = 10;

        public Color BackgroundColor { get; set; }
        public Color ComponentColor { get; set; }
        public float ComponentMargin { get; set; }
        public Color HighlightColor { get; set; }
        public Color TextColor { get; set; }
        public uint FontSize { get; set; }
        public Font Font { get; set; }
        public float LeftMargin { get; set; }
        public float ComponentHeight { get; set; }
        public Vector2f SizeFactor { get; set; }
        public Vector2f TextPosition { get; set; }
        public float ComponentWidthFactor { get; set; }
        public Vector2u WindowSize { get; set; }
        public float FrameWidth => WindowSize.Y * (1 - 2 * SizeFactor.Y);
        

        public Frame NewFrame()
        {
            var frame = new Frame
            {
                Shape = new RectangleShape
                {
                    FillColor = BackgroundColor,
                    Size = new Vector2f(WindowSize.X - 2 * LeftMargin, FrameWidth)
                }
            };

            frame.Position = new Vector2f(LeftMargin, SizeFactor.Y * WindowSize.Y);

            return frame;
        }

        public Label PlayerNumberLabel()
        {
            var label = new Label
            {
                Shape = new RectangleShape
                {
                    FillColor = ComponentColor,
                    Size = new Vector2f(PLAYER_NUMBER_WIDTH, ComponentHeight)
                },
                Text = new Text
                {
                    DisplayedString = PLAYER_NUMBER_CAPTION,
                    CharacterSize = FontSize,
                    Font = Font,
                    Color = TextColor
                },
                Position = new Vector2f(0, ComponentMargin),
                TextPosition = TextPosition
            };

            return label;
        }

        public TextBox PlayerNumberTextBox()
        {
            var textBox = new SingleCharacterBox
            {
                HighlightBackgroundColor = HighlightColor,
                HighlightTextColor = TextColor,
                IdleBackgroundColor = ComponentColor,
                IdleTextColor = TextColor,
                Shape = new RectangleShape
                {
                    FillColor = ComponentColor,
                    Size = new Vector2f(PLAYER_NUMBER_TEXTBOX_WIDTH, ComponentHeight)
                },
                Text = new Text
                {
                    CharacterSize = FontSize,
                    Color = TextColor,
                    DisplayedString = DEFAULT_PLAYER_NUMBER.ToString(),
                    Font = Font
                },
                Position = new Vector2f(PLAYER_NUMBER_TEXTBOX_MARGIN + PLAYER_NUMBER_WIDTH, ComponentMargin),
                TextPosition = TextPosition
            };

            return textBox;
        }

        public TextBox PlayerNameTextBox(int index)
        {
            var textBox = new TextBox
            {
                HighlightBackgroundColor = HighlightColor,
                HighlightTextColor = TextColor,
                IdleBackgroundColor = ComponentColor,
                IdleTextColor = TextColor,
                MaxLength = PLAYER_NAME_MAX_LENGTH,
                Shape = new RectangleShape
                {
                   FillColor = ComponentColor,
                   Size = new Vector2f(PLAYER_NAME_WIDTH, ComponentHeight)
                },
                Text = new Text
                {
                    CharacterSize = FontSize,
                    Color = TextColor,
                    DisplayedString = PLAYER_NAME_TEXT,
                    Font = Font
                },
                Position = new Vector2f(0, TopComponentPosition(index, ComponentHeight, ComponentMargin)),
                TextPosition = TextPosition
            };

            return textBox;
        }

        public GameSettingsPlayerColourButton PlayerNameColorButton(int index)
        {
            var button = new GameSettingsPlayerColourButton
            {
                HighlightBackgroundColor = HighlightColor,
                HighlightTextColor = TextColor,
                IdleBackgroundColor = ComponentColor,
                IdleTextColor = TextColor,
                Shape = new RectangleShape
                {
                    Size = new Vector2f(ComponentHeight, ComponentHeight)
                },
                Position = new Vector2f(PLAYER_NAME_COLOR_BUTTON_MARGIN + PLAYER_NAME_WIDTH, TopComponentPosition(index, ComponentHeight, ComponentMargin)),
                TextPosition = TextPosition,
                Colour = PlayerColour.Red
            };

            return button;
        }

        private float TopComponentPosition(int index, float height, float margin)
        {
            return (height + margin) * index + margin;
        }
    }
}
