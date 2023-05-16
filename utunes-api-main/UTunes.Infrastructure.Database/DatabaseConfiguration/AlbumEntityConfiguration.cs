using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UTunes.Core.Entities;

namespace UTunes.Infrastructure.Database.DatabaseConfiguration
{
	public class AlbumEntityConfiguration : IEntityTypeConfiguration<Album>
	{
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Artist).IsRequired();
            builder.Property(x => x.Review).IsRequired();
            builder.Property(x => x.Likes).IsRequired();

            builder.HasMany(x => x.Songs)
                .WithOne(x => x.Album)
                .HasForeignKey(x => x.AlbumId);

            builder.HasData(new Album
            {
                Name = "DNA",
                Artist = "Backstreet Boys",
                Review = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean sed leo elit. Nullam tellus ipsum, fringilla quis ex vitae, mattis rutrum felis. Duis venenatis faucibus turpis, at tincidunt arcu bibendum ac. Vestibulum eget placerat libero, nec tempus ipsum. Sed elit libero, luctus non dapibus et, sagittis a tellus. Ut suscipit porta vestibulum. Mauris justo velit, pretium at efficitur nec, posuere non massa. Proin quis aliquet quam. Maecenas malesuada mauris ex, eu sollicitudin quam laoreet ut. Sed mollis enim dolor, eu malesuada dui aliquet ut. Quisque rhoncus augue urna, at volutpat justo ultrices et. Vivamus maximus quam non nisl placerat varius. Nam mollis erat ullamcorper diam efficitur, molestie feugiat urna finibus. Phasellus dignissim interdum neque sed dictum.",
                Id = 1,
                Likes= 0,
            });
        }
    }
}

