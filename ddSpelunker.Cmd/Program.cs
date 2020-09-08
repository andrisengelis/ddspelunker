using System;
using System.Collections.Generic;
using System.IO;
using ddSpelunker.Domain;

namespace ddSpelunker.Cmd
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("ddSpelunker started.");

			var rootPath = @"D:\";
			var outputFileName = @"D:\content.txt";

			IDiskDrive diskDrive = new FileSystemDrive(rootPath);

			Spelunker ddSpelunker = new Spelunker(diskDrive);



			List<string> files = new List<string>();
			
			files.AddRange(AllFilesInDrive(rootPath));
			
			File.WriteAllLines(outputFileName, files);

			Console.WriteLine("ddSpelunker ended.");
		}

		static private List<string> AllFilesInDrive(string directoryPath)
		{
			List<string> filesInDirectory = new List<string>();

			foreach (var directory in Directory.EnumerateDirectories(directoryPath))
			{
				filesInDirectory.AddRange(AllFilesInDrive(directory));
			}

			filesInDirectory.AddRange(Directory.GetFiles(directoryPath));

			return filesInDirectory;
		}
	}
}
