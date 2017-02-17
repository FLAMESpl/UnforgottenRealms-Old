using UnforgottenRealms.Settings;

namespace UnforgottenRealms.Game.Players
{
    public static class PlayerExtensions
    {
        public static Player CreatePlayer(this PlayerMetadata playerMetedata)
        {
            return new Player(
                colour: playerMetedata.Colour,
                name: playerMetedata.Name,
                resources: null
            );
        }
    }
}
