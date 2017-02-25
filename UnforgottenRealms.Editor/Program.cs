using SFML.Graphics;
using System;
using System.Windows.Forms;

namespace UnforgottenRealms.Editor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var form = new Forms.Main();
            var renderwindow = form.InitializeSfml();
            var clearColor = new Color(50, 50, 200);

            form.Show();
            
            while (form.Visible) 
            {
                Application.DoEvents(); 
                renderwindow.DispatchEvents(); 
                renderwindow.Clear(clearColor);
                renderwindow.Draw(form);
                renderwindow.Display();
            }
        }
    }
}
