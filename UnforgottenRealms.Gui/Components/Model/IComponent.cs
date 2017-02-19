using SFML.Graphics;
using SFML.Window;
using UnforgottenRealms.Gui.Components.Container;

namespace UnforgottenRealms.Gui.Components.Model
{
    public interface IComponent : Drawable
    {
        /// <summary>
        /// Container that holds this component
        /// </summary>
        IComponentContainer Container { get; set; }
        bool HasFocus { get; }
        
        /// <summary>
        /// Container-relative position of component
        /// </summary>
        Vector2f Position { get; set; }
        Vector2f Size { get; }

        void Invalidate();
        void SetFocus(bool focus);
    }
}
