using SFML.Graphics;
using UnforgottenRealms.Common.Resources;
using UnforgottenRealms.Game.Players;
using UnforgottenRealms.Game.World;
using UnforgottenRealms.Game.World.Coordinates;
using UnforgottenRealms.Game.World.Geometry;

namespace UnforgottenRealms.Game.Objects.Improvements
{
    public delegate Improvement ImprovementFactory(Field location, HexModel model, ResourceManager resources, Player owner);

    public class Improvement : GameObject
    {
        public Improvement(Field location, HexModel hex, Player owner) : base(
            location: location,
            hexModel: hex,
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
