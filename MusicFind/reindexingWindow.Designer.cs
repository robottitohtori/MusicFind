namespace MusicFind
{
	partial class reindexingWindow
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
			this.label1 = new System.Windows.Forms.Label();
			this.statusLabel = new System.Windows.Forms.Label();
			this.processingLabel = new System.Windows.Forms.Label();
			this.okButton = new System.Windows.Forms.Button();
			this.processingPanel = new System.Windows.Forms.Panel();
			this.processingPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(6, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(149, 31);
			this.label1.TabIndex = 0;
			this.label1.Text = "Reindexing";
			// 
			// statusLabel
			// 
			this.statusLabel.AutoSize = true;
			this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.statusLabel.Location = new System.Drawing.Point(9, 40);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(80, 16);
			this.statusLabel.TabIndex = 1;
			this.statusLabel.Text = "Please wait.";
			// 
			// processingLabel
			// 
			this.processingLabel.AutoSize = true;
			this.processingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.processingLabel.Location = new System.Drawing.Point(3, 0);
			this.processingLabel.Name = "processingLabel";
			this.processingLabel.Size = new System.Drawing.Size(76, 16);
			this.processingLabel.TabIndex = 2;
			this.processingLabel.Text = "Processing";
			// 
			// okButton
			// 
			this.okButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.okButton.Enabled = false;
			this.okButton.Location = new System.Drawing.Point(199, 343);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(80, 25);
			this.okButton.TabIndex = 3;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// processingPanel
			// 
			this.processingPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.processingPanel.AutoScroll = true;
			this.processingPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.processingPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.processingPanel.Controls.Add(this.processingLabel);
			this.processingPanel.Location = new System.Drawing.Point(12, 72);
			this.processingPanel.Name = "processingPanel";
			this.processingPanel.Size = new System.Drawing.Size(455, 265);
			this.processingPanel.TabIndex = 4;
			// 
			// reindexingWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(479, 380);
			this.Controls.Add(this.processingPanel);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.statusLabel);
			this.Controls.Add(this.label1);
			this.Name = "reindexingWindow";
			this.Text = "MusicFind - Reindexing";
			this.Load += new System.EventHandler(this.reindexing_Load);
			this.processingPanel.ResumeLayout(false);
			this.processingPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.Label processingLabel;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Panel processingPanel;
	}
}