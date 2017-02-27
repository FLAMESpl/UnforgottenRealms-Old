using SFML.Graphics;
using System;
using UnforgottenRealms.Common.Definitions.Entity;

namespace UnforgottenRealms.Editor.Level
{
    public delegate Unit UnitFactory(Field location, int ownerId);

    public class Unit : IUnit, Drawable
    {
        public EntityId Id { get; }

        public void Draw(RenderTarget target, RenderStates states)
        {
            throw new NotImplementedException();
        }
    }
}
