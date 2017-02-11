using System;
using System.IO;
using UnforgottenRealms.Controllers;

namespace UnforgottenRealms
{
    class Program
    {
        static void SetProgramPath()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            Directory.SetCurrentDirectory(path);
        }

        static void Main(string[] args)
        {
            SetProgramPath();

            bool @continue = true;

            while (@continue)
            {
                var menuController = new MainMenuController();
                var result = menuController.Start();

                switch (result)
                {
                    default:
                    case MainMenuResult.Continue:
                        break;
                    case MainMenuResult.Closed:
                        @continue = false;
                        break;
                    case MainMenuResult.GameStarted:

                        new GameController().Start(menuController.GameSettings);
                        break;
                }
            }
        }
    }
}
