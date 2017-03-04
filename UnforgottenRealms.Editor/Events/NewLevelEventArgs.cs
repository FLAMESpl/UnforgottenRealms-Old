using SFML.Window;
using System;

namespace UnforgottenRealms.Editor.Events
{
    public class NewLevelEventArgs : EventArgs
    {
        public string Name { get; }
        public int NumberOfPlayers { get; }
        public Vector2i Size { get; }

        public NewLevelEventArgs(string name, int numberOfPlayers, Vector2i size)
        {
            Name = name;
            NumberOfPlayers = numberOfPlayers;
            Size = size;
        }
    }
}
