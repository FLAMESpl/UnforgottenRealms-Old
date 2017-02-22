using System.Collections.Generic;

namespace UnforgottenRealms.Common.Definitions.Entity
{
    public interface IField
    {
        IDeposit Deposit { get; }
        IImprovement Improvement { get; }
        ITerrain Terrain { get; }
        IEnumerable<IUnit> Units { get; }

    }
}
