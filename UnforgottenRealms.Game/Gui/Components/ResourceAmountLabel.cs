using SFML.Graphics;
using SFML.Window;
using UnforgottenRealms.Common.Utils;
using UnforgottenRealms.Game;
using UnforgottenRealms.Game.Events;
using UnforgottenRealms.Game.Players;
using UnforgottenRealms.Game.Resources;
using UnforgottenRealms.Gui.Components.ShapeBased;

namespace UnforgottenRealms.Game.Gui.Components
{
    public class ResourceAmountLabel : Label
    {
        private bool delegateInitialized = false;
        private ResourceType resourceType;

        public ResourceAmountLabel(ResourceType resourceType, Vector2f position, TurnCycle turnCycle)
        {
            this.resourceType = resourceType;

            Text = new Text
            {
                CharacterSize = 24,
                Color = Color.Black,
                Font = FontExtensions.Font
            };

            Position = position;

            turnCycle.TurnChanged += ActivePlayerChanged;
        }

        private void ActivePlayerChanged(object sender, ValueChangedEventArgs<Player> e)
        {
            var resource = e.New.Resources.Types[resourceType];
            Text.DisplayedString = resource.Amount.ToString();
            resource.AmountChanged += ResourceChanged;

            if (delegateInitialized)
                e.Old.Resources.Types[resourceType].AmountChanged -= ResourceChanged;
        }

        private void ResourceChanged(object sender, ValueChangedEventArgs<int> e)
        {
            Text.DisplayedString = e.New.ToString();
        }
    }
}
