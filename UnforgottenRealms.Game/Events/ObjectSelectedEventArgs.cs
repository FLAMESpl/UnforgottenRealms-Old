using System;
using UnforgottenRealms.Game.Objects;

namespace UnforgottenRealms.Game.Events
{
    public class ObjectSelectedEventArgs : EventArgs
    {
        public GameObject Object { get; }

        public ObjectSelectedEventArgs(GameObject @object)
        {
            Object = @object;
        }
    }
}
