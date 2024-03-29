﻿namespace UnforgottenRealms.Editor.Forms
{
    partial class NewLevel
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
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelButtons = new System.Windows.Forms.TableLayoutPanel();
            this.okCancelDialog = new UnforgottenRealms.Editor.Controls.OkCancelDialog();
            this.tableLayoutPanelSize = new System.Windows.Forms.TableLayoutPanel();
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.playersComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelButtons.SuspendLayout();
            this.tableLayoutPanelSize.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelButtons, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelSize, 0, 0);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(227, 148);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // tableLayoutPanelButtons
            // 
            this.tableLayoutPanelButtons.ColumnCount = 2;
            this.tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 153F));
            this.tableLayoutPanelButtons.Controls.Add(this.okCancelDialog, 1, 0);
            this.tableLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelButtons.Location = new System.Drawing.Point(3, 111);
            this.tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
            this.tableLayoutPanelButtons.RowCount = 1;
            this.tableLayoutPanelButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelButtons.Size = new System.Drawing.Size(221, 34);
            this.tableLayoutPanelButtons.TabIndex = 0;
            // 
            // okCancelDialog
            // 
            this.okCancelDialog.Location = new System.Drawing.Point(71, 3);
            this.okCancelDialog.Name = "okCancelDialog";
            this.okCancelDialog.Size = new System.Drawing.Size(147, 28);
            this.okCancelDialog.TabIndex = 0;
            // 
            // tableLayoutPanelSize
            // 
            this.tableLayoutPanelSize.ColumnCount = 2;
            this.tableLayoutPanelSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanelSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSize.Controls.Add(this.labelHeight, 0, 2);
            this.tableLayoutPanelSize.Controls.Add(this.labelWidth, 0, 1);
            this.tableLayoutPanelSize.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanelSize.Controls.Add(this.nameTextBox, 1, 0);
            this.tableLayoutPanelSize.Controls.Add(this.widthTextBox, 1, 1);
            this.tableLayoutPanelSize.Controls.Add(this.heightTextBox, 1, 2);
            this.tableLayoutPanelSize.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanelSize.Controls.Add(this.playersComboBox, 1, 3);
            this.tableLayoutPanelSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSize.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelSize.Name = "tableLayoutPanelSize";
            this.tableLayoutPanelSize.RowCount = 4;
            this.tableLayoutPanelSize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelSize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanelSize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanelSize.Size = new System.Drawing.Size(221, 102);
            this.tableLayoutPanelSize.TabIndex = 1;
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelHeight.Location = new System.Drawing.Point(3, 49);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(63, 26);
            this.labelHeight.TabIndex = 2;
            this.labelHeight.Text = "Height";
            this.labelHeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelWidth.Location = new System.Drawing.Point(3, 24);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(63, 25);
            this.labelWidth.TabIndex = 0;
            this.labelWidth.Text = "Width";
            this.labelWidth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameTextBox.Location = new System.Drawing.Point(72, 3);
            this.nameTextBox.MaxLength = 30;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(146, 20);
            this.nameTextBox.TabIndex = 5;
            // 
            // widthTextBox
            // 
            this.widthTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.widthTextBox.Location = new System.Drawing.Point(72, 27);
            this.widthTextBox.MaxLength = 2;
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(45, 20);
            this.widthTextBox.TabIndex = 6;
            this.widthTextBox.Text = "10";
            // 
            // heightTextBox
            // 
            this.heightTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.heightTextBox.Location = new System.Drawing.Point(72, 52);
            this.heightTextBox.MaxLength = 2;
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(45, 20);
            this.heightTextBox.TabIndex = 7;
            this.heightTextBox.Text = "10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 27);
            this.label2.TabIndex = 8;
            this.label2.Text = "Players";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // playersComboBox
            // 
            this.playersComboBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.playersComboBox.FormattingEnabled = true;
            this.playersComboBox.Location = new System.Drawing.Point(72, 78);
            this.playersComboBox.Name = "playersComboBox";
            this.playersComboBox.Size = new System.Drawing.Size(45, 21);
            this.playersComboBox.TabIndex = 9;
            // 
            // NewLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 148);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewLevel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NewLevelSize";
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelButtons.ResumeLayout(false);
            this.tableLayoutPanelSize.ResumeLayout(false);
            this.tableLayoutPanelSize.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelButtons;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSize;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox playersComboBox;
        private Controls.OkCancelDialog okCancelDialog;
    }
}