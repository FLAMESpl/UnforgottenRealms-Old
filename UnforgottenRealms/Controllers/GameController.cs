using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnforgottenRealms.Settings;

namespace UnforgottenRealms.Controllers
{
    public class GameController : Controller
    {
        public override ControllerResult Start(ControllerSettings settings)
        {
            var gameSettings = (GameSettings)settings;

            return new ControllerResult
            {
                Next = NextController.MainMenu,
                Settings = null
            };
        }
    }
}
