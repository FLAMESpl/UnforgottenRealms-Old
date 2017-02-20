using SFML.Graphics;
using System.Collections.Generic;
using UnforgottenRealms.Game.Graphics;
using UnforgottenRealms.Game.Objects;
using UnforgottenRealms.Game.Gui.ContextPreview;

namespace UnforgottenRealms.Game.World.Deposits
{
    public delegate Deposit DepositFactory(Field location);

    public abstract class Deposit : Drawable, IContextInfoSubject
    {
        private Sprite sprite;
        
        public Field Location { get; private set; }
        public abstract string Name { get; }

        public Deposit(Field location, TextureDescriptor textureDescriptor)
        {
            Location = location;

            var model = location.World.Model;
            sprite = new Sprite
            {
                Position = model.GetTopLeftCorner(location.Position),
                Scale = textureDescriptor.Scale(model.Size),
                Texture = textureDescriptor.Texture,
                TextureRect = textureDescriptor.Bounds
            };
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(sprite, states);
        }

        public virtual IEnumerable<ContextInfoContent> GetContextInfoContent()
        {
            yield return new ContextInfoContent(GetContextInfoLines());
        }

        protected virtual IEnumerable<ContextInfoLine> GetContextInfoLines()
        {
            yield return new ContextInfoLine(Color.Black, Name);
        }
    }
}
