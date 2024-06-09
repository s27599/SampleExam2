using Microsoft.EntityFrameworkCore;

namespace SampleExam2.Models;

public class MusicianDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    protected MusicianDbContext()
    {
    }

    public MusicianDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Musician> Musicians { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Label> Labels { get; set; }
    public DbSet<Song> Songs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MusicianDbContext).Assembly);
    }
}