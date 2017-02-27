﻿using SFML.Graphics;
using SFML.Window;
using System.Collections.Generic;
using UnforgottenRealms.Common.Resources;
using UnforgottenRealms.Common.Window;
using UnforgottenRealms.Game.Graphics;
using UnforgottenRealms.Game.Objects.Abilities;
using UnforgottenRealms.Gui.Components.ShapeBased;
using Button = UnforgottenRealms.Gui.Components.ImageBased.Button;

namespace UnforgottenRealms.Game.Gui.Components
{
    public class AbilitiesContainer : Frame
    {
        private AbilitiesTileset tileset;
        private Vector2f borderMargin = new Vector2f(24, 24);
        private float buttonsMargin = 12;
        private float buttonHeight = 64;

        public AbilitiesContainer(ResourceManager resources, GameWindow window)
        {
            tileset = resources.Get<GameTilesets>().Abilities;
            Position = new Vector2f(0, window.Size.Y - borderMargin.Y - buttonHeight);
        }

        public void Set(IEnumerable<Ability> abilities)
        {
            var i = 0;
            var left = borderMargin.X;
            foreach (var ability in abilities)
            {
                i++;
                var button = new Button
                {
                    HighlightEnabled = ability.Type != AbilityType.Passive,
                    HighlightColor = new Color(200, 200, 155, 255),
                    Image = new Sprite
                    {
                        Texture = tileset.Texture,
                        TextureRect = ability.Tile.Bounds
                    },
                    Position = new Vector2f(left, 0)
                };
                left += buttonsMargin;
                Components.Add(button);
            }
        }
    }
}
