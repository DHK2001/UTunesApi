using System;
namespace UTunes.Core.Entities
{
	public class AlbumCreateDto
	{

		public string Name { get; set; }

		public string Artist { get; set; }

		public string Review { get; set; }
        public int Likes { get; set; }

    }
}

