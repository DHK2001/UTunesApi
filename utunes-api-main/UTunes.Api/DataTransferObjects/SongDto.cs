using System;
namespace UTunes.Core.Entities
{
	public class SongDto
	{
        public int Id { get; set; }

        public string Name { get; set; }

        public string Artist { get; set; }

        public int AlbumId { get; set; }
        public int Price { get; set; }
    }
}

