using System;

namespace UnforgottenRealms.Game.Events
{
    public class ValueChangedEventArgs<T> : EventArgs
    {
        public T NewValue { get; private set; }
        public T OldValue { get; private set; }

        public ValueChangedEventArgs(T newValue, T oldValue)
        {
            NewValue = newValue;
            OldValue = oldValue;
        }
    }
}
