using System;
using System.Collections.Generic;
using System.Linq;
using UnforgottenRealms.Game.Events;
using UnforgottenRealms.Game.Players;

namespace UnforgottenRealms.Game
{
    public class TurnCycle
    {
        public event EventHandler<ValueChangedEventArgs<Player>> TurnChanged;
        public event EventHandler<RoundChangedEventArgs> RoundChanged;

        private IEnumerable<Player> players;

        public Player CurrentPlayer { get; private set; }
        public int Round { get; private set; }

        public void Start(IEnumerable<Player> players)
        {
            this.players = players;
            CurrentPlayer = players.First();
            CurrentPlayer.Active = true;
            Round = 1;
        }

        public void Next()
        {
            var oldPlayer = CurrentPlayer;
            var newPlayer = CurrentPlayer = players.SkipWhile(p => p != CurrentPlayer).Skip(1).FirstOrDefault();

            oldPlayer.Active = false;

            if (newPlayer != null)
            {
                newPlayer.Active = true;
                CurrentPlayer = newPlayer;
            }
            else
            {
                newPlayer = players.First();
                newPlayer.Active = true;
                CurrentPlayer = newPlayer;
                OnRoundChanged(new RoundChangedEventArgs(++Round));
            }

            OnTurnChanged(new ValueChangedEventArgs<Player>(newPlayer, oldPlayer));
        }

        protected void OnTurnChanged(ValueChangedEventArgs<Player> eventArgs) => TurnChanged?.Invoke(this, eventArgs);
        protected void OnRoundChanged(RoundChangedEventArgs eventArgs) => RoundChanged?.Invoke(this, eventArgs);
    }
}
