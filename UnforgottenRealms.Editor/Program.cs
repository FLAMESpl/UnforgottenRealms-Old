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
            form.InitializeSfml();
            form.Show();

            while (form.Visible)
            {
                Application.DoEvents();
                form.Process();
            }
        }
    }
}
