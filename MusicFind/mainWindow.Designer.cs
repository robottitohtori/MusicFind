namespace MusicFind
{
    partial class mainWindow
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
			this.searchBox = new System.Windows.Forms.TextBox();
			this.searchButton = new System.Windows.Forms.Button();
			this.foundGrid = new System.Windows.Forms.DataGridView();
			this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.masterDir = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dir = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.file = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.opt_d = new System.Windows.Forms.CheckBox();
			this.opt_f = new System.Windows.Forms.CheckBox();
			this.launchButton = new System.Windows.Forms.Button();
			this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripSettings = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripIndexInfo = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripReindex = new System.Windows.Forms.ToolStripStatusLabel();
			((System.ComponentModel.ISupportInitialize)(this.foundGrid)).BeginInit();
			this.mainStatusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// searchBox
			// 
			this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.searchBox.Location = new System.Drawing.Point(12, 565);
			this.searchBox.Name = "searchBox";
			this.searchBox.Size = new System.Drawing.Size(748, 20);
			this.searchBox.TabIndex = 10;
			// 
			// searchButton
			// 
			this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.searchButton.Location = new System.Drawing.Point(769, 561);
			this.searchButton.Name = "searchButton";
			this.searchButton.Size = new System.Drawing.Size(80, 25);
			this.searchButton.TabIndex = 15;
			this.searchButton.TabStop = false;
			this.searchButton.Text = "Search";
			this.searchButton.UseVisualStyleBackColor = true;
			this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
			// 
			// foundGrid
			// 
			this.foundGrid.AllowUserToAddRows = false;
			this.foundGrid.AllowUserToDeleteRows = false;
			this.foundGrid.AllowUserToOrderColumns = true;
			this.foundGrid.AllowUserToResizeRows = false;
			this.foundGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.foundGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.foundGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.num,
            this.masterDir,
            this.dir,
            this.file});
			this.foundGrid.Location = new System.Drawing.Point(12, 12);
			this.foundGrid.Name = "foundGrid";
			this.foundGrid.ReadOnly = true;
			this.foundGrid.RowHeadersVisible = false;
			this.foundGrid.RowHeadersWidth = 4;
			this.foundGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.foundGrid.Size = new System.Drawing.Size(836, 512);
			this.foundGrid.StandardTab = true;
			this.foundGrid.TabIndex = 18;
			this.foundGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.foundGrid_CellClick);
			// 
			// num
			// 
			this.num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.num.HeaderText = "#";
			this.num.Name = "num";
			this.num.ReadOnly = true;
			this.num.Width = 30;
			// 
			// masterDir
			// 
			this.masterDir.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.masterDir.FillWeight = 1F;
			this.masterDir.HeaderText = "Master dir";
			this.masterDir.Name = "masterDir";
			this.masterDir.ReadOnly = true;
			this.masterDir.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.masterDir.Visible = false;
			// 
			// dir
			// 
			this.dir.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dir.HeaderText = "Dir";
			this.dir.Name = "dir";
			this.dir.ReadOnly = true;
			// 
			// file
			// 
			this.file.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.file.HeaderText = "File";
			this.file.Name = "file";
			this.file.ReadOnly = true;
			// 
			// opt_d
			// 
			this.opt_d.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.opt_d.AutoSize = true;
			this.opt_d.Checked = true;
			this.opt_d.CheckState = System.Windows.Forms.CheckState.Checked;
			this.opt_d.Location = new System.Drawing.Point(12, 537);
			this.opt_d.Name = "opt_d";
			this.opt_d.Size = new System.Drawing.Size(39, 17);
			this.opt_d.TabIndex = 5;
			this.opt_d.TabStop = false;
			this.opt_d.Text = "&Dir";
			this.opt_d.UseVisualStyleBackColor = true;
			// 
			// opt_f
			// 
			this.opt_f.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.opt_f.AutoSize = true;
			this.opt_f.Checked = true;
			this.opt_f.CheckState = System.Windows.Forms.CheckState.Checked;
			this.opt_f.Location = new System.Drawing.Point(57, 537);
			this.opt_f.Name = "opt_f";
			this.opt_f.Size = new System.Drawing.Size(42, 17);
			this.opt_f.TabIndex = 6;
			this.opt_f.TabStop = false;
			this.opt_f.Text = "&File";
			this.opt_f.UseVisualStyleBackColor = true;
			// 
			// launchButton
			// 
			this.launchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.launchButton.Location = new System.Drawing.Point(769, 530);
			this.launchButton.Name = "launchButton";
			this.launchButton.Size = new System.Drawing.Size(80, 25);
			this.launchButton.TabIndex = 20;
			this.launchButton.TabStop = false;
			this.launchButton.Text = "Launch";
			this.launchButton.UseVisualStyleBackColor = true;
			this.launchButton.Click += new System.EventHandler(this.launchButton_Click);
			// 
			// mainStatusStrip
			// 
			this.mainStatusStrip.AutoSize = false;
			this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSettings,
            this.toolStripIndexInfo,
            this.toolStripReindex});
			this.mainStatusStrip.Location = new System.Drawing.Point(0, 599);
			this.mainStatusStrip.Name = "mainStatusStrip";
			this.mainStatusStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.mainStatusStrip.Size = new System.Drawing.Size(861, 22);
			this.mainStatusStrip.TabIndex = 21;
			this.mainStatusStrip.Text = "statusStrip1";
			// 
			// toolStripSettings
			// 
			this.toolStripSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.toolStripSettings.IsLink = true;
			this.toolStripSettings.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
			this.toolStripSettings.Name = "toolStripSettings";
			this.toolStripSettings.Size = new System.Drawing.Size(50, 17);
			this.toolStripSettings.Text = "Settings";
			this.toolStripSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// toolStripIndexInfo
			// 
			this.toolStripIndexInfo.Name = "toolStripIndexInfo";
			this.toolStripIndexInfo.Size = new System.Drawing.Size(639, 17);
			this.toolStripIndexInfo.Spring = true;
			this.toolStripIndexInfo.Text = "toolStripIndexInfo";
			// 
			// toolStripReindex
			// 
			this.toolStripReindex.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripReindex.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.toolStripReindex.IsLink = true;
			this.toolStripReindex.Name = "toolStripReindex";
			this.toolStripReindex.Size = new System.Drawing.Size(49, 17);
			this.toolStripReindex.Text = "Reindex";
			this.toolStripReindex.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(861, 621);
			this.Controls.Add(this.mainStatusStrip);
			this.Controls.Add(this.launchButton);
			this.Controls.Add(this.opt_f);
			this.Controls.Add(this.opt_d);
			this.Controls.Add(this.foundGrid);
			this.Controls.Add(this.searchButton);
			this.Controls.Add(this.searchBox);
			this.Name = "mainWindow";
			this.Text = "MusicFind";
			this.Load += new System.EventHandler(this.mainWindow_Load);
			((System.ComponentModel.ISupportInitialize)(this.foundGrid)).EndInit();
			this.mainStatusStrip.ResumeLayout(false);
			this.mainStatusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.DataGridView foundGrid;
        private System.Windows.Forms.CheckBox opt_d;
        private System.Windows.Forms.CheckBox opt_f;
		private System.Windows.Forms.Button launchButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn masterDir;
        private System.Windows.Forms.DataGridViewTextBoxColumn dir;
		private System.Windows.Forms.DataGridViewTextBoxColumn file;
		private System.Windows.Forms.StatusStrip mainStatusStrip;
		private System.Windows.Forms.ToolStripStatusLabel toolStripSettings;
		private System.Windows.Forms.ToolStripStatusLabel toolStripIndexInfo;
		private System.Windows.Forms.ToolStripStatusLabel toolStripReindex;
    }
}

