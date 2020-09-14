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

            File.WriteAllLines(outputFileName, ddSpelunker.Files);

            Console.WriteLine("ddSpelunker ended.");
        }
    }
}