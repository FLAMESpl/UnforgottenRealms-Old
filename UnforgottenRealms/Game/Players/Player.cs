using System.Collections.Generic;
using UnforgottenRealms.Common.Enums;
using UnforgottenRealms.Game.Objects;
using UnforgottenRealms.Game.Resources;

namespace UnforgottenRealms.Game.Players
{
    public class Player
    {
        private List<GameObject> objects = new List<GameObject>();

        public PlayerColour Colour { get; private set; }
        public IEnumerable<GameObject> Objects => objects;
        public ResourceSet Resources { get; private set; }

        public Player(PlayerColour colour, ResourceSet resources = null)
        {
            Colour = colour;
            Resources = resources ?? new ResourceSet(ResourcesExtensions.CreateEach());
        }
    }
}
