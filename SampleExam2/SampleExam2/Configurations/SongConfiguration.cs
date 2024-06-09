using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleExam2.Models;

namespace SampleExam2.Configurations;

public class SongConfiguration :IEntityTypeConfiguration<Song>
{
    public void Configure(EntityTypeBuilder<Song> builder)
    {
     
        builder.HasKey(p => p.IdSong);
        builder.Property(p => p.Title).IsRequired().HasMaxLength(30);
        builder.Property(p => p.Duration).IsRequired();
    }
}