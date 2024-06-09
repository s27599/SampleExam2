using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleExam2.Models;

namespace SampleExam2.Configurations;

public class LabelConfiguration :IEntityTypeConfiguration<Label>
{
    public void Configure(EntityTypeBuilder<Label> builder)
    {
        builder.HasKey(p => p.IdLabel);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
    }
}