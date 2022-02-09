using Microsoft.EntityFrameworkCore;

namespace PlaylistsApi.Data;

public class PlaylistsDataContext : DbContext
{
    public PlaylistsDataContext(DbContextOptions<PlaylistsDataContext> options):base(options)
    {

    }

    public DbSet<PlaylistItem>? Playlists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlaylistItem>()
            .HasData(
                new PlaylistItem {  Id = 1, Title = "Blue Monday", Artist = "New Order", Album="12 Inch Single", YearReleased=1983},
                new PlaylistItem { Id = 2, Title = "The Final Countdown", Artist="Europe"}

            );
    }
}

public class PlaylistItem
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string? Artist { get; set; }
    public string? Album { get; set; }
    public int? YearReleased { get; set; }
}
