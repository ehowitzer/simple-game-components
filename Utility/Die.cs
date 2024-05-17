namespace Utility
{
    public class Die
	{
		private uint _sideCount;
		private Random _random = new Random();

		public uint SideCount
		{
			get { return _sideCount; }
			set { _sideCount = value; }
		}

		private Die()
		{
		}

		public Die(uint sides)
		{
			if (sides < 2)
			{
				throw new ArgumentOutOfRangeException("sides", "A die must have at least 2 sides");
			}

			this.SideCount = sides;
		}

		public uint Roll()
		{
			return (uint)_random.Next((int)_sideCount) + 1;
		}
	}
}
