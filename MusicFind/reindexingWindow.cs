using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;


namespace MusicFind
{
	public partial class reindexingWindow : Form
	{
		private List<string> locations;

		private collection root;

		private settings sets;

		private BackgroundWorker indexWorker;
		
		public reindexingWindow()
		{
			InitializeComponent();
			this.Shown += new System.EventHandler(reindexingWindowShown);
			this.FormClosing += new FormClosingEventHandler(reindexingWindow_FormClosing);
			workerCanceller.Instance.cancelWork = false;

			this.KeyPreview = true;
			this.KeyPress += new KeyPressEventHandler(reindexingWindow_KeyPress);
		}

		private void cancelWorkers()
		{
			if (indexWorker != null && indexWorker.IsBusy)
			{
				indexWorker.CancelAsync();
				workerCanceller.Instance.cancelWork = true;
			}
		}

		private void reindexingWindow_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Escape)
			{
				this.Close();
			}
		}

		private void reindexingWindow_FormClosing(object sender, EventArgs e)
		{
			cancelWorkers();
		}

		private void reindexingWindowShown(object sender, EventArgs e)
		{
			startReindexing();
		}

		public void setLocations(List<string> newLocations)
		{
			locations = newLocations;
		}

		public void setCollection(collection newCollection)
		{
			root = newCollection;
		}

		public void setSettings(settings newSets)
		{
			sets = newSets;
		}

		public void startReindexing()
		{
			if (root == null || locations == null)
			{
				okButton.Visible = true;
				statusLabel.Text = "Internal error. ";
				return;
			}
			indexWorker = new BackgroundWorker();
			indexWorker.DoWork += (s, args) =>
			{
				reindex(ref root, ref locations, args);
			};
			indexWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.reindexDone);
			indexWorker.WorkerSupportsCancellation = true;
			indexWorker.RunWorkerAsync();
			//oldindexWorker.RunWorkerAsync();
		}

/*		public void startIndexing()
		{
			processingLabel.Text = "";
			directory root = new directory();
			List<string> errorStrings = new List<string>();
			foreach (string loc in locations)
			{
				processingLabel.Text = processingLabel.Text + "\nProcessing \"" + loc + "\"...\n";
				root.addSubDir(loc, errorStrings);
				foreach (string error in errorStrings)
				{
					processingLabel.Text = processingLabel.Text + error + "\n";
				}
				errorStrings.Clear();
			}
			
			okButton.Visible = true;
		}*/

		private void reindexing_Load(object sender, EventArgs e)
		{
			/*this.BeginInvoke((MethodInvoker)delegate
			{
				startIndexing();
			});*/
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			List<string> errors;
			statusLabel.Text = "Saving... ";
			processingLabel.Text += "\n\nSaving... ";
			processingPanel.AutoScrollPosition = new System.Drawing.Point(0, processingLabel.Height);
			okButton.Enabled = false;
			okButton.Click -= okButton_Click;
			okButton.Click += new System.EventHandler(this.okButton_Click2);

			if (!root.saveCollection(sets, out errors))
			{
				string message = "";
				foreach (string err in errors)
				{
					message += err;
				}
				statusLabel.Text = "Got errors saving. ";
				processingLabel.Text += "\n\n" + message;
				processingPanel.AutoScrollPosition = new System.Drawing.Point(0, processingLabel.Height);
			}
			else
			{
				statusLabel.Text = "Saving done. ";
				processingLabel.Text += "\n\nSaving done. ";
				processingPanel.AutoScrollPosition = new System.Drawing.Point(0, processingLabel.Height);
				//processingLabel. = new System.Drawing.Point(0, 500);
			}
			okButton.Text = "&OK";
			okButton.Enabled = true;
			// TODO handle error info correctly
		}

		private void okButton_Click2(object sender, EventArgs e)
		{
			this.Close();
		}

/*		private void indexWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			// okButton.Visible = true;
		} */

/*		private void indexWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			
			this.Invoke((MethodInvoker)delegate
			{
				processingLabel.Text = "";
			});
			
			directoryItem root = new directoryItem();
			List<string> errorStrings = new List<string>();
			root.allocateDirs((uint)locations.Count);

			for (int d = 0; d < locations.Count; d++)
			{
				if (indexWorker.CancellationPending)
				{
					e.Cancel = true;
					return;
				}
				this.Invoke((MethodInvoker)delegate
				{
					addToProcessingLabel("Processing \"" + locations[d] + "\"...\n");
				});

				root.addSubDir(locations[d], d, ref errorStrings);

				if (indexWorker.CancellationPending)
				{
					e.Cancel = true;
					return;
				}
				foreach (string error in errorStrings)
				{
					this.Invoke((MethodInvoker)delegate
					{
						addToProcessingLabel(error + "\n");
					});
				}

				errorStrings.Clear();
			}

		} */

		private void addToProcessingLabel(string message)
		{
			processingLabel.Text += message;
		}

		private void reindexDone(object sender, RunWorkerCompletedEventArgs e)
		{
			// check args!
			okButton.Enabled = true;
			okButton.Text = "&Save";
			statusLabel.Text = "Indexing done. ";
			processingLabel.Text += "\nIndexing done. ";
			processingPanel.AutoScrollPosition = new System.Drawing.Point(0, processingLabel.Height);

		}

		private void reindex(ref collection root, ref List<string> locs, DoWorkEventArgs e)
		{
			try
			{
				string statusText = "";
				this.Invoke((MethodInvoker)delegate
				{
					processingLabel.Text = "";
				});

				List<string> errors = new List<string>();
				//root.allocateDirs(locations.Count);

				for (int d = 0; d < locations.Count; d++)
				{
					statusText += "Processing \"" + locations[d] + "\"...\n";
					if (indexWorker.CancellationPending)
					{
						e.Cancel = true;
						return;
					}
					this.Invoke((MethodInvoker)delegate
					{
						processingLabel.Text = statusText;
					});

					root.addSubDir(locations[d], ref errors);

					foreach (string error in errors)
					{
						statusText += error + "\n";
					}
					if (indexWorker.CancellationPending)
					{
						e.Cancel = true;
						return;
					}
					this.Invoke((MethodInvoker)delegate
					{
						processingLabel.Text = statusText;
					});


					errors.Clear();
				}
			}
			catch (Exception)
			{
				return;
			}

		}

	}
}
