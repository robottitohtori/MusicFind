using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace MusicFind
{
	public class directoryItem : resultItem
	{
		public string name = null;
		public fileItem[] files;
		public directoryItem[] directories;
		public directoryItem parent = null;

		// private int nextFreeDirSlot = 0;
		//directory parent = null;


/*		public string getWholeDirectory()
		{
			if (name != null && parent != null)
			{
				return parent.getWholeDirectory() + "\\" + name;
			}
			else
			{
				string dirBase = new string(name.ToArray());
				return dirBase;
			}
		} */

		public string getDirName()
		{
			return name;
		}

		public string getFileName()
		{
			return "";
		}

		public string getRootName()
		{
			return (this.parent == null) ? name : parent.getRootName();
		}

		public bool search(ref searchParameters searchParams, ref List<resultItem> foundItems)
		{
			if (searchParams == null || foundItems == null)
				return false;
			bool hit = false;

			if (searchParams.searchDirectories == true && name != null)
			{
				hit = true;

				if (searchParams.searchWords != null && searchParams.searchWords.Length > 0)
				{
					foreach (string searchKeyword in searchParams.searchWords)
					{
						if (searchKeyword != null)
						{
							Match reg = Regex.Match(name, searchKeyword, RegexOptions.IgnoreCase);
							if (!reg.Success)
							{
								hit = false;
							}
						}
					}
				}
				if (hit)
				{
					foundItems.Add((resultItem)this);
				}
			}

			if (searchParams.searchFilenames == true && files != null && files.Length > 0)
			{
				foreach (fileItem file in files)
				{
					if (file != null)
					{
						if (hit)
							foundItems.Add((resultItem)file);
						else
							file.search(ref searchParams, ref foundItems);
					}
				}
			}

			if (directories != null)
			{
				foreach (directoryItem dir in directories)
				{
					if (dir != null)
					{
						dir.search(ref searchParams, ref foundItems);
					}
				}
			}


			return false;
		}

		public void allocateDirs(uint num)
		{
			directories = new directoryItem[num];
		}

		public void allocateFiles(uint num)
		{
			files = new fileItem[num];
		}

		public void addFile(string newName, int num, ref List<string> errors)
		{
			if (newName == null || newName == "" || num < 0 || num > files.Length - 1 || errors ==  null)
				return;
			fileItem fileToAdd = new fileItem();
			fileToAdd.name = newName;
			fileToAdd.parent = this;
			files[num] = fileToAdd;

		}

		public bool addSubDir(string newName, int num, ref List<string> errors)
		{
			if (newName == null || newName == "" || num < 0 || num > directories.Length - 1 || errors == null || workerCanceller.Instance.cancelWork)
			{
				return false;
			}
			directoryItem dirToAdd = new directoryItem();
			if (dirToAdd.nameAndPopulate(ref newName, ref errors))
			{
				dirToAdd.parent = this;
				directories[num] = dirToAdd;
				return true;
			}
			else
			{
				return false;
			}

			
		}

		/*private void addSubDir(string newName, directory parentDir, List<string> errorStrings)
		{
			directory dirToAdd = new directory();
			dirToAdd.nameAndPopulate(newName, parentDir, errorStrings);
			directories.Add(dirToAdd);
		}*/

		public bool nameAndPopulate(ref string newName, ref List<string> errors)
		{
			if (newName == null || newName == "" || errors == null)
				return false;

			string[] subDirs = null;
			string[] subFiles = null;
			//directories = null;
			//files = null;
			name = newName;
			//bool success = true;
			//parent = parentDir;
			//string wholeDir = getWholeDirectory();
			try
			{
				//errorStrings.Add("Probing " + name + "\n");
				subDirs = Directory.GetDirectories(name);
				subFiles = Directory.GetFiles(name);
			}
			catch (Exception ex)
			{
				errors.Add("Error opening \"" + name + "\": " + ex.Message);
				return false;
			}

			if (subFiles != null)
			{
				allocateFiles((uint)subFiles.Length);
				for (int d = 0; d < subFiles.Length; d++)
				{
					//errors.Add("Added " + subDirs[d]);
					Match reg = Regex.Match(subFiles[d], searchStrings.patternFileNameSeparation);
					if (reg.Success)
					{
						addFile(reg.Groups[1].Value, d, ref errors);
					}
				}
			}
			if (subDirs != null)
			{
				allocateDirs((uint)subDirs.Length);
				for (int d = 0; d < subDirs.Length; d++)
				{
					//errors.Add("Adding " + subDirs[d]);
					if (!addSubDir(subDirs[d], d, ref errors))
					{
						workerCanceller.Instance.cancelWork = false;
						return false;
					}
				}
			}
			return true;


		}

		public uint getFileCount()
		{
			uint num = 0;
			if (directories != null)
			{
				foreach (directoryItem dir in directories)
				{
					if (dir != null) num += dir.getFileCount();
				}
			}
			// we'll trust the cast..
			return ((files == null) ? num : num + (uint)files.Length);
		}

		public uint getDirCount()
		{
			uint num = 1;
			if (directories != null)
			{
				foreach (directoryItem dir in directories)
				{
					if (dir != null) num += dir.getDirCount();
				}
			}
			// we'll trust the cast..
			return num;
		}

		public void getContents(ref string contents)
		{
			if (name == null)
				return;

			contents += "d" + fileStrings.indexSeparator + name + fileStrings.indexSeparator + directories.Length + fileStrings.indexSeparator + files.Length + "\n";

			foreach (directoryItem dir in directories)
			{
				contents += "s" + fileStrings.indexSeparator + dir.getDirName() + "\n";
			}

			foreach (fileItem file in files)
			{
				file.getContents(ref contents);
			}

			foreach (directoryItem dir in directories)
			{
				dir.getContents(ref contents);
			}

		}

		public void saveContents(StreamWriter sr)
		{
			{
				if (name == null || sr == null || directories == null || files == null)
				{
					throw new ArgumentNullException();
				}

				sr.WriteLine("d" + fileStrings.indexSeparator + name + fileStrings.indexSeparator + directories.Length + fileStrings.indexSeparator + files.Length);

				foreach (directoryItem dir in directories)
				{
					sr.WriteLine("s" + fileStrings.indexSeparator + dir.getDirName());
				}
				foreach (fileItem file in files)
				{
					file.saveContents(sr);
				}
				foreach (directoryItem dir in directories)
				{
					dir.saveContents(sr);
				}

			}
		}
	}


}
