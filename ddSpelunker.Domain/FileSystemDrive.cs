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
		
		public IEnumerable<Nugget> Spelunk()
		{
			var filesInRootPath = GetAllFiles(RootPath);
			
			List<Nugget> allFiles = new List<Nugget>();

			foreach (var filePath in filesInRootPath)
			{
				var fileName = Path.GetFileName(filePath);
				var nugget = new Nugget()
				{
					Name = fileName,
					Path = filePath
				};
				allFiles.Add(nugget);
			}
			
			return allFiles;
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
