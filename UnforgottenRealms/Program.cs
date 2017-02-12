using System;
using System.IO;
using UnforgottenRealms.Controllers;
using UnforgottenRealms.Settings;

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

            var controllerResult = new ControllerResult
            {
                Next = NextController.MainMenu,
                Settings = null
            };

            while (controllerResult.Next != NextController.Exit)
            {
                Controller controller = null;

                switch (controllerResult.Next)
                {
                    default:
                    case NextController.MainMenu:
                        controller = new MainMenuController();
                        break;
                    case NextController.Game:
                        controller = new GameController();
                        break;
                    case NextController.Exit:
                        break;
                }

                controllerResult = controller.Start(controllerResult.Settings);
            }
        }
    }
}
