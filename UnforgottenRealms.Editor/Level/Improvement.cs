using System;
using SFML.Graphics;
using UnforgottenRealms.Common.Definitions.Entity;

namespace UnforgottenRealms.Editor.Level
{
    public delegate Improvement ImprovementFactory(Field location, int ownerId);

    public class Improvement : IImprovement, Drawable
    {
        public void Draw(RenderTarget target, RenderStates states)
        {
            throw new NotImplementedException();
        }
    }
}
