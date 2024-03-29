﻿using UnforgottenRealms.Editor.Level;
using UnforgottenRealms.Editor.Level.Entities.Metadata;

namespace UnforgottenRealms.Editor.Palette
{
    public class DepositBrush : Brush
    {
        public DepositBrush(DepositMetadata metadata) : base(metadata)
        {
        }

        public override void Paint(Field field) => field.Create((DepositMetadata)EntityMetadata);
    }
}
