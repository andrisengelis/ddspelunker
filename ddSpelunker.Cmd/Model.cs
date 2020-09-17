using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ddSpelunker.Cmd
{
    public class SpelunkerContext : DbContext
    {
        public DbSet<DiskDrive> DiskDrives { get; set; }
        public DbSet<NuggetFile> Files { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite("Data Source = nuggets.db");
    }

    public class DiskDrive
    {
        public int DiskDriveId { get; set; }
        public string Title { get; set; }
        
        public List<NuggetFile> Files { get; } = new List<NuggetFile>();
    }

    public class NuggetFile
    {
     public int NuggetFileId { get; set; }
     public string Title { get; set; }
     public string Path { get; set; }
     
     public int DiskDriveId { get; set; }
     public DiskDrive DiskDrive { get; set; }
    }
}