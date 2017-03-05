using System.Collections.Generic;
using System.Drawing;
using UnforgottenRealms.Common.Definitions.Entity;
using UnforgottenRealms.Common.Graphics;
using UnforgottenRealms.Editor.Controls;
using UnforgottenRealms.Editor.Level;
using UnforgottenRealms.Editor.Palette;

namespace UnforgottenRealms.Editor.Helpers
{
    public static class BrushesExtensions
    {
        public static void AddDepositBrush(this List<ImageBrushPair> list, Image image, EntityId id, Tile tile)
        {
            list.Add(new ImageBrushPair(
                brush: new DepositBrush(
                    metadata: new DepositMetadata(
                        entityId: id,
                        tile: tile
                    )
                ),
                image: image
            ));
        }

        public static void AddDepositBrush(this List<ImageBrushPair> list, Image image, DepositMetadata metadata)
        {
            list.Add(new ImageBrushPair(
                brush: new DepositBrush(
                    metadata: metadata
                ),
                image: image
            ));
        }

        public static void AddTerrainBrush(this List<ImageBrushPair> list, Image image, EntityId id, TerrainTile tile)
        {
            list.Add(new ImageBrushPair(
                brush: new TerrainBrush(
                    metadata: new TerrainMetadata(
                        entityId: id,
                        textureDescriptor: tile
                    )
                ),
                image: image
            ));
        }

        public static void AddTerrainBrush(this List<ImageBrushPair> list, Image image, TerrainMetadata metadata)
        {
            list.Add(new ImageBrushPair(
                brush: new TerrainBrush(
                    metadata: metadata
                ),
                image: image
            ));
        }

        public static void AddUnitBrush(this List<ImageBrushPair> list, EditorToolBar toolBar, Image image, EntityId id, Tile tile)
        {
            var brush = new UnitBrush(
                metadata: new UnitMetadata(
                    entityId: id,
                    tile: tile,
                    owner: null
            ));

            toolBar.PlayerSelected += (s, e) => brush.ChangePlayer(e.Colour);

            list.Add(new ImageBrushPair(brush, image));
        }

        public static void AddUnitBrush(this List<ImageBrushPair> list, Image image, UnitMetadata metadata)
        {
            list.Add(new ImageBrushPair(
                brush: new UnitBrush(
                    metadata: metadata
                ),
                image: image
            ));
        }
    }
}
