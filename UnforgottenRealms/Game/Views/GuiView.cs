using SFML.Graphics;
using UnforgottenRealms.Common.Resources;
using UnforgottenRealms.Common.Window;
using UnforgottenRealms.Gui;
using UnforgottenRealms.Gui.Components.Container;

namespace UnforgottenRealms.Game.Views
{
    public class GuiView : Drawable
    {
        private View view;
        private PageControl pageControl;

        public GuiView(GameWindow window, ResourceManager resources, TurnCycle turnCycle)
        {
            view = new View(window.DefaultView);
            pageControl = new PageControl();
            
            pageControl.InitializeComponents(window, resources, turnCycle);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.SetView(view);
            target.Draw(pageControl.Active, states);
        }
    }
}
