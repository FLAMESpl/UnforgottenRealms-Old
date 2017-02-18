using SFML.Graphics;
using UnforgottenRealms.Game.Players;
using UnforgottenRealms.Game.World;
using UnforgottenRealms.Game.World.Coordinates;

namespace UnforgottenRealms.Game.Objects.Improvements
{
    public delegate Improvement ImprovementFactory(Field location, Player owner);

    public class Improvement : GameObject
    {
        public Improvement(Field location, Player owner) : base(
            location: location,
            owner: owner)
        {
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
        }

        public override void PerformPrimaryAction(AxialCoordinates targetPosition)
        {
        }

        public override void Select(bool isSelected)
        {
        }
    }
}
