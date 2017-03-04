using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using UnforgottenRealms.Common.Enums;
using UnforgottenRealms.Editor.Helpers;

namespace UnforgottenRealms.Editor.Controls
{
    public partial class PlayerToolButton : ToolStripButton
    {
        public PlayerColour Player { get; set; }

        public PlayerToolButton()
        {
            InitializeComponent();
        }

        public PlayerToolButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void Select(bool isSelected)
        {
            BackColor = isSelected ? Player.ToSystemActiveColor() : Player.ToSystemInactiveColor();
        }

        public void Initialize(PlayerColour colour, Size size, Padding padding)
        {
            Player = colour;
            DisplayStyle = ToolStripItemDisplayStyle.None;
            BackColor = colour.ToSystemInactiveColor();
            Size = size;
            Margin = padding;
            Visible = false;
        }
    }
}
