using System.Collections.Generic;

namespace UnforgottenRealms.Gui.ContextPreview
{
    public class ContextInfoContent
    {
        public IEnumerable<ContextInfoLine> Lines { get; set; }

        public ContextInfoContent(IEnumerable<ContextInfoLine> lines)
        {
            Lines = lines;
        }
    }
}
