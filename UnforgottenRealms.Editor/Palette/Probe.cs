using System;
using UnforgottenRealms.Common.Definitions.Entity;
using UnforgottenRealms.Editor.Level;

namespace UnforgottenRealms.Editor.Palette
{
    public class Probe
    {
        private Func<Field, EntityId?> selector;

        private Probe(Func<Field, EntityId?> selector)
        {
            this.selector = selector;
        }

        public EntityId? Pick(Field field) => selector.Invoke(field);

        public static Probe Deposit => new Probe(f => f.Deposit?.Metadata.EntityId);
        public static Probe Terrain => new Probe(f => f.Terrain?.Metadata.EntityId);
        public static Probe Unit => new Probe(f => f.Unit?.Metadata.EntityId);
    }
}
