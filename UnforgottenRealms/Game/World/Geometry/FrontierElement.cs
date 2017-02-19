using System.Collections.Generic;

namespace UnforgottenRealms.Game.World.Geometry
{
    public class FrontierElement
    {
        public int Cost { get; }
        public Field Field { get; }

        public FrontierElement(int cost, Field field)
        {
            Cost = cost;
            Field = field;
        }

        public class Comparer : IComparer<FrontierElement>
        {
            public int Compare(FrontierElement x, FrontierElement y)
            {
                return x.Cost - y.Cost;
            }
        }
    }
}
