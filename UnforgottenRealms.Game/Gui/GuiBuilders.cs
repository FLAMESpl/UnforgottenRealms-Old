using SFML.Graphics;
using SFML.Window;
using UnforgottenRealms.Common.Resources;
using UnforgottenRealms.Common.Window;
using UnforgottenRealms.Game;
using UnforgottenRealms.Game.Graphics;
using UnforgottenRealms.Game.Resources;
using UnforgottenRealms.Game.Gui.Components;
using UnforgottenRealms.Gui.Components.Container;
using UnforgottenRealms.Gui.Components.ImageBased;
using UnforgottenRealms.Gui.Components.ShapeBased;

namespace UnforgottenRealms.Game.Gui
{
    public static class GuiBuilders
    {
        public static void InitializeComponents(this PageControl pageControl, GameWindow window, ResourceManager resources, TurnCycle turnCycle)
        {
            var tileset = resources.Get<GameTilesets>().Gui;
            var mainContainer = new ComponentContainer();
            var topFrame = new Frame
            {
                Shape = new RectangleShape
                {
                    FillColor = Color.White,
                    Size = new Vector2f(window.Size.X, 100)
                },
                Position = new Vector2f()
            };

            mainContainer.Add(topFrame);
            pageControl.Add(mainContainer);
            pageControl.Set(mainContainer);

            var resourcesPicturesStartPosition = new Vector2f(300, 25);

            topFrame.Components.AddResourcePicture(ResourceType.Food, tileset.Food, turnCycle, resourcesPicturesStartPosition, 0);
            topFrame.Components.AddResourcePicture(ResourceType.Wood, tileset.Wood, turnCycle, resourcesPicturesStartPosition, 1);
            topFrame.Components.AddResourcePicture(ResourceType.Iron, tileset.Iron, turnCycle, resourcesPicturesStartPosition, 2);
            topFrame.Components.AddResourcePicture(ResourceType.Gems, tileset.Gems, turnCycle, resourcesPicturesStartPosition, 3);

            var bottomFrameSize = new Vector2f(400, 40);
            var bottomFramePosition = new Vector2f(window.Size.X - bottomFrameSize.X, window.Size.Y - bottomFrameSize.Y);
            var bottomFrame = new Frame
            {
                Shape = new RectangleShape
                {
                    FillColor = Color.White,
                    Size = bottomFrameSize
                },
                Position = bottomFramePosition
            };

            mainContainer.Add(bottomFrame);
            
            var activePlayerLabel = new ActivePlayerLabel(new Vector2f(6, 0), turnCycle);
            var currentRoundLabel = new CurrentRoundLabel(new Vector2f(bottomFrameSize.X - 64, 6), turnCycle);

            bottomFrame.Components.Add(activePlayerLabel);
            bottomFrame.Components.Add(currentRoundLabel);
        }

        private static void AddResourcePicture(this IComponentContainer container, ResourceType resourceType, TextureDescriptor textureDescriptor, TurnCycle turnCycle, Vector2f startPosition, int order)
        {
            var offset = new Vector2f(150, 0) * order;

            var picture = new Picture
            {
                Image = new Sprite
                {
                    Texture = textureDescriptor.Texture,
                    TextureRect = textureDescriptor.Bounds
                },
                Position = startPosition + offset
            };

            var label = new ResourceAmountLabel(
                resourceType: resourceType,
                position: startPosition + new Vector2f(70, 0) + offset,
                turnCycle: turnCycle
            );

            container.Add(picture);
            container.Add(label);
        }
    }
}
