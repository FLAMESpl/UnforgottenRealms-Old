using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnforgottenRealms.Common.Definitions.Entity;
using UnforgottenRealms.Common.Geometry;
using UnforgottenRealms.Common.Graphics;
using UnforgottenRealms.Common.Resources;
using UnforgottenRealms.Editor.Graphics;
using UnforgottenRealms.Editor.Helpers;
using UnforgottenRealms.Editor.Level;
using UnforgottenRealms.Editor.Palette;
using Brush = UnforgottenRealms.Editor.Palette.Brush;

namespace UnforgottenRealms.Editor.Forms
{
    public partial class Main : Form, Drawable
    {
        private PlayersOptions playersOptionDialog = new PlayersOptions();
        private WorldOptions worldOptionsDialog = new WorldOptions();
        private HexModel model = null;
        private ResourceManager resources;
        private Map world;

        private ImageBrushPair[] terrainBrushes = null;

        public Main()
        {
            InitializeComponent();
        }

        public RenderWindow InitializeSfml()
        {
            model = new HexModel(40);
            resources = new ResourceManager();
            world = new Map(model, resources);

            var tilesets = new EditorTilesets();

            world.Create(new Vector2i(10, 10));

            CreateTerrainBrushes(tilesets.Terrain);
            
            return drawingSurface.InitializeSfml();
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(world, states);
        }

        private void worldToolStripMenuItem_Click(object sender, EventArgs e) => worldOptionsDialog.ShowDialog();
        private void playersToolStripMenuItem_Click(object sender, EventArgs e) => playersOptionDialog.ShowDialog();

        private void LoadPaletteContent(ImageList images) => palette.LoadContent(new PaletteContent(terrainBrushes, Probe.Terrain));
        private void toolTerrain_Click(object sender, EventArgs e) => LoadPaletteContent(imagesTerrainPalette);

        private void drawingSurface_Click(object sender, EventArgs e)
        {
            var eventArgs = e as MouseEventArgs;
            var mousePosition = eventArgs.Location.ToFloatVector();

            var position = model.FindHex(mousePosition);
            if (!world.Contains(position))
                return;

            if (eventArgs.Button == MouseButtons.Left)
                palette.PaintField(world[position]);
            else if (eventArgs.Button == MouseButtons.Right)
                palette.PickField(world[position]);
        }

        private void CreateTerrainBrushes(TerrainTileset tileset)
        {
            var images = imagesTerrainPalette.Images;
            terrainBrushes = new ImageBrushPair[images.Count];

            terrainBrushes[0] = new ImageBrushPair(
                brush: new TerrainBrush(TerrainMetadata.Empty),
                image: images[0]
            );

            for (int i = 1; i < images.Count; i++)
            {
                terrainBrushes[i] = new ImageBrushPair(
                    brush: new TerrainBrush(
                        new TerrainMetadata(
                            entityId: new EntityId(
                                @class: EntityClass.Terrain,
                                value: i.ToString()
                            ),
                            textureDescriptor: tileset.Get(i-1)
                        )
                    ),
                    image: images[i]
                );
            }
        } 
    }
}
