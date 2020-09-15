using System;
using System.Collections.Generic;

namespace ddSpelunker.Domain
{
	public class Spelunker
	{
		private readonly IDiskDrive _diskDrive;
		public IEnumerable<Nugget> Nuggets { get; set; }
		
		public Spelunker(IDiskDrive diskDrive)
		{
			_diskDrive = diskDrive;
		}

		public void SpelunkDd()
		{
			Nuggets = _diskDrive.Spelunk();
		}
	}
}
