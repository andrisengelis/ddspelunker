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

            ddSpelunker.SpelunkDd();

            var outputContent = new List<string>();
            foreach (var nugget in ddSpelunker.Nuggets)
            {
                var nuggetString = $"{nugget.Name}\t{nugget.Path}";
                outputContent.Add(nuggetString);
            }
            
            File.WriteAllLines(outputFileName, outputContent);

            Console.WriteLine("ddSpelunker ended.");
        }
    }
}