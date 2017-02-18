﻿using UnforgottenRealms.Common.Resources;
using UnforgottenRealms.Game.Graphics;
using UnforgottenRealms.Game.World.Coordinates;
using UnforgottenRealms.Game.World.Geometry;

namespace UnforgottenRealms.Game.World.Terrain
{
    public class Water : AbstractTerrain
    {
        public Water(OffsetCoordinates position, HexModel model, ResourceManager resources) :
            base(
                model: model,
                movementCost: 1,
                position: position,
                textureDescriptor: resources.Get<GameTilesets>().Terrain.Water,
                type: TerrainType.Water
            )
        {
        }
    }
}
