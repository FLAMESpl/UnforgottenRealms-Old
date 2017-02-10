using System;

namespace UnforgottenRealms.Gui.Schemas
{
    public class FromSchema : Attribute
    {
        public string Property { get; set; }

        public FromSchema(string property)
        {
            Property = property;
        }
    }
}
