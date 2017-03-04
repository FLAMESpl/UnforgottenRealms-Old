using System;
using System.Windows.Forms;
using UnforgottenRealms.Editor.Events;

namespace UnforgottenRealms.Editor.Forms
{
    public partial class PlayersOptions : Form
    {
        public event EventHandler<PlayersOptionsChangedEventArgs> PlayerOptionsChanged;

        public PlayersOptions()
        {
            InitializeComponent();

            okCancelDialog.Ok += OkDialogClicked;
            okCancelDialog.Cancel += CancelDialogClicked;
        }

        public void SetAllowedNumbersOfPlayers(params int[] allowedNumbersOfPlayers)
        {
            foreach (var allowedNumberOfPlayers in allowedNumbersOfPlayers)
                numberOfPlayersComboBox.Items.Add(allowedNumberOfPlayers);
        }

        private void CancelDialogClicked(object sender, EventArgs e)
        {
            Close();
        }

        private void OkDialogClicked(object sender, EventArgs e)
        {
            if (numberOfPlayersComboBox.SelectedItem == null)
            {
                ShowError("Number of players must be selected");
                return;
            }

            PlayerOptionsChanged?.Invoke(this, new PlayersOptionsChangedEventArgs(
                numberOfPlayers: (int)numberOfPlayersComboBox.SelectedItem
            ));

            Close();
        }

        private void ShowError(string errorMsg) => MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
