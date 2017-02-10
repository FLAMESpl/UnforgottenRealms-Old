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
            var controller = new MainMenuController();
            controller.Start();
        }
    }
}
