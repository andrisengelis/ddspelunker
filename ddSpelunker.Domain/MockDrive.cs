using System;
using System.Collections.Generic;

namespace ddSpelunker.Domain
{
	public class MockDrive : IDiskDrive
	{
		public string RootPath { get; set; }
		public IEnumerable<String> Spelunk()
		{
			throw new NotImplementedException();
		}

		public MockDrive(string rootPath)
		{
			RootPath = rootPath;
		}
	}
}
