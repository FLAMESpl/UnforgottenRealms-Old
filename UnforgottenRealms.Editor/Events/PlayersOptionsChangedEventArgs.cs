using System;

namespace UnforgottenRealms.Editor.Events
{
    public class PlayersOptionsChangedEventArgs : EventArgs
    {
        public int NumberOfPlayers { get; }

        public PlayersOptionsChangedEventArgs(int numberOfPlayers)
        {
            NumberOfPlayers = numberOfPlayers;
        }
    }
}
