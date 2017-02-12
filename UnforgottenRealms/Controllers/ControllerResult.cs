using UnforgottenRealms.Settings;

namespace UnforgottenRealms.Controllers
{
    public class ControllerResult
    {
        public NextController Next { get; set; }
        public ControllerSettings Settings { get; set; }
    }
}
