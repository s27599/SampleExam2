using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleExam2.Models;

namespace SampleExam2.Configurations;

public class AlbumConfiguration :IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> builder)
    {
        builder.HasKey(p => p.IdAlbum);
        builder.Property(p => p.AlbumName).IsRequired().HasMaxLength(30);
        builder.Property(p => p.ReleaseDate).IsRequired();
    }
}