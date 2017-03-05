using UnforgottenRealms.Common.Definitions.Entity;

namespace UnforgottenRealms.Editor.Level.Entities.Metadata
{
    public interface IEntityMetadata
    {
        bool IsEmpty { get; }
        EntityId EntityId { get; }
    }
}
