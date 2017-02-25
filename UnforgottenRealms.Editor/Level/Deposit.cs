using System;
using SFML.Graphics;
using UnforgottenRealms.Common.Definitions.Entity;

namespace UnforgottenRealms.Editor.Level
{
    public delegate Deposit DepositFactory(Field location);

    public class Deposit : IDeposit, Drawable
    {
        public void Draw(RenderTarget target, RenderStates states)
        {
            throw new NotImplementedException();
        }
    }
}
