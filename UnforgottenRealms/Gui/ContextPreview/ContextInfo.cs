using SFML.Graphics;
using System.Collections.Generic;
using SFML.Window;
using UnforgottenRealms.Common.Utils;
using System.Linq;

namespace UnforgottenRealms.Gui.ContextPreview
{
    public class ContextInfo : Drawable
    {
        private static uint FONT_SIZE = 17;
        private static float SPACING = 4;
        private static Vector2f MARGIN = new Vector2f(6, 6);

        private RectangleShape frame;
        private float length;
        private Vector2f position;
        private IEnumerable<Text> textLines;

        public bool HasContent { get; private set; } = false;

        public ContextInfo(Vector2f position, float length)
        {
            this.position = position;
            this.length = length;
        }

        public void SetContent(IEnumerable<ContextInfoContent> content)
        {
            var hasContent = content.Any();
            if (!hasContent)
            {
                HasContent = hasContent;
                return;
            }

            var subsequentPosition = MARGIN;

            FloatRect bounds = new FloatRect();
            var textLines = content.SelectMany(c =>
            {
                var result = c.Lines.Select(line =>
                {
                    var text = new Text
                    {
                        CharacterSize = FONT_SIZE,
                        Color = line.Color,
                        DisplayedString = line.Text,
                        Font = FontExtensions.Font,
                        Position = subsequentPosition
                    };
                    bounds = text.GetLocalBounds();
                    subsequentPosition += new Vector2f(0, bounds.Height + SPACING);
                    return text;
                });
                subsequentPosition += new Vector2f(0, bounds.Height + SPACING);
                return result;

            }).ToList();

            var framePosition = new Vector2f(position.X, position.Y - subsequentPosition.Y);
            textLines.ForEach(t => t.Position += new Vector2f(position.X, position.Y - subsequentPosition.Y - MARGIN.Y));
            
            frame = new RectangleShape
            {
                FillColor = new Color(255, 255, 255, 155),
                Position = framePosition,
                Size = new Vector2f(length, subsequentPosition.Y + MARGIN.Y)
            };

            this.textLines = textLines;
            HasContent = hasContent;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(frame, states);
            foreach (var textLine in textLines)
                target.Draw(textLine, states);
        }
    }
}
