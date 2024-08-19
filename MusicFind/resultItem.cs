using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicFind
{
	public interface resultItem
	{
		//public string name;
		bool search(ref searchParameters searchParams, ref List<resultItem> foudItems);
		string getFileName();
		string getDirName();
		string getRootName();
		//void setName(string newName);
	}

	
}
