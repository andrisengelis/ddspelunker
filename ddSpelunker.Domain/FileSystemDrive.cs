using System;
using System.Collections.Generic;
using System.IO;

namespace ddSpelunker.Domain
{
	public class FileSystemDrive : IDiskDrive
	{
		public string RootPath { get; set; }
		
		public FileSystemDrive(string rootPath)
		{
			RootPath = rootPath;
		}
		
		public IEnumerable<String> Spelunk()
		{
			return GetAllFiles(RootPath);
		}

		private IEnumerable<String> GetAllFiles(string directoryPath)
		{
			List<string> filesInDirectory = new List<string>();

			foreach (var directory in Directory.EnumerateDirectories(directoryPath))
			{
				filesInDirectory.AddRange(GetAllFiles(directory));
			}

			filesInDirectory.AddRange(Directory.GetFiles(directoryPath));

			return filesInDirectory;
		}
	}
}
