using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UTunes.Core.Entities;

namespace UTunes.Infrastructure.Database.DatabaseConfiguration
{
    public class SongEntityConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Artist).IsRequired();
            builder.HasOne(x => x.Album)
                .WithMany(x => x.Songs)
                .HasForeignKey(x => x.AlbumId);
            builder.Property(x => x.Price).IsRequired();

            builder.HasData(new Song
            {
                Name = "Don't go breaking my heart",
                Artist = "Backstreet boys",
                AlbumId = 1,
                Id = 1,
                Price= 3,
            },
            new Song
            {
                Name = "Nobody else",
                Artist = "Backstreet boys",
                AlbumId = 1,
                Id = 2,
                Price = 12
            },
            new Song
            {
                Name = "Breathe",
                Artist = "Backstreet boys",
                AlbumId = 1,
                Id = 3,
                Price = 24
            },
            new Song
            {
                Name = "New love",
                Artist = "Backstreet boys",
                AlbumId = 1,
                Id = 4,
                Price= 30
            });

        }
    }
}

