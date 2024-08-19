using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace MusicFind
{
	public class fileItem : resultItem
	{
		public string name = null;
		public directoryItem parent = null;


		public bool search(ref searchParameters searchParams, ref List<resultItem> foundItems)
		{
			if (searchParams == null || foundItems == null || name == null)
			{
				return false;
			}
			if (searchParams.searchFilenames == true)
			{
				bool hit = true;

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

			return true;
		}

		public string getFileName()
		{
			return (name == null) ? "" : name;
		}

		public string getDirName()
		{
			return ((parent == null) ? "" : parent.getDirName());
		}

		public string getRootName()
		{
			return (this.parent == null) ? "" : parent.getRootName();
		}

		public void getContents(ref string contents)
		{
			if (name == null)
				return;
			contents += ("f" + fileStrings.indexSeparator + name + "\n");
		}

		public void saveContents(StreamWriter sr)
		{
			if (name == null || sr == null)
				return;
			sr.WriteLine("f" + fileStrings.indexSeparator + name);
		}
	}
}
