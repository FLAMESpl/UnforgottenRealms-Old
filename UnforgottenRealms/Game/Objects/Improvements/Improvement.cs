using SFML.Graphics;
using UnforgottenRealms.Game.Players;
using UnforgottenRealms.Game.World;
using UnforgottenRealms.Game.World.Coordinates;
using UnforgottenRealms.Game.World.Geometry;

namespace UnforgottenRealms.Game.Objects.Improvements
{
    public class Improvement : GameObject
    {
        public Improvement(AxialCoordinates position, HexModel hex, Player owner) : base(
            position: position,
            hexModel: hex,
            owner: owner)
        {
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
        }

        public override void PerformPrimaryAction(Map map, AxialCoordinates targetPosition)
        {
        }

        public override void Select(bool isSelected)
        {
        }
    }
}
