using UnforgottenRealms.Common.Definitions.Entity;
using UnforgottenRealms.Game.Events;
using UnforgottenRealms.Game.Graphics;
using UnforgottenRealms.Game.Players;
using UnforgottenRealms.Game.Resources;
using UnforgottenRealms.Game.World;

namespace UnforgottenRealms.Game.Objects.Improvements
{
    public class Farm : Improvement
    {
        public static ImprovementFactory Factory => (location, owner) => new Farm(location, owner);

        public override EntityId Id => ImprovementDefinitions.Farm;
        public override string Name => "FARM";
        public int ProductionRate => 1;

        public Farm(Field location, Player owner) : 
            base(
                improvementTexture: location.World.Resources.Get<GameTilesets>().Improvements.Farm,
                location: location, 
                owner: owner
            )
        {
        }

        protected override void Refresh(object sender, RoundChangedEventArgs e)
        {
            Owner.Resources.Types[ResourceType.Food].Amount += ProductionRate;
        }
    }
}
