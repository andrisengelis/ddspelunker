using System;
using System.Collections.Generic;

namespace ddSpelunker.Domain
{
	public class Spelunker
	{
		private readonly IDiskDrive _diskDrive;
		public IEnumerable<String> Files { get; set; }
		
		public Spelunker(IDiskDrive diskDrive)
		{
			_diskDrive = diskDrive;
		}

		public void SpelunkDd()
		{
			Files = _diskDrive.Spelunk();
		}
	}
}
