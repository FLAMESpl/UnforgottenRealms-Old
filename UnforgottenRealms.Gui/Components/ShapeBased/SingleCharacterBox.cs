using UnforgottenRealms.Gui.Components.Events;
using System.Linq;

namespace UnforgottenRealms.Gui.Components.ShapeBased
{
    public class SingleCharacterBox : TextBox
    {
        protected override void TextInput(TextEntered @event)
        {
            if (InputValidator(@event.Text.Unicode.First()))
            {
                Text.DisplayedString = @event.Text.Unicode;
                SetFocus(false);
            }
        }
    }
}
