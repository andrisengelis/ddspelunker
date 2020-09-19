using System;
using System.Collections.Generic;
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
            
            var rootPath = path;
            var diskTitle = title;
            
            Console.WriteLine("ddSpelunker started.");

            switch (operation)
            {
                case "add":
                    AddToDb(diskTitle, rootPath);
                    break;
                case "delete":
                    DeleteDdFromDb(diskTitle);
                    break;
                case "update":
                    break;
                default:
                    break;
            }
            
            Console.WriteLine("ddSpelunker ended.");
        }

        private static void AddToDb(string diskTitle, string rootPath)
        {
            IDiskDrive diskDrive = new FileSystemDrive(rootPath);

            Spelunker ddSpelunker = new Spelunker(diskDrive);

            ddSpelunker.SpelunkDd();

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

        }

        private static void DeleteDdFromDb(string diskTitle)
        {
            using (var db = new SpelunkerContext())
            {
                var disk = db.DiskDrives.FirstOrDefault(dd => dd.Title == diskTitle);

                if (disk != null)
                {
                    disk.Files.RemoveAll(f => f.DiskDriveId == disk.DiskDriveId);
                    db.DiskDrives.Remove(disk);
                }
                else
                {
                    Console.WriteLine("No disk found in db.");
                }

                db.SaveChanges();
            }
        }
    }
}