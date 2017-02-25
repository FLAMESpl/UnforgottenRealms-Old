using SFML.Graphics;
using SFML.Window;
using System;
using System.Threading;
using UnforgottenRealms.Common.Resources;
using UnforgottenRealms.Common.Window;
using UnforgottenRealms.Game.World;
using UnforgottenRealms.Gui.Components.Container;
using UnforgottenRealms.Game.Gui.ContextPreview;
using UnforgottenRealms.Game.Gui;
using UnforgottenRealms.Common.Geometry;

namespace UnforgottenRealms.Game.Views
{
    public class GuiView : Drawable
    {
        private ContextInfo contextInfo;
        private HexModel model;
        private PageControl pageControl;
        private View view;
        private Map world;
        private WorldView worldView;

        private bool contextInfoUpdateLock = false;

        public GuiView(GameWindow window, ResourceManager resources, Map world, WorldView worldView)
        {
            this.contextInfo = new ContextInfo(new Vector2f(window.Size.X - 400, window.Size.Y - 50), 350);
            this.model = world.Model;
            this.pageControl = new PageControl();
            this.view = new View(window.DefaultView);
            this.world = world;
            this.worldView = worldView;
            
            pageControl.InitializeComponents(window, resources, world.TurnCycle);
            window.MouseMoved += MouseMoved;
        }

        private void MouseMoved(object sender, MouseMoveEventArgs e)
        {
            if (!contextInfoUpdateLock)
            {
                contextInfoUpdateLock = true;
                Action<Vector2f> action = UpdateContextInfo;
                action.BeginInvoke(new Vector2f(e.X, e.Y), null, null);
            }
        }

        private void UpdateContextInfo(Vector2f mouseAbsolutePosition)
        {
            var mousePosition = worldView.MapMousePosition(mouseAbsolutePosition);
            var position = model.FindHex(mousePosition);
            if (world.Contains(position))
            {
                var contextInfoContent = world[position].GetContextInfoContent();
                contextInfo.SetContent(contextInfoContent);
            }
            Thread.Sleep(100);
            contextInfoUpdateLock = false;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.SetView(view);
            target.Draw(pageControl.Active, states);
            if (contextInfo.HasContent)
                target.Draw(contextInfo, states);
        }
    }
}
