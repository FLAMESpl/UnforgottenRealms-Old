using System;
using UnforgottenRealms.Game.Players;

namespace UnforgottenRealms.Game.Events
{
    public class TurnChangedEventArgs : EventArgs
    {
        public Player CurrentPlayer { get; private set; }

        public TurnChangedEventArgs(Player currentPlayer)
        {
            CurrentPlayer = currentPlayer;
        }
    }
}
