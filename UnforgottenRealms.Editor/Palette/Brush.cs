using UnforgottenRealms.Editor.Level;

namespace UnforgottenRealms.Editor.Palette
{
    public abstract class Brush
    {
        public IEntityMetadata EntityMetadata { get; }

        public Brush(IEntityMetadata entityMetadata)
        {
            EntityMetadata = entityMetadata;
        }

        public abstract void Paint(Field field);
    }
}
