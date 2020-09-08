namespace ddSpelunker.Domain
{
	public class Spelunker
	{
		private readonly IDiskDrive _diskDrive;

		public Spelunker(IDiskDrive diskDrive)
		{
			_diskDrive = diskDrive;
		}
	}
}
