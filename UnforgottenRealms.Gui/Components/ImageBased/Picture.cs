using SFML.Graphics;
using SFML.Window;
using UnforgottenRealms.Gui.Components.Container;
using UnforgottenRealms.Gui.Components.Model;

namespace UnforgottenRealms.Gui.Components.ImageBased
{
    public class Picture : IComponent
    {
        private Vector2f position = new Vector2f();

        public IComponentContainer Container { get; set; }
        public Sprite Image { get; set; }
        public bool HasFocus { get; protected set; }
        public Vector2f Position
        {
            get { return position; }
            set
            {
                if (Container != null && Image != null)
                {
                    Image.Position = Container.Position + value;
                }
                position = value;
            }
        }

        public Vector2f Size { get; }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(Image, states);
        }

        public void Invalidate() => Position = position;

        public void SetFocus(bool focus) => Container?.SetFocus(focus ? this : null);
    }
}
