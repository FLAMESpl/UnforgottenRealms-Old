using System.Collections.Generic;
using System.Linq;
using UnforgottenRealms.Common.Utils;

namespace UnforgottenRealms.Game.Gui.ContextPreview
{
    public class ContextInfoContent
    {
        public IEnumerable<ContextInfoLine> Lines { get; set; }

        public ContextInfoContent(IEnumerable<ContextInfoLine> lines)
        {
            Lines = lines;
        }

        public static IEnumerable<ContextInfoContent> Merge (params IEnumerable<ContextInfoContent>[] contextInfoContents)
        {
            yield return new ContextInfoContent(
                EnumerableExtensions.Stream(
                    contextInfoContents.SelectMany(
                        s => s?.SelectMany(
                            c => c?.Lines
                        )
                    )
                )
            );
        }
    }
}
