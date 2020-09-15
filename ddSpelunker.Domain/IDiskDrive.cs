using System;
using System.Collections.Generic;

namespace ddSpelunker.Domain
{
	public interface IDiskDrive
	{
		string RootPath { get; set; }

		IEnumerable<Nugget> Spelunk();
	}
}
