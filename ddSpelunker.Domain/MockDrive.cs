using System;
using System.Collections.Generic;
using System.Text;

namespace ddSpelunker.Domain
{
	public class MockDrive : IDiskDrive
	{
		public string RootPath { get; set; }

		public MockDrive(string rootPath)
		{
			RootPath = rootPath;
		}
	}
}
