using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleExam2.Models;

namespace SampleExam2.Configurations;

public class MusicianConfiguration :IEntityTypeConfiguration<Musician>
{
    public void Configure(EntityTypeBuilder<Musician> builder)
    {
        builder.HasKey(p => p.idMusician);
        builder.Property(p =>p.FirstName).IsRequired().HasMaxLength(30);
        builder.Property(p =>p.LastName).IsRequired().HasMaxLength(40);
        builder.Property(p =>p.Nickname).HasMaxLength(50);
    }
}