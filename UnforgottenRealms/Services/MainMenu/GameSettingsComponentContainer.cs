using System;
using System.Collections.Generic;
using UnforgottenRealms.Gui.Components.Container;
using UnforgottenRealms.Gui.Components.ShapeBased;

namespace UnforgottenRealms.Services.MainMenu
{
    public class GameSettingsComponentContainer : ComponentContainer
    {
        private Stack<TextBox> textBoxes = new Stack<TextBox>();

        public void AddPlayerNameTextBox(GameSettingsService factory, int amount)
        {
            int count = textBoxes.Count + amount + 1;
            for (int i = textBoxes.Count + 1; i < count; i++)
            {
                var textBox = factory.PlayerNameTextBox(i);
                textBoxes.Push(textBox);
                Add(textBox);
            }
        }

        public void RemovePlayerNameTextBox(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                var textBox = textBoxes.Pop();
                Remove(textBox);
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
