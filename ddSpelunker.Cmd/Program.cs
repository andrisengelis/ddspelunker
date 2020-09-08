using System;
using System.Collections.Generic;
using System.IO;

namespace ddSpelunker.Cmd
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("ddSpelunker started.");

			var rootDirectory = @"D:\";

			List<string> files = new List<string>();

			files.AddRange(AllFilesInDrive(rootDirectory));

			File.WriteAllLines(@"D:\content.txt", files);

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
