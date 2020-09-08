namespace ddSpelunker.Domain
{
	public class FileSystemDrive : IDiskDrive
	{
		public string RootPath { get; set; }

		public FileSystemDrive(string rootPath)
		{
			RootPath = rootPath;
		}
	}
}
