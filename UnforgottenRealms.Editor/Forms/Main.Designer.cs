namespace UnforgottenRealms.Editor.Forms
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.drawingSurface = new UnforgottenRealms.Editor.Controls.DrawingSurface(this.components);
            this.palette = new UnforgottenRealms.Editor.Controls.Palette();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.worldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolTerrain = new System.Windows.Forms.ToolStripButton();
            this.toolDeposits = new System.Windows.Forms.ToolStripButton();
            this.toolUnits = new System.Windows.Forms.ToolStripButton();
            this.toolImprovements = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.imagesTerrainPalette = new System.Windows.Forms.ImageList(this.components);
            this.tableLayout.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayout
            // 
            this.tableLayout.ColumnCount = 2;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout.Controls.Add(this.drawingSurface, 1, 0);
            this.tableLayout.Controls.Add(this.palette, 0, 0);
            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout.Location = new System.Drawing.Point(0, 49);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.RowCount = 1;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout.Size = new System.Drawing.Size(449, 251);
            this.tableLayout.TabIndex = 0;
            // 
            // drawingSurface
            // 
            this.drawingSurface.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingSurface.Location = new System.Drawing.Point(142, 3);
            this.drawingSurface.Name = "drawingSurface";
            this.drawingSurface.Size = new System.Drawing.Size(304, 245);
            this.drawingSurface.TabIndex = 2;
            this.drawingSurface.Text = "drawingSurface";
            // 
            // palette
            // 
            this.palette.BrushesMargin = new System.Drawing.Size(6, 6);
            this.palette.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palette.Location = new System.Drawing.Point(3, 3);
            this.palette.Name = "palette";
            this.palette.Size = new System.Drawing.Size(133, 245);
            this.palette.TabIndex = 3;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.propertiesToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(449, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.worldToolStripMenuItem,
            this.playersToolStripMenuItem});
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.propertiesToolStripMenuItem.Text = "Properties";
            // 
            // worldToolStripMenuItem
            // 
            this.worldToolStripMenuItem.Name = "worldToolStripMenuItem";
            this.worldToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.worldToolStripMenuItem.Text = "World";
            this.worldToolStripMenuItem.Click += new System.EventHandler(this.worldToolStripMenuItem_Click);
            // 
            // playersToolStripMenuItem
            // 
            this.playersToolStripMenuItem.Name = "playersToolStripMenuItem";
            this.playersToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.playersToolStripMenuItem.Text = "Players";
            this.playersToolStripMenuItem.Click += new System.EventHandler(this.playersToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolTerrain,
            this.toolDeposits,
            this.toolUnits,
            this.toolImprovements,
            this.toolStripSeparator1});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(449, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolTerrain
            // 
            this.toolTerrain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolTerrain.Image = ((System.Drawing.Image)(resources.GetObject("toolTerrain.Image")));
            this.toolTerrain.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolTerrain.Name = "toolTerrain";
            this.toolTerrain.Size = new System.Drawing.Size(23, 22);
            this.toolTerrain.Text = "toolTerrain";
            this.toolTerrain.Click += new System.EventHandler(this.toolTerrain_Click);
            // 
            // toolDeposits
            // 
            this.toolDeposits.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDeposits.Image = ((System.Drawing.Image)(resources.GetObject("toolDeposits.Image")));
            this.toolDeposits.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDeposits.Name = "toolDeposits";
            this.toolDeposits.Size = new System.Drawing.Size(23, 22);
            this.toolDeposits.Text = "toolStripButton4";
            // 
            // toolUnits
            // 
            this.toolUnits.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolUnits.Image = ((System.Drawing.Image)(resources.GetObject("toolUnits.Image")));
            this.toolUnits.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolUnits.Name = "toolUnits";
            this.toolUnits.Size = new System.Drawing.Size(23, 22);
            this.toolUnits.Text = "toolStripButton2";
            // 
            // toolImprovements
            // 
            this.toolImprovements.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolImprovements.Image = ((System.Drawing.Image)(resources.GetObject("toolImprovements.Image")));
            this.toolImprovements.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolImprovements.Name = "toolImprovements";
            this.toolImprovements.Size = new System.Drawing.Size(23, 22);
            this.toolImprovements.Text = "toolStripButton3";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // imagesTerrainPalette
            // 
            this.imagesTerrainPalette.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagesTerrainPalette.ImageStream")));
            this.imagesTerrainPalette.TransparentColor = System.Drawing.Color.Transparent;
            this.imagesTerrainPalette.Images.SetKeyName(0, "none.png");
            this.imagesTerrainPalette.Images.SetKeyName(1, "grass.png");
            this.imagesTerrainPalette.Images.SetKeyName(2, "desert.png");
            this.imagesTerrainPalette.Images.SetKeyName(3, "water.png");
            this.imagesTerrainPalette.Images.SetKeyName(4, "mountain.png");
            this.imagesTerrainPalette.Images.SetKeyName(5, "hill.png");
            this.imagesTerrainPalette.Images.SetKeyName(6, "forest.png");
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 300);
            this.Controls.Add(this.tableLayout);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Main";
            this.Text = "Main";
            this.tableLayout.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem worldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playersToolStripMenuItem;
        private Controls.DrawingSurface drawingSurface;
        private Controls.Palette palette;
        private System.Windows.Forms.ToolStripButton toolTerrain;
        private System.Windows.Forms.ToolStripButton toolDeposits;
        private System.Windows.Forms.ToolStripButton toolUnits;
        private System.Windows.Forms.ToolStripButton toolImprovements;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ImageList imagesTerrainPalette;
    }
}