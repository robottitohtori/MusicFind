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
    public partial class reindexWindow : Form
    {
        //private string[] locations = new string[] { "c:\\flac", "k:\\flac", "e:\\mp3" };

        private mainWindow main;

		private collection root;

		private settings sets;

        public reindexWindow()
        {
            InitializeComponent();
			reindexLocationsList.SelectionChanged += new EventHandler(reindexLocationsList_clearSelection);

			this.KeyPreview = true;
			this.KeyPress += new KeyPressEventHandler(reindexWindow_KeyPress);
        }

		void reindexWindow_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Escape)
			{
				this.Close();
			}
		}

		public void setCollection(collection newCollection)
		{
			root = newCollection;
		}

        public void setSettings(settings newSets)
        {
			sets = newSets;
			
            //reindexLocationsList.BeginUpdate();
			reindexLocationsList.Rows.Clear();

			if (sets == null)
				return;

            foreach (indexingLocation loc in sets.getIndexingLocations())
            {
				reindexLocationsList.Rows.Add(loc.reindexAsDefault, loc.location, ((root == null || !root.indexDates.ContainsKey(loc.location) || root.indexDates[loc.location] == null) ? "never" : root.indexDates[loc.location]));
            }
			//reindexLocationsList.ClearSelection();
            //reindexLocationsList.EndUpdate();
            // indexCreatedAtLabel.Text = "Index created at " + sets.indexDate;
        }

        public void setCallback(mainWindow m)
        {
            main = m;
        }

        private void reindexLocationsList_clearSelection(object sender, EventArgs e)
        {
			reindexLocationsList.ClearSelection();
        }

        private void reindexButton_Click(object sender, EventArgs e)
        {
			List<DataGridViewRow> checkedItems;
			if (getCheckedItems(out checkedItems) == 0)
			{
				return;
			}
			List<string> indexItems = new List<string>();
			foreach (DataGridViewRow item in checkedItems)
			{
				indexItems.Add(item.Cells[1].Value.ToString());
			}
			reindexingWindow indexer = new reindexingWindow();
			indexer.setLocations(indexItems);
			indexer.setCollection(root);
			indexer.setSettings(sets);
			// indexer.startReindexing();
			indexer.ShowDialog();
			//indexer.startIndexing();
			this.Close();
        }

		private int getCheckedItems(out List<DataGridViewRow> checkedItems)
		{
			checkedItems = new List<DataGridViewRow>();
			foreach (DataGridViewRow row in reindexLocationsList.Rows)
			{
				if ((bool)row.Cells[0].Value == true)
				{
					checkedItems.Add(row);
				}
			}


			return checkedItems.Count;
		}


    }
}
