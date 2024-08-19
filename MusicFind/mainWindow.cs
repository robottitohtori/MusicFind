using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics;

namespace MusicFind
{
    public partial class mainWindow : Form
    {
        private settings sets = new settings();
		private collection root = new collection();
		private List<resultItem> foundItems = new List<resultItem>();
		private static uint[] version;


		public mainWindow()
        {
            InitializeComponent();
            loadSettings();

			foundGrid.DoubleClick += new EventHandler(foundGrid_DoubleClick);
			foundGrid.KeyPress += new KeyPressEventHandler(foundGrid_KeyPress);

			searchBox.Enter += new EventHandler(searchBox_Enter);
			searchBox.Leave += new EventHandler(searchBox_Leave);
			foundGrid.Enter += new EventHandler(foundGrid_Enter);
			foundGrid.Leave += new EventHandler(foundGrid_Leave);

			toolStripSettings.Click += new EventHandler(toolStripSettings_Click);
			toolStripReindex.Click += new EventHandler(toolStripRecreateIndex_Click);

			version = new uint[] { 0, 3 };

        }

		void foundGrid_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				launcItems();
				e.Handled = true;
			}    
		}

		void foundGrid_Leave(object sender, EventArgs e)
		{
			AcceptButton = null;
		}

		void foundGrid_Enter(object sender, EventArgs e)
		{
			AcceptButton = launchButton;
		}

		void searchBox_Leave(object sender, EventArgs e)
		{
			AcceptButton = null;
		}

		void searchBox_Enter(object sender, EventArgs e)
		{
			AcceptButton = searchButton;
		}

        public bool setSettings(settings newSettings)
        {
            bool success = true;
			bool reloadIndex = false;
            List<string> errors;

			if (sets.indexFileLocation != newSettings.indexFileLocation)
			{
				reloadIndex = true;
			}

            sets = newSettings;

			if (!sets.saveSettings(out errors))
			{
				string message = errorStrings.settingsSaveError + ": \n";
				if (errors != null)
				{
					foreach (string er in errors)
					{
						message = message + er + "\n";
					}
				}
				errorWindow error = new errorWindow();
				error.setErrorText(message);
				error.ShowDialog();
				success = false;
			}
			else
			{
				if (reloadIndex)
				{
					success = loadCollection();
				}
				if (success)
				{
					if (deleteObsoleteLocations())
					{
						success = saveCollection();
					}
				}
			}
            return success;
        }

        public bool loadSettings()
        {
            /*sets.indexingLocations.Add("c:\\flac");
            sets.indexingLocations.Add("k:\\flac");
            sets.indexingLocations.Add("e:\\mp3");
            sets.indexFileLocation = "c:\\temp\\index.txt";*/
			sets.settingsFileLocation = System.Environment.GetEnvironmentVariable("APPDATA") + "\\MusicFind\\MusicFind.ini";
            List<string> errors; // = new List<string>();
			if (!sets.loadSettings(out errors))
			{
				if (errors.Count == 1 && (errors[0].Equals(errorStrings.settingsFileNotFound) || errors[0].Equals(errorStrings.settingsAllNotFound)))
				{
					showSettings();
				}
				else
				{
					string message = errorStrings.settingsLoadError + " \"" + sets.settingsFileLocation + "\": \n";
					if (errors != null)
					{
						foreach (string er in errors)
						{
							message = message + er + "\n";
						}
					}
					errorWindow error = new errorWindow();
					error.setErrorText(message);
					error.ShowDialog();
				}
				return false;

			}
			else
			{
				//sets.indexDate = DateTime.Now;
				//sets.files = 23908;
				//sets.dirs = 235;
				return loadCollection();
			}
        }
		
		public void refreshFoundItems()
		{
			clearFoundGrid();

			if (foundItems == null)
				return;

			foreach (resultItem item in foundItems)
			{
				string dirName = item.getDirName();
				if (sets.hideRootDirectories)
				{
					Match reg = Regex.Match(dirName, "^" + Regex.Escape(item.getRootName()) + "(.*)$");
					if (reg.Success)
					{
						dirName = reg.Groups[1].Value;
					}
					// TODO else error
				}
				addDataRow(item.getRootName(), dirName, item.getFileName());

				//  (resultItem.get
			}


		}

		public void refreshStatusBar()
        {
			if (!root.loaded)
			{
				toolStripIndexInfo.Text = "The index is empty. Please reindex. ";
			}
			else
			{
				toolStripIndexInfo.Text = "Index contains " + root.fileCount.ToString() + " files and " + root.dirCount.ToString() + " dirs, last reindex: " + root.indexDate + ". ";
			}
        }

		public static string getVersionString()
		{
			string versionString = "Version ";
			bool first = true;
			foreach (uint v in version)
			{
				versionString += (first ? "" : ".") + v;
				first = false;
			}
			return versionString;
		}

		public static uint[] getVersion()
		{
			return version;
		}

		// return true if there were obsolete locations to delete
		private bool deleteObsoleteLocations()
		{
			List<string> deleteThese = new List<string>();
			foreach (string oldDir in root.directories.Keys)
			{
				bool found = false;
				foreach (indexingLocation newDir in sets.getIndexingLocations())
				{
					if (newDir.location == oldDir)
					{
						found = true;
						break;
					}
				}
				if (!found)
				{
					deleteThese.Add(oldDir);
				}
			}

			if (deleteThese.Count > 0)
			{
				foreach (string oldDir in deleteThese)
				{
					root.delSubDir(oldDir);
				}
				refreshStatusBar();
				return true;
			}
			return false;
		}

   		private bool loadCollection()
		{
			List<string> errors;
			if (!root.loadCollection(sets, out errors))
			{
				if (errors != null)
				{
					if (errors[0] != null && errors[0] == errorStrings.indexFileNotReadable)
					{
						// index not found, new installation or such.
						
					}
					else
					{
						string message = "";
						foreach (string er in errors)
						{
							message = message + er + "\n";
						}
						errorWindow error = new errorWindow();
						error.setErrorText(message);
						error.ShowDialog();
						return false;
					}
				}
			}

			refreshStatusBar();
			return true;
		}

		private bool saveCollection()
		{
			List<string> errors;
			if (!root.saveCollection(sets, out errors))
			{
				if (errors != null)
				{
					if (errors[0] != null && errors[0] == errorStrings.indexFileNotReadable)
					{
						// index not found, new installation or such.

					}
					else
					{
						string message = "";
						foreach (string er in errors)
						{
							message = message + er + "\n";
						}
						errorWindow error = new errorWindow();
						error.setErrorText(message);
						error.ShowDialog();
						return false;
					}
				}
			}

			refreshStatusBar();
			return true;
		}
	
        private void addDataRow(string searchLocation, string dir, string file)
        {
			string[] newRow = new string[4] { foundGrid.RowCount.ToString(), searchLocation, dir, file };
            foundGrid.Rows.Add(newRow);
            // curRows++;
        }

        private void launchButton_Click(object sender, EventArgs e)
        {
			launcItems();
        }        

		private void searchButton_Click(object sender, EventArgs e)
        {
            //string rev = new string searchBox.Text.Clone();
            /*string pattern = "^([^ ]+) ([^ ]+) (.+)$";
            string[] dada;
            Match reg = Regex.Match(searchBox.Text, pattern);
            if (reg.Success)
            {
                dada = new string[] { reg.Groups[1].Value, reg.Groups[2].Value, reg.Groups[3].Value };
            }
            else
            {
                dada = new string[] { searchBox.Text, "", "" };
            }
            // { searchBox.Text, searchBox.Text. };
            // dada = [];
            addDataRow(dada);
            // foundGrid.Rows.Add(dada);
            //.SetValues(dada);
            searchBox.Text = "";
            foundGrid.ClearSelection();*/

			foundItems.Clear();

			searchParameters searchParams = new searchParameters();
			searchParams.searchDirectories = opt_d.Checked;
			searchParams.searchFilenames = opt_f.Checked;
			string[] keywords = Regex.Split(searchBox.Text, searchStrings.patternKeywordSplit);
			if (keywords != null)
			{
				for (int d = 0; d < keywords.Length; d++)
				{
					keywords[d] = Regex.Escape(keywords[d]);
				}
			}
			searchParams.searchWords = keywords;
			
			root.search(ref searchParams, ref foundItems);
			refreshFoundItems();

			searchBox.SelectAll();

        }

        private void mainWindow_Load(object sender, EventArgs e)
        {

        }

        private void foundGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // toolStripIndexInfo.Text = foundGrid.CurrentCellAddress.Y.ToString();
            // foundGrid.Rows[foundGrid.CurrentCellAddress.Y].Selected = true;
        }

		private void foundGrid_DoubleClick(object sender, EventArgs e)
		{
			launcItems();
		}

        private void toolStripSettings_Click(object sender, EventArgs e)
        {
			showSettings();
        }

		private void toolStripRecreateIndex_Click(object sender, EventArgs e)
        {
			showRecreateIndex();
        }

		private void showSettings()
		{
			settingsWindow settings = new settingsWindow();
			settings.setSets(sets);
			settings.setCallback(this);
			settings.setVersionString(getVersionString());
			settings.ShowDialog();
		}
        
		private void showRecreateIndex()
		{
			reindexWindow reindex = new reindexWindow();
			reindex.setCollection(root);
			reindex.setSettings(sets);
			reindex.setCallback(this);
			reindex.ShowDialog();
			refreshStatusBar();
		}

		private void launcItems()
		{
			List<string> launchList = new List<string>();
			foreach (DataGridViewCell cell in foundGrid.SelectedCells)
			{
				
				if (cell.ColumnIndex == 0 || cell.ColumnIndex == 3)
				{
					launchList.Add(((sets.hideRootDirectories == false) ? "" : foundGrid.Rows[cell.RowIndex].Cells[1].Value.ToString()) + foundGrid.Rows[cell.RowIndex].Cells[2].Value.ToString() + ((foundGrid.Rows[cell.RowIndex].Cells[3].Value.ToString() == "") ? "" : fileStrings.valueDirSeparator + foundGrid.Rows[cell.RowIndex].Cells[3].Value.ToString()));
				}
				else if (cell.ColumnIndex == 2)
				{
					launchList.Add(((sets.hideRootDirectories == false) ? "" : foundGrid.Rows[cell.RowIndex].Cells[1].Value.ToString()) + cell.Value.ToString());
				}
				/*else if (cell.ColumnIndex == 3)
				{
					launchList.Add(foundGrid.Rows[cell.RowIndex].Cells[1].Value.ToString() + foundGrid.Rows[cell.RowIndex].Cells[2].Value.ToString() + fileStrings.valueDirSeparator + cell.Value.ToString());
				}*/
			}

			//string launchString = "";
			foreach (string lau in launchList)
			{
				Process launcher = new Process();
				launcher.StartInfo.FileName = sets.launchProgram;
				launcher.StartInfo.Arguments = "\"" + lau + "\"";
				launcher.Start();
			}
			//toolStripIndexInfo.Text = "Launched" + launchString;

			clearFoundGridSelection();
		}

        private void clearFoundGridSelection()
        {
            foundGrid.ClearSelection();
        }

		private void clearFoundGrid()
		{
			foundGrid.Rows.Clear();
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == (Keys.Control | Keys.D))
			{
				opt_d.Checked = !opt_d.Checked;
				return true;
			}
			if (keyData == (Keys.Control | Keys.F))
			{
				opt_f.Checked = !opt_f.Checked;
				return true;
			}
			if (keyData == (Keys.Alt | Keys.S))
			{
				showSettings();
				return true;
			}
			if (keyData == (Keys.Alt | Keys.R))
			{
				showRecreateIndex();
				return true;
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}
    }
}
