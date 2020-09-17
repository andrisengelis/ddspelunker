using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            var diskTitle = "Movies0001";

            IDiskDrive diskDrive = new FileSystemDrive(rootPath);

            Spelunker ddSpelunker = new Spelunker(diskDrive);

            ddSpelunker.SpelunkDd();

            var outputContent = new List<string>();
            foreach (var nugget in ddSpelunker.Nuggets)
            {
                var nuggetString = $"{nugget.Name}\t{nugget.Path}";
                outputContent.Add(nuggetString);
            }

            using (var db = new SpelunkerContext())
            {
                db.Add(new DiskDrive {Title = diskTitle});
                db.SaveChanges();

                var disk = db.DiskDrives.First(dd => dd.Title == diskTitle);

                foreach (var nugget in ddSpelunker.Nuggets)
                {
                    disk.Files.Add(
                        new NuggetFile()
                        {
                            Title = nugget.Name,
                            Path = nugget.Path
                        });
                }

                db.SaveChanges();
            }
            
            File.WriteAllLines(outputFileName, outputContent);

            Console.WriteLine("ddSpelunker ended.");
        }
    }
}