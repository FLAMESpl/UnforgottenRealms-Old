using System.Collections.Generic;

namespace UnforgottenRealms.Game.Gui.ContextPreview
{
    public interface IContextInfoSubject
    {
        IEnumerable<ContextInfoContent> GetContextInfoContent();
    }
}
