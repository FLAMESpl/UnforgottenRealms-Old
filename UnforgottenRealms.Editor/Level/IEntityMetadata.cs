using UnforgottenRealms.Common.Definitions.Entity;

namespace UnforgottenRealms.Editor.Level
{
    public interface IEntityMetadata
    {
        bool IsEmpty { get; }
        EntityId? EntityId { get; }
    }
}
