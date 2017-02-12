using UnforgottenRealms.Settings;

namespace UnforgottenRealms.Controllers
{
    public abstract class Controller
    {
        public abstract ControllerResult Start(ControllerSettings settings);
    }
}
