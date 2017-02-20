using System.Collections.Generic;
using UnforgottenRealms.Common.Enums;
using UnforgottenRealms.Game.Objects;
using UnforgottenRealms.Game.Resources;

namespace UnforgottenRealms.Game.Players
{
    public class Player
    {
        private List<GameObject> objects = new List<GameObject>();

        public bool Active { get; set; }
        public PlayerColour Colour { get; private set; }
        public string Name { get; private set; }
        public IEnumerable<GameObject> Objects => objects;
        public ResourceSet Resources { get; private set; }

        public Player(PlayerColour colour, string name, ResourceSet resources = null)
        {
            Colour = colour;
            Name = name;
            Resources = resources ?? new ResourceSet(ResourcesExtensions.CreateEach());
        }
    }
}
