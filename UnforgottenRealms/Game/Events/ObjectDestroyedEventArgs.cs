using System;
using UnforgottenRealms.Game.Objects;
using UnforgottenRealms.Game.World;

namespace UnforgottenRealms.Game.Events
{
    public class ObjectDestroyedEventArgs : EventArgs
    {
        public Field Location { get; private set; }
        public GameObject Object { get; private set; }

        public ObjectDestroyedEventArgs(Field location, GameObject @object)
        {
            Location = location;
            Object = @object;
        }
    }
}
