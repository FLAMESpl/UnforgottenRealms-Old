using SFML.Window;
using System;
using System.Windows.Forms;
using UnforgottenRealms.Editor.Events;

namespace UnforgottenRealms.Editor.Forms
{
    public partial class NewLevel : Form
    {
        public event EventHandler<NewLevelEventArgs> NewLevelCreated;

        public NewLevel()
        {
            InitializeComponent();

            okCancelDialog.Ok += ButtonOkClick;
            okCancelDialog.Cancel += ButtonCancelClick;
        }

        public void SetAllowedNumbersOfPlayers(params int[] allowedNumbersOfPlayers)
        {
            foreach (var allowedNumberOfPlayer in allowedNumbersOfPlayers)
                playersComboBox.Items.Add(allowedNumberOfPlayer);
        }

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonOkClick(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                ShowError("Level name cannot be empty");
                return;
            }

            try
            {
                var width = Int32.Parse(widthTextBox.Text);
                var height = Int32.Parse(heightTextBox.Text);

                if (width < 10 || height < 10)
                {
                    ShowError("Level dimensions cannot be smaller than 10");
                    return;
                }
                if (playersComboBox.SelectedItem == null)
                {
                    ShowError("Number of players must be selected");
                    return;
                }

                OnNewLevelCreated(new NewLevelEventArgs(
                    name: nameTextBox.Text,
                    numberOfPlayers: (int)playersComboBox.SelectedItem,
                    size: new Vector2i(width, height)
                ));
                Close();
            }
            catch(FormatException)
            {
                ShowError("Level size must be a number");
            }
        }

        protected void OnNewLevelCreated(NewLevelEventArgs e)
        {
            NewLevelCreated?.Invoke(this, e);
        }

        private void ShowError(string errorMsg) => MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
