using Microsoft.EntityFrameworkCore;
using UTunes.Infrastructure.Database.DatabaseConfiguration;

namespace UTunes.Infrastructure.Database;
public class UTunesContext : DbContext
{
    public UTunesContext(DbContextOptions<UTunesContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AlbumEntityConfiguration());
        modelBuilder.ApplyConfiguration(new SongEntityConfiguration());
    }
}

