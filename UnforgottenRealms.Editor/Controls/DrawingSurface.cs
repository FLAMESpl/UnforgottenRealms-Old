using SFML.Graphics;
using SFML.Window;
using System.ComponentModel;
using System.Windows.Forms;
using UnforgottenRealms.Common.Window;
using View = SFML.Graphics.View;

namespace UnforgottenRealms.Editor.Controls
{
    public partial class DrawingSurface : Control
    {
        public GameWindow RenderWindow { get; protected set; }

        public DrawingSurface()
        {
            InitializeComponent();
        }

        public DrawingSurface(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public GameWindow InitializeSfml()
        {
            RenderWindow = new GameWindow(Handle);
            return RenderWindow;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
#if DEBUG
            if (DesignMode)
                base.OnPaint(e);
#endif
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
#if DEBUG
            if (DesignMode)
                base.OnPaintBackground(e);
#endif
        }

    }
}
