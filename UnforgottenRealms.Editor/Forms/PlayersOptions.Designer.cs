namespace UnforgottenRealms.Editor.Forms
{
    partial class PlayersOptions
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
            this.tableLayoutPanelNumberOfPlayers = new System.Windows.Forms.TableLayoutPanel();
            this.numberOfPlayersLabel = new System.Windows.Forms.Label();
            this.numberOfPlayersComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.okCancelDialog = new UnforgottenRealms.Editor.Controls.OkCancelDialog();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelNumberOfPlayers.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelNumberOfPlayers, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanel1, 0, 2);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(284, 170);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // tableLayoutPanelNumberOfPlayers
            // 
            this.tableLayoutPanelNumberOfPlayers.ColumnCount = 2;
            this.tableLayoutPanelNumberOfPlayers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelNumberOfPlayers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelNumberOfPlayers.Controls.Add(this.numberOfPlayersLabel, 0, 0);
            this.tableLayoutPanelNumberOfPlayers.Controls.Add(this.numberOfPlayersComboBox, 1, 0);
            this.tableLayoutPanelNumberOfPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelNumberOfPlayers.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelNumberOfPlayers.Name = "tableLayoutPanelNumberOfPlayers";
            this.tableLayoutPanelNumberOfPlayers.RowCount = 1;
            this.tableLayoutPanelNumberOfPlayers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelNumberOfPlayers.Size = new System.Drawing.Size(278, 25);
            this.tableLayoutPanelNumberOfPlayers.TabIndex = 0;
            // 
            // numberOfPlayersLabel
            // 
            this.numberOfPlayersLabel.AutoSize = true;
            this.numberOfPlayersLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numberOfPlayersLabel.Location = new System.Drawing.Point(3, 0);
            this.numberOfPlayersLabel.Name = "numberOfPlayersLabel";
            this.numberOfPlayersLabel.Size = new System.Drawing.Size(133, 25);
            this.numberOfPlayersLabel.TabIndex = 0;
            this.numberOfPlayersLabel.Text = "Players";
            this.numberOfPlayersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numberOfPlayersComboBox
            // 
            this.numberOfPlayersComboBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.numberOfPlayersComboBox.FormattingEnabled = true;
            this.numberOfPlayersComboBox.Location = new System.Drawing.Point(142, 3);
            this.numberOfPlayersComboBox.Name = "numberOfPlayersComboBox";
            this.numberOfPlayersComboBox.Size = new System.Drawing.Size(41, 21);
            this.numberOfPlayersComboBox.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.okCancelDialog, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 130);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(278, 37);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // okCancelDialog
            // 
            this.okCancelDialog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.okCancelDialog.Location = new System.Drawing.Point(131, 3);
            this.okCancelDialog.Name = "okCancelDialog";
            this.okCancelDialog.Size = new System.Drawing.Size(144, 31);
            this.okCancelDialog.TabIndex = 0;
            // 
            // PlayersOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 170);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PlayersOptions";
            this.Text = "Players";
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelNumberOfPlayers.ResumeLayout(false);
            this.tableLayoutPanelNumberOfPlayers.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelNumberOfPlayers;
        private System.Windows.Forms.Label numberOfPlayersLabel;
        private System.Windows.Forms.ComboBox numberOfPlayersComboBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Controls.OkCancelDialog okCancelDialog;
    }
}