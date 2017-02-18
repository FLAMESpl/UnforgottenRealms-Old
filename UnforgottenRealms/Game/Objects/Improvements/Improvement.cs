using SFML.Graphics;
using SFML.Window;
using UnforgottenRealms.Common.Utils;
using UnforgottenRealms.Game.Graphics;
using UnforgottenRealms.Game.Players;
using UnforgottenRealms.Game.World;
using UnforgottenRealms.Game.World.Coordinates;
using UnforgottenRealms.Game.World.Geometry;

namespace UnforgottenRealms.Game.Objects.Improvements
{
    public delegate Improvement ImprovementFactory(Field location, Player owner);

    public class Improvement : GameObject
    {
        private Sprite improvementSprite;
        private Sprite flagSprite;

        public Improvement(Field location, TextureDescriptor improvementTexture, Player owner) : base(
            location: location,
            owner: owner)
        {
            var model = location.World.Model;
            var flagTexture = location.World.Resources.Get<GameTilesets>().Miscellaneous.Flag;

            improvementSprite = new Sprite
            {
                Position = model.GetTopLeftCorner(location.Position),
                Scale = improvementTexture.Scale(model.Size),
                Texture = improvementTexture.Texture,
                TextureRect = improvementTexture.Bounds
            };

            flagSprite = new Sprite
            {
                Color = owner.Colour.ToRGB(),
                Position = model.GetTopLeftCorner(location.Position) + FlagOffset(model),
                Scale = flagTexture.Scale(model.Size),
                Texture = flagTexture.Texture,
                TextureRect = flagTexture.Bounds
            };
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(flagSprite, states);
            target.Draw(improvementSprite, states);
        }

        public override void PerformPrimaryAction(AxialCoordinates targetPosition)
        {
        }

        public override void Select(bool isSelected)
        {
        }

        protected virtual Vector2f FlagOffset(HexModel model) => new Vector2f(0, -model.VerticalSize / 2);
    }
}
