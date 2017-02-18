using System;
using UnforgottenRealms.Game.Objects;
using UnforgottenRealms.Game.World;

namespace UnforgottenRealms.Game.Events
{
    public class ObjectCreatedEventArgs : EventArgs
    {
        public Field Location { get; private set; }
        public GameObject Object { get; private set; }

        public ObjectCreatedEventArgs(Field location, GameObject @object)
        {
            Location = location;
            Object = @object;
        }
    }
}
