using System;
using System.Windows.Forms;

namespace UnforgottenRealms.Editor.Controls
{
    public partial class OkCancelDialog : UserControl
    {
        public event EventHandler Ok;
        public event EventHandler Cancel;

        public OkCancelDialog()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e) => Ok?.Invoke(this, EventArgs.Empty);

        private void buttonCancel_Click(object sender, EventArgs e) => Cancel?.Invoke(this, EventArgs.Empty);
    }
}
