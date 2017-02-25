﻿using SFML.Graphics;
using SFML.Window;

namespace UnforgottenRealms.Common.Graphics
{
    public class TextureDescriptor : ITextureDescriptor
    {
        public IntRect Bounds { get; private set; }
        public Texture Texture { get; private set; }
        public Vector2i TileSize { get; private set; }

        public TextureDescriptor(IntRect bounds, Texture texture, Vector2i tileSize)
        {
            Bounds = bounds;
            Texture = texture;
            TileSize = tileSize;
        }
    }
}