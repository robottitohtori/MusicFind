using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace MusicFind
{
	public class collection
	{
		public Dictionary<string, directoryItem> directories { get; private set; }
		public Dictionary<string, uint> fileCounts { get; private set; }
		public Dictionary<string, uint> dirCounts { get; private set; }
		public Dictionary<string, string> indexDates { get; private set; }
		public uint fileCount { get; private set; }
		public uint dirCount { get; private set; }
		public string indexDate { get; private set; }
		public bool loaded { get; private set; }

		public collection()
		{
			reset();
		}

		private void reset()
		{
			directories = new Dictionary<string, directoryItem>();
			fileCounts = new Dictionary<string, uint>();
			dirCounts = new Dictionary<string, uint>();
			indexDates = new Dictionary<string, string>();
			indexDate = "";
			fileCount = 0;
			dirCount = 0;
			loaded = false;
		}

		public bool search(ref searchParameters searchParams, ref List<resultItem> foundItems)
		{
			if (searchParams == null || foundItems == null)
				return false;
			foreach (directoryItem item in directories.Values)
			{
				item.search(ref searchParams, ref foundItems);
			}
			return true;
		}

		public bool addSubDir(string newName, ref List<string> errors)
		{
			if (newName == null || errors==null || newName == "")
				return false;

			// "flush" in case there's old data
			directories.Remove(newName);
			directoryItem dirToAdd = new directoryItem();
			if (dirToAdd.nameAndPopulate(ref newName, ref errors))
			{
				directories[newName] = dirToAdd;
				fileCounts[newName] = directories[newName].getFileCount();
				dirCounts[newName] = directories[newName].getDirCount();
				indexDate = DateTime.Now.ToString();
				indexDates[newName] = indexDate;
				loaded = true;
				updateCounts();
				return true;
			}
			return false;
		}

		public bool delSubDir(string delName)
		{
			if (delName == null || delName=="")
				return false;
			directories.Remove(delName);
			indexDates.Remove(delName);
			updateIndexDate();
			updateCounts();
			if (directories.Count == 0)
			{
				loaded = false;
			}
			return true;
		}

		private void updateIndexDate()
		{
			DateTime curNewest = new DateTime();
			DateTime challenger;
			foreach (string dat in indexDates.Values)
			{
				if (DateTime.TryParse(dat, out challenger))
				{
					if (challenger > curNewest)
					{
						curNewest = challenger;
					}
				}

				
			}
			challenger = new DateTime();
			if (curNewest != challenger)
			{
				indexDate = curNewest.ToString();
			}
			else
			{
				indexDate = "";
			}
		}

		private void updateCounts()
		{
			fileCount = 0;
			dirCount = 0;

			foreach (string dir in directories.Keys)
			{
				fileCount += directories[dir].getFileCount();
				dirCount += directories[dir].getDirCount();
			}

		}

		public bool loadCollection(settings sets, out List<string> errors)
		{
			errors = new List<string>();
			bool success = false;

			if (sets == null)
			{
				errors.Add(errorStrings.settingsFileNotSet );
				return false;
			}
				
			if (sets.indexFileLocation == null || sets.indexFileLocation == "")
			{
				errors.Add(errorStrings.settingsIndexNotSet);
				return false;
			}
				
			try
			{
				System.IO.StreamReader index = new System.IO.StreamReader(sets.indexFileLocation);
				success = parseCollection(index);
				index.Close();
				success = true;
			}
			catch (Exception)
			{
				errors.Add(errorStrings.indexFileNotReadable);
				reset();
				//errors.Add(ex.Message);
				return false;
			}
			if (!success)
			{
				errors.Add(errorStrings.indexParseError);
				reset();
			}
			else if (directories.Count > 0)
			{
				loaded = true;
			}
			return success;
		}

		private bool parseCollection(System.IO.StreamReader index)
		{
			string line;
			//string curLocation = "";
			//string curDir = "";

			Stack<Queue<directoryItem>> dirStack = new Stack<Queue<directoryItem>>();
			Queue<directoryItem> currentDirQueue = new Queue<directoryItem>();
			directoryItem currentDirectory = null;

			uint fileCounter = 0;
			uint dirCounter = 0;
			uint fileCount = 0;
			uint dirCount = 0;

			//Match reg;
			string[] tokens;
			//int depth = 0;
			reset();
			while ((line = index.ReadLine()) != null)
			{
				tokens = line.Split(fileStrings.indexSeparator);
				//reg = Regex.Match(line, fileStrings.patternIndexLine);
				if (tokens.Length > 1)
				{
					//string type = tokens[0];

					switch (tokens[0])
					{
						case "l":
							if (tokens.Length < 3)
							{
								return false;
							}
							indexDates[tokens[1]] = tokens[2];
							directoryItem newLocation = new directoryItem();
							newLocation.name = tokens[1];
							directories.Add(tokens[1], newLocation);
							currentDirQueue = new Queue<directoryItem>();
							currentDirQueue.Enqueue(newLocation);
							dirStack.Push(currentDirQueue);
							currentDirQueue = new Queue<directoryItem>();
							break;

						case "d":
							//curDir = tokens[1];
							if (tokens.Length < 4)
							{
								return false;
							}
							if (!uint.TryParse(tokens[2], out dirCount) || !uint.TryParse(tokens[3], out fileCount))
							{
								return false;
							}
							// TODO max number of items?

							//directories[curLocation].
							//currentDirectory = curDirQueue.Dequeue();
							while (currentDirQueue.Count == 0)
							{
								currentDirQueue = dirStack.Pop();
							}
							currentDirectory = currentDirQueue.Dequeue();
							currentDirectory.allocateDirs(dirCount);

							currentDirectory.allocateFiles(fileCount);

							if (dirCount > 0)
							{
								dirStack.Push(currentDirQueue);
								currentDirQueue = new Queue<directoryItem>();
							}
							dirCounter = 0;
							fileCounter = 0;
							break;

						case "s":
							if (currentDirectory != null && currentDirectory.directories != null && dirCounter < currentDirectory.directories.Length)
							{
								currentDirectory.directories[dirCounter] = new directoryItem();
								currentDirectory.directories[dirCounter].name = tokens[1];
								currentDirectory.directories[dirCounter].parent = currentDirectory;
								currentDirQueue.Enqueue(currentDirectory.directories[dirCounter]);
								dirCounter++;
							}
							else
							{
								return false;
							}
							/*if (dirCount > 0 && dirCount == dirCounter)
							{
								currentDirQueue = dirQueue.Dequeue();
								//depth--;
							}*/
							break;

						case "f":
							if (currentDirectory != null && currentDirectory.files != null && fileCounter < currentDirectory.files.Length)
							{
								currentDirectory.files[fileCounter] = new fileItem();
								currentDirectory.files[fileCounter].name = tokens[1];
								currentDirectory.files[fileCounter].parent = currentDirectory;
								fileCounter++;
							}
							else
							{
								return false;
							}
							break;

						default:
							return false;
					}
				}
				else
				{
					return false;
				}
			}
			updateIndexDate();
			updateCounts();
			return true;
		}

		public bool saveCollection(settings sets, out List<string> errors)
		{
			errors = new List<string>();
			/*string contents = "";
			foreach (string dirName in directories.Keys)
			{
				contents += "l" + fileStrings.indexSeparator + dirName + fileStrings.indexSeparator + indexDates[dirName] + "\n";
				directories[dirName].getContents(ref contents);
			}*/

			if (directories == null)
			{
				errors.Add(errorStrings.internalError);
				return false;
			}


			///////////////

			bool everythingSuccesful = false;
			if (sets.indexFileLocation == "" || sets.indexFileLocation == null)
			{
				errors.Add(errorStrings.settingsIndexNotSet);
				return false;
			}

			FileInfo info = new FileInfo(sets.indexFileLocation);
			if (!info.Exists)
			{
				errors.Add(errorStrings.noFileFoundButCreating);
				DirectoryInfo dinfo = info.Directory;
				if (!dinfo.Exists)
				{
					errors.Add(errorStrings.noDirFoundButCreating);
					dinfo.Create();
				}
			}


			try
			{
				using (StreamWriter sr = new StreamWriter(sets.indexFileLocation))
				{
					foreach (string dirName in directories.Keys)
					{
						sr.WriteLine("l" + fileStrings.indexSeparator + dirName + fileStrings.indexSeparator + indexDates[dirName]);
						directories[dirName].saveContents(sr);
					}
					
					everythingSuccesful = true;
				}
			}
			catch (Exception ex)
			{
				// separate catches?
				errors.Add(errorStrings.indexFileNotWritable);
				errors.Add(ex.Message);
			}

			return everythingSuccesful;


			///////////////

			
		}
	}
}
