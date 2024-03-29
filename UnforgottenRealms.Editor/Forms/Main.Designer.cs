﻿namespace UnforgottenRealms.Editor.Forms
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.worldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terrainPaletteImages = new System.Windows.Forms.ImageList(this.components);
            this.depositsPaletteImages = new System.Windows.Forms.ImageList(this.components);
            this.unitsPalleteImages = new System.Windows.Forms.ImageList(this.components);
            this.palette = new UnforgottenRealms.Editor.Controls.Palette();
            this.drawingSurface = new UnforgottenRealms.Editor.Controls.DrawingSurface(this.components);
            this.toolBar = new UnforgottenRealms.Editor.Controls.EditorToolBar(this.components);
            this.improvementsPalleteImages = new System.Windows.Forms.ImageList(this.components);
            this.tableLayout.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayout
            // 
            this.tableLayout.ColumnCount = 2;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout.Controls.Add(this.palette, 0, 0);
            this.tableLayout.Controls.Add(this.drawingSurface, 1, 0);
            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout.Location = new System.Drawing.Point(0, 49);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.RowCount = 1;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout.Size = new System.Drawing.Size(449, 251);
            this.tableLayout.TabIndex = 0;
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
            this.newToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
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
            // terrainPaletteImages
            // 
            this.terrainPaletteImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("terrainPaletteImages.ImageStream")));
            this.terrainPaletteImages.TransparentColor = System.Drawing.Color.Transparent;
            this.terrainPaletteImages.Images.SetKeyName(0, "none");
            this.terrainPaletteImages.Images.SetKeyName(1, "grass");
            this.terrainPaletteImages.Images.SetKeyName(2, "desert");
            this.terrainPaletteImages.Images.SetKeyName(3, "water");
            this.terrainPaletteImages.Images.SetKeyName(4, "mountain");
            this.terrainPaletteImages.Images.SetKeyName(5, "hill");
            this.terrainPaletteImages.Images.SetKeyName(6, "forest");
            // 
            // depositsPaletteImages
            // 
            this.depositsPaletteImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("depositsPaletteImages.ImageStream")));
            this.depositsPaletteImages.TransparentColor = System.Drawing.Color.Transparent;
            this.depositsPaletteImages.Images.SetKeyName(0, "none");
            this.depositsPaletteImages.Images.SetKeyName(1, "iron");
            this.depositsPaletteImages.Images.SetKeyName(2, "gems");
            this.depositsPaletteImages.Images.SetKeyName(3, "pearls");
            // 
            // unitsPalleteImages
            // 
            this.unitsPalleteImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("unitsPalleteImages.ImageStream")));
            this.unitsPalleteImages.TransparentColor = System.Drawing.Color.Transparent;
            this.unitsPalleteImages.Images.SetKeyName(0, "none");
            this.unitsPalleteImages.Images.SetKeyName(1, "archer");
            this.unitsPalleteImages.Images.SetKeyName(2, "swordsman");
            this.unitsPalleteImages.Images.SetKeyName(3, "worker");
            this.unitsPalleteImages.Images.SetKeyName(4, "boat");
            this.unitsPalleteImages.Images.SetKeyName(5, "horseman");
            this.unitsPalleteImages.Images.SetKeyName(6, "dragon");
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
            // drawingSurface
            // 
            this.drawingSurface.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingSurface.Location = new System.Drawing.Point(142, 3);
            this.drawingSurface.Name = "drawingSurface";
            this.drawingSurface.Size = new System.Drawing.Size(304, 245);
            this.drawingSurface.TabIndex = 2;
            this.drawingSurface.Text = "drawingSurface";
            // 
            // toolBar
            // 
            this.toolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolBar.Location = new System.Drawing.Point(0, 24);
            this.toolBar.Name = "toolBar";
            this.toolBar.NumberOfPlayers = 2;
            this.toolBar.Size = new System.Drawing.Size(449, 25);
            this.toolBar.TabIndex = 2;
            this.toolBar.Text = "editorToolBar1";
            // 
            // improvementsPalleteImages
            // 
            this.improvementsPalleteImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("improvementsPalleteImages.ImageStream")));
            this.improvementsPalleteImages.TransparentColor = System.Drawing.Color.Transparent;
            this.improvementsPalleteImages.Images.SetKeyName(0, "none");
            this.improvementsPalleteImages.Images.SetKeyName(1, "barracks");
            this.improvementsPalleteImages.Images.SetKeyName(2, "dragonlair");
            this.improvementsPalleteImages.Images.SetKeyName(3, "farm");
            this.improvementsPalleteImages.Images.SetKeyName(4, "lumberjacks");
            this.improvementsPalleteImages.Images.SetKeyName(5, "mine");
            this.improvementsPalleteImages.Images.SetKeyName(6, "shipyard");
            this.improvementsPalleteImages.Images.SetKeyName(7, "stable");
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 300);
            this.Controls.Add(this.tableLayout);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Main";
            this.Text = "Main";
            this.tableLayout.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem worldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playersToolStripMenuItem;
        private Controls.DrawingSurface drawingSurface;
        private Controls.Palette palette;
        private System.Windows.Forms.ImageList terrainPaletteImages;
        private System.Windows.Forms.ImageList depositsPaletteImages;
        private Controls.EditorToolBar toolBar;
        private System.Windows.Forms.ImageList unitsPalleteImages;
        private System.Windows.Forms.ImageList improvementsPalleteImages;
    }
}