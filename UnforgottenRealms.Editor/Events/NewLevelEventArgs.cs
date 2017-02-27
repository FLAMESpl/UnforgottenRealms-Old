using SFML.Window;
using System;

namespace UnforgottenRealms.Editor.Events
{
    public class NewLevelEventArgs : EventArgs
    {
        public string Name { get; }
        public Vector2i Size { get; }

        public NewLevelEventArgs(string name, Vector2i size)
        {
            Name = name;
            Size = size;
        }
    }
}
