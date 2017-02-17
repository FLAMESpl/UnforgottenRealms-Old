using System;
using System.Collections.Generic;
using System.Linq;
using UnforgottenRealms.Game.Events;
using UnforgottenRealms.Game.Players;

namespace UnforgottenRealms.Game
{
    public class TurnCycle
    {
        public event EventHandler<TurnChangedEventArgs> TurnChanged;

        private IEnumerable<Player> players;

        public Player CurrentPlayer { get; private set; }

        public TurnCycle(IEnumerable<Player> players)
        {
            this.players = players;
        }

        public void First()
        {
            CurrentPlayer = players.First();
        }

        public void Next()
        {
            CurrentPlayer = players.SkipWhile(p => p != CurrentPlayer).Skip(1).FirstOrDefault() ?? players.First();
            OnTurnChanged(new TurnChangedEventArgs(CurrentPlayer));
        }

        protected void OnTurnChanged(TurnChangedEventArgs eventArgs) => TurnChanged?.Invoke(this, eventArgs);
    }
}
