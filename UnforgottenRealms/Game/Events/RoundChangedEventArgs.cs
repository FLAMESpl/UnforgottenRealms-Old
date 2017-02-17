using System;

namespace UnforgottenRealms.Game.Events
{
    public class RoundChangedEventArgs : EventArgs
    {
        public int Round { get; private set; }

        public RoundChangedEventArgs(int round)
        {
            Round = round;
        }
    }
}
