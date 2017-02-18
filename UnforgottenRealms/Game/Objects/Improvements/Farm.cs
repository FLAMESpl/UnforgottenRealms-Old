using UnforgottenRealms.Game.Graphics;
using UnforgottenRealms.Game.Players;
using UnforgottenRealms.Game.World;

namespace UnforgottenRealms.Game.Objects.Improvements
{
    public class Farm : Improvement
    {
        public static ImprovementFactory Factory => (location, owner) => new Farm(location, owner);

        public Farm(Field location, Player owner) : 
            base(
                improvementTexture: location.World.Resources.Get<GameTilesets>().Improvements.Farm,
                location: location, 
                owner: owner
            )
        {
        }
    }
}
