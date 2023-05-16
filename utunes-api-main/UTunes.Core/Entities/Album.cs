using System;
namespace UTunes.Core.Entities
{
	public class Album
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Artist { get; set; }

		public string Review { get; set; }

		public ICollection<Song> Songs { get; set; }
        public int Likes { get; set; }
    }
}

