using System;

namespace UnforgottenRealms.Game.Events
{
    public class ValueChangedEventArgs<T> : EventArgs
    {
        public T New { get; private set; }
        public T Old { get; private set; }

        public ValueChangedEventArgs(T newValue, T oldValue)
        {
            New = newValue;
            Old = oldValue;
        }
    }
}
