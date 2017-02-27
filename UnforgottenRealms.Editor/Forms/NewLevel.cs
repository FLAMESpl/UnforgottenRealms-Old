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
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
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

                OnNewLevelCreated(new NewLevelEventArgs(
                    name: nameTextBox.Text,
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
