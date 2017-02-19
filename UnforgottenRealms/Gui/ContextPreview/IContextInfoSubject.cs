using System.Collections.Generic;

namespace UnforgottenRealms.Gui.ContextPreview
{
    public interface IContextInfoSubject
    {
        IEnumerable<ContextInfoContent> GetContextInfoContent();
    }
}
