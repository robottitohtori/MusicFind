using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MusicFind
{
    public partial class settingsWindow : Form
    {
        public settingsWindow()
        {
            InitializeComponent();
			directoriesToIndex.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(directoriesToIndex_DefaultValuesNeeded);
			//this.Load += new System.EventHandler(settingsWindow_onload);
			//directoriesToIndexHelpLabel.Text = "eh" + directoriesToIndex.Controls.Count.ToString();
			directoriesToIndex.Columns[0].ToolTipText = helpStrings.defaultIndexTarget;
			directoriesToIndex.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(directoriesToIndex_RowsAdded);

			
			directoriesToIndex.SelectionChanged += new EventHandler(directoriesToIndex_clearSelection);
			//directoriesToIndex.

			this.KeyPreview = true;
			this.KeyPress += new KeyPressEventHandler(settingsWindow_KeyPress);
        }

		void settingsWindow_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Escape)
			{
				this.Close();
			}
		}

        // private settings sets;
        private mainWindow main;
        private settings oldSettings;
		//private string reindexingDefaultTooltipText = ;
        

        public void setSets(settings newSettings)
        {
            oldSettings = newSettings;

            directoriesToIndex.Rows.Clear();
            foreach (indexingLocation loc in newSettings.getIndexingLocations())
            {
				directoriesToIndex.Rows.Add(loc.reindexAsDefault, loc.location);
				// directoriesToIndexHelpLabel.Text = directoriesToIndex.Rows.Count.ToString();
				//directoriesToIndex.Rows[i].Cells[0].ToolTipText = reindexingDefaultTooltipText;
            }

			// can't do on prev loop(?)
			/*foreach (DataGridViewRow dat in directoriesToIndex.Rows)
			{
				dat.Cells[0].ToolTipText = reindexingDefaultTooltipText;
			}*/
            indexFile.Text = newSettings.indexFileLocation;
			indexFile.Select(indexFile.TextLength, 0);
			directoriesToIndex.ClearSelection();
			//directoriesToIndex.Rows[directoriesToIndex.Rows.Count - 1].Cells[0].Selected = true;
        }

        public void setCallback(mainWindow m)
        {
            main = m;
        }

		public void setVersionString(string versionString)
		{
			versionInfo.Text = versionString;
		}

        private void saveButton_Click(object sender, EventArgs e)
        {
			settings sets = new settings();

            sets.indexFileLocation = indexFile.Text;
			sets.settingsFileLocation = oldSettings.settingsFileLocation;
            foreach (DataGridViewRow row in directoriesToIndex.Rows)
            {
                if (row.Cells[1].Value != null)
                {
					sets.addIndexingLocation(row.Cells[1].Value.ToString(), (bool)row.Cells[0].Value);
                }
            }
            if (main != null)
            {
				if (main.setSettings(sets))
				{
					this.Close();
				}
				// TODO else
            }
        }

        private void directoriesToIndex_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
			if (e.ColumnIndex == 2)
			{
				// we've got a click at the button row
				directoriesToIndex_ButtonColumnClick(e);
			}
        }

		private void directoriesToIndex_ButtonColumnClick(DataGridViewCellEventArgs e)
		{
			// TODO something better than value comparison
			if (directoriesToIndex.Rows[e.RowIndex].Cells[2].Value.Equals("Browse"))
			{
				directoriesToIndex_ButtonColumnClickBrowse(e);
			}
			else
			{
				directoriesToIndex_ButtonColumnClickDelete(e);
			}
		}

		private void directoriesToIndex_ButtonColumnClickBrowse(DataGridViewCellEventArgs e)
		{
			FolderBrowserDialog browseWindow = new FolderBrowserDialog();
			//DialogResult result = browseWindow.ShowDialog();
			if (browseWindow.ShowDialog() == DialogResult.OK)
			{
				directoriesToIndex.Rows.Add(true, browseWindow.SelectedPath, "Delete");
				//directoriesToIndex.Rows[e.RowIndex].Cells[1].Value = browseWindow.SelectedPath;
				//directoriesToIndex.Rows[e.RowIndex].Cells[2].Value = "New";
				
			}
			//directoriesToIndex.
			
			//browseWindow.
				
		}

		private void directoriesToIndex_ButtonColumnClickDelete(DataGridViewCellEventArgs e)
		{
			directoriesToIndex.Rows.RemoveAt(e.RowIndex);
		}

		private void directoriesToIndex_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
		{
			e.Row.Cells[0].Value = true;
			//e.Row.Cells[0].ToolTipText = reindexingDefaultTooltipText;
		}

        private void indexFile_TextChanged(object sender, EventArgs e)
        {

        }

		private void directoriesToIndex_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{

			directoriesToIndex.Rows[e.RowIndex].Cells[0].ToolTipText = helpStrings.defaultIndexTarget;
			//directoriesToIndex.Rows[e.RowIndex].Cells[0].Value = true;
			directoriesToIndex.Rows[e.RowIndex].Cells[2].Value = "Browse";
			//deleteButton.
			//directoriesToIndex.Rows[e.RowIndex].Cells[2].
		}

		private void directoriesToIndex_clearSelection(object sender, EventArgs e)
		{
			directoriesToIndex.ClearSelection();
		}

		private void browseButton_Click(object sender, EventArgs e)
		{
			// indexing file location button
			SaveFileDialog browseWindow = new SaveFileDialog();
			if (browseWindow.ShowDialog() == DialogResult.OK)
			{
				indexFile.Text = browseWindow.FileName;
			}

		}
		/*private void settingsWindow_onload(object sender, EventArgs e)
		{
			ToolTip reindexingDefaultToolTip = new ToolTip();
			reindexingDefaultToolTip.SetToolTip(directoriesToIndex.Controls[1], "Set to make default reindexing target");

			ToolTip asd = new ToolTip();
			asd.SetToolTip(indexFile, "Test");
			
			// directoriesToIndex.Controls
			//directoriesToIndex Coltrols
		}*/

		
    }
}
