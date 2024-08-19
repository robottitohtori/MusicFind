namespace MusicFind
{
    partial class reindexWindow
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
			this.reindexButton = new System.Windows.Forms.Button();
			this.reindexLocationsList = new System.Windows.Forms.DataGridView();
			this.reindexCheckbox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.reindexLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.indexDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.reindexLocationsList)).BeginInit();
			this.SuspendLayout();
			// 
			// reindexButton
			// 
			this.reindexButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.reindexButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.reindexButton.Location = new System.Drawing.Point(477, 376);
			this.reindexButton.Name = "reindexButton";
			this.reindexButton.Size = new System.Drawing.Size(109, 25);
			this.reindexButton.TabIndex = 1;
			this.reindexButton.Text = "&Reindex selected";
			this.reindexButton.UseVisualStyleBackColor = true;
			this.reindexButton.Click += new System.EventHandler(this.reindexButton_Click);
			// 
			// reindexLocationsList
			// 
			this.reindexLocationsList.AllowUserToAddRows = false;
			this.reindexLocationsList.AllowUserToDeleteRows = false;
			this.reindexLocationsList.AllowUserToResizeColumns = false;
			this.reindexLocationsList.AllowUserToResizeRows = false;
			this.reindexLocationsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.reindexLocationsList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.reindexLocationsList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			this.reindexLocationsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.reindexLocationsList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.reindexCheckbox,
            this.reindexLocation,
            this.indexDate});
			this.reindexLocationsList.Location = new System.Drawing.Point(12, 12);
			this.reindexLocationsList.MultiSelect = false;
			this.reindexLocationsList.Name = "reindexLocationsList";
			this.reindexLocationsList.RowHeadersVisible = false;
			this.reindexLocationsList.Size = new System.Drawing.Size(573, 355);
			this.reindexLocationsList.TabIndex = 3;
			// 
			// reindexCheckbox
			// 
			this.reindexCheckbox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.reindexCheckbox.HeaderText = " ";
			this.reindexCheckbox.MinimumWidth = 20;
			this.reindexCheckbox.Name = "reindexCheckbox";
			this.reindexCheckbox.Width = 20;
			// 
			// reindexLocation
			// 
			this.reindexLocation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.reindexLocation.HeaderText = "Directory";
			this.reindexLocation.Name = "reindexLocation";
			this.reindexLocation.ReadOnly = true;
			// 
			// indexDate
			// 
			this.indexDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.indexDate.HeaderText = "Last indexed";
			this.indexDate.Name = "indexDate";
			this.indexDate.ReadOnly = true;
			this.indexDate.Width = 92;
			// 
			// reindexWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(598, 411);
			this.Controls.Add(this.reindexLocationsList);
			this.Controls.Add(this.reindexButton);
			this.Name = "reindexWindow";
			this.Text = "MusicFind - Recreate Index";
			((System.ComponentModel.ISupportInitialize)(this.reindexLocationsList)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.Button reindexButton;
		private System.Windows.Forms.DataGridView reindexLocationsList;
		private System.Windows.Forms.DataGridViewCheckBoxColumn reindexCheckbox;
		private System.Windows.Forms.DataGridViewTextBoxColumn reindexLocation;
		private System.Windows.Forms.DataGridViewTextBoxColumn indexDate;
    }
}