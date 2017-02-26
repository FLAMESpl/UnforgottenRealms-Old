namespace UnforgottenRealms.Game.Objects
{
    public class MovementAvailibility
    {
        public int Cost { get; }
        public MovementType Type { get; }

        public MovementAvailibility(int cost, MovementType type)
        {
            Cost = cost;
            Type = type;
        }
    }
}
