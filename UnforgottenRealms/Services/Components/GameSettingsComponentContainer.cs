using System;
using System.Collections.Generic;
using System.Linq;
using UnforgottenRealms.Gui.Components.Container;
using UnforgottenRealms.Gui.Components.ShapeBased;
using UnforgottenRealms.Services.MainMenu;
using UnforgottenRealms.Settings;

namespace UnforgottenRealms.Services.Components
{
    public class GameSettingsComponentContainer : ComponentContainer
    {
        private Stack<TextBox> textBoxes = new Stack<TextBox>();
        private Stack<GameSettingsPlayerColourButton> buttons = new Stack<GameSettingsPlayerColourButton>();

        public PlayerMetadata[] GetPlayersMetadata()
        {
            var playerNames = textBoxes.Select(t => t.Text.DisplayedString).ToArray();
            var playerColours = buttons.Select(b => b.Colour).ToArray();
            var players = new PlayerMetadata[playerNames.Length];

            for (int i = 0; i < textBoxes.Count; i++)
            {
                players[i] = new PlayerMetadata
                {
                    Colour = playerColours[i],
                    Name = playerNames[i],
                    Id = Math.Abs(textBoxes.Count - 1 - i)
                };
            }

            return players.OrderBy(p => p.Id).ToArray();
        }

        public void AddPlayerNameTextBox(GameSettingsService factory, int amount)
        {
            int count = textBoxes.Count + amount + 1;
            for (int i = textBoxes.Count + 1; i < count; i++)
            {
                var textBox = factory.PlayerNameTextBox(i);
                var button = factory.PlayerNameColorButton(i);
                textBoxes.Push(textBox);
                buttons.Push(button);
                Add(textBox);
                Add(button);
            }
        }

        public void RemovePlayerNameTextBox(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                var textBox = textBoxes.Pop();
                var button = buttons.Pop();
                Remove(textBox);
                Remove(button);
            }
        }

        public void UpdatePlayerNameTextBoxes(GameSettingsService factory, int difference)
        {
            if (difference > 0)
                AddPlayerNameTextBox(factory, difference);
            else if (difference < 0)
                RemovePlayerNameTextBox(Math.Abs(difference));
        }
    }
}
