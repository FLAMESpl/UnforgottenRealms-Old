using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnforgottenRealms.Common.Definitions.Entity;

namespace UnforgottenRealms.Editor.Level
{
    public delegate Unit UnitFactory(Field location, int ownerId);

    public class Unit : IUnit, Drawable
    {
        public void Draw(RenderTarget target, RenderStates states)
        {
            throw new NotImplementedException();
        }
    }
}
