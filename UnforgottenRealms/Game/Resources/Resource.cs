using System;
using UnforgottenRealms.Game.Events;

namespace UnforgottenRealms.Game.Resources
{
    public class Resource
    {
        public event EventHandler<ValueChangedEventArgs<int>> AmountChanged;

        private int amount;

        public int Amount
        {
            get { return amount; }
            set
            {
                var old = amount;
                amount = value;
                OnAmountChange(new ValueChangedEventArgs<int>(value, old));
            }
        }
        public ResourceType Type { get; private set; }

        public Resource(ResourceType type, int amount = 0)
        {
            this.amount = amount;
            Type = type;
        }

        protected void OnAmountChange(ValueChangedEventArgs<int> eventArgs) => AmountChanged?.Invoke(this, eventArgs);
    }
}
