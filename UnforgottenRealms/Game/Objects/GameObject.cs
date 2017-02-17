using SFML.Graphics;
using UnforgottenRealms.Game.Players;
using UnforgottenRealms.Game.World.Coordinates;
using UnforgottenRealms.Gui.ContextPreview;

namespace UnforgottenRealms.Game.Objects
{
    public abstract class GameObject : Drawable, IContextPreviewProvider
    {
        public AxialCoordinates Position { get; protected set; }
        public Player Owner { get; protected set; }

        public GameObject(AxialCoordinates position, Player owner)
        {
            Position = position;
            Owner = owner;
        }

        public abstract void Draw(RenderTarget target, RenderStates states);
        public abstract void Select(bool isSelected);
    }
}
