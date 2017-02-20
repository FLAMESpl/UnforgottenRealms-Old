using UnforgottenRealms.Game.Graphics;

namespace UnforgottenRealms.Game.World.Deposits
{
    public class Iron : Deposit
    {
        public static DepositFactory Factory => (location) => new Iron(location);

        public override string Name => "IRON ORE";

        public Iron(Field location) :
            base(
                location: location,
                textureDescriptor: location.World.Resources.Get<GameTilesets>().Deposits.Iron)
        {
        }
    }
}
