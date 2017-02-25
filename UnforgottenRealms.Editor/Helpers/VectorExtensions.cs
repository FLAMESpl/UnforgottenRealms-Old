using SFML.Window;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnforgottenRealms.Editor.Helpers
{
    public static class VectorExtensions
    {
        public static Vector2f ToFloatVector(this Point point) => new Vector2f(point.X, point.Y);
    }
}
