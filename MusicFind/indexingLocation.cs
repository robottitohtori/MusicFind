using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicFind
{
	public class indexingLocation
	{
		public string location { get; set; }
		public bool reindexAsDefault { get; set; }

		public indexingLocation(string loc, bool def)
		{
			location = loc;
			reindexAsDefault = def;
		}
	}


}
