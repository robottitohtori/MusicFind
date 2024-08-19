using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicFind
{
	public sealed class workerCanceller
	{
		private static readonly workerCanceller instance = new workerCanceller();
		public bool cancelWork { get; set; }

		static workerCanceller()
		{
		}

	    private workerCanceller()
	    {
			cancelWork = false;
	    }

	    public static workerCanceller Instance
	    {
			get
			{
	            return instance;
			}
		}
	}
}
