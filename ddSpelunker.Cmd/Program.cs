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
            var operation = args[0];
            var title = args[1];
            var path = args[2];
            
            Console.WriteLine("ddSpelunker started.");

            var rootPath = path;
            var outputFileName = @"U:\content.txt";
            var diskTitle = title;

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
                if (!db.DiskDrives.Any(dd => dd.Title == diskTitle))
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
                else
                {
                    Console.WriteLine("Disk already exists in DB");
                }
            }
            
            File.WriteAllLines(outputFileName, outputContent);

            Console.WriteLine("ddSpelunker ended.");
        }
    }
}