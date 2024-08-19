namespace MusicFind
{
    partial class settingsWindow
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.indexFile = new System.Windows.Forms.TextBox();
			this.indexFileHelpLabel = new System.Windows.Forms.Label();
			this.directoriesToIndex = new System.Windows.Forms.DataGridView();
			this.reindexingDefault = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dir = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.deleteButton = new System.Windows.Forms.DataGridViewButtonColumn();
			this.directoriesToIndexHelpLabel = new System.Windows.Forms.Label();
			this.saveButton = new System.Windows.Forms.Button();
			this.browseButton = new System.Windows.Forms.Button();
			this.versionInfo = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.directoriesToIndex)).BeginInit();
			this.SuspendLayout();
			// 
			// indexFile
			// 
			this.indexFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.indexFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.indexFile.Location = new System.Drawing.Point(10, 37);
			this.indexFile.Name = "indexFile";
			this.indexFile.Size = new System.Drawing.Size(405, 20);
			this.indexFile.TabIndex = 0;
			this.indexFile.TextChanged += new System.EventHandler(this.indexFile_TextChanged);
			// 
			// indexFileHelpLabel
			// 
			this.indexFileHelpLabel.AutoSize = true;
			this.indexFileHelpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.indexFileHelpLabel.Location = new System.Drawing.Point(12, 21);
			this.indexFileHelpLabel.Name = "indexFileHelpLabel";
			this.indexFileHelpLabel.Size = new System.Drawing.Size(225, 13);
			this.indexFileHelpLabel.TabIndex = 1;
			this.indexFileHelpLabel.Text = "Index file (will be overwritten when reindexing):";
			// 
			// directoriesToIndex
			// 
			this.directoriesToIndex.AllowUserToResizeColumns = false;
			this.directoriesToIndex.AllowUserToResizeRows = false;
			this.directoriesToIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.directoriesToIndex.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			this.directoriesToIndex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.directoriesToIndex.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.reindexingDefault,
            this.dir,
            this.deleteButton});
			this.directoriesToIndex.Cursor = System.Windows.Forms.Cursors.Default;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.directoriesToIndex.DefaultCellStyle = dataGridViewCellStyle1;
			this.directoriesToIndex.Location = new System.Drawing.Point(11, 93);
			this.directoriesToIndex.Name = "directoriesToIndex";
			this.directoriesToIndex.RowHeadersVisible = false;
			this.directoriesToIndex.RowHeadersWidth = 4;
			this.directoriesToIndex.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.directoriesToIndex.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.directoriesToIndex.Size = new System.Drawing.Size(495, 283);
			this.directoriesToIndex.TabIndex = 2;
			this.directoriesToIndex.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.directoriesToIndex_CellContentClick);
			// 
			// reindexingDefault
			// 
			this.reindexingDefault.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.reindexingDefault.HeaderText = " ";
			this.reindexingDefault.MinimumWidth = 20;
			this.reindexingDefault.Name = "reindexingDefault";
			this.reindexingDefault.Width = 20;
			// 
			// dir
			// 
			this.dir.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dir.HeaderText = "Directory";
			this.dir.Name = "dir";
			// 
			// deleteButton
			// 
			this.deleteButton.HeaderText = "";
			this.deleteButton.Name = "deleteButton";
			this.deleteButton.ReadOnly = true;
			this.deleteButton.Text = "Delete";
			this.deleteButton.UseColumnTextForButtonValue = true;
			this.deleteButton.Width = 80;
			// 
			// directoriesToIndexHelpLabel
			// 
			this.directoriesToIndexHelpLabel.AutoSize = true;
			this.directoriesToIndexHelpLabel.Location = new System.Drawing.Point(15, 77);
			this.directoriesToIndexHelpLabel.Name = "directoriesToIndexHelpLabel";
			this.directoriesToIndexHelpLabel.Size = new System.Drawing.Size(338, 13);
			this.directoriesToIndexHelpLabel.TabIndex = 3;
			this.directoriesToIndexHelpLabel.Text = "Directories to index (check box to include as default reindexing target):";
			// 
			// saveButton
			// 
			this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.saveButton.Location = new System.Drawing.Point(426, 382);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(80, 25);
			this.saveButton.TabIndex = 4;
			this.saveButton.Text = "&Save";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// browseButton
			// 
			this.browseButton.Location = new System.Drawing.Point(426, 34);
			this.browseButton.Name = "browseButton";
			this.browseButton.Size = new System.Drawing.Size(80, 25);
			this.browseButton.TabIndex = 5;
			this.browseButton.Text = "&Browse";
			this.browseButton.UseVisualStyleBackColor = true;
			this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
			// 
			// versionInfo
			// 
			this.versionInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.versionInfo.AutoSize = true;
			this.versionInfo.Location = new System.Drawing.Point(8, 388);
			this.versionInfo.Name = "versionInfo";
			this.versionInfo.Size = new System.Drawing.Size(42, 13);
			this.versionInfo.TabIndex = 6;
			this.versionInfo.Text = "Version";
			this.versionInfo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// settingsWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(519, 419);
			this.Controls.Add(this.versionInfo);
			this.Controls.Add(this.browseButton);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.directoriesToIndexHelpLabel);
			this.Controls.Add(this.directoriesToIndex);
			this.Controls.Add(this.indexFileHelpLabel);
			this.Controls.Add(this.indexFile);
			this.Name = "settingsWindow";
			this.Text = "MusicFind - Settings";
			this.TopMost = true;
			((System.ComponentModel.ISupportInitialize)(this.directoriesToIndex)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox indexFile;
        private System.Windows.Forms.Label indexFileHelpLabel;
		private System.Windows.Forms.DataGridView directoriesToIndex;
        private System.Windows.Forms.Label directoriesToIndexHelpLabel;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.Button browseButton;
		private System.Windows.Forms.DataGridViewCheckBoxColumn reindexingDefault;
		private System.Windows.Forms.DataGridViewTextBoxColumn dir;
		private System.Windows.Forms.DataGridViewButtonColumn deleteButton;
		private System.Windows.Forms.Label versionInfo;
    }
}