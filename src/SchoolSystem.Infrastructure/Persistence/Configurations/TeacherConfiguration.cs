using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSystem.Domain.Entities;
using SchoolSystem.Domain.Enums;

namespace SchoolSystem.Infrastructure.Persistence.Configurations;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.ToTable("Teachers");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.LastName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.Email)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasIndex(t => t.Email)
            .IsUnique();

        builder.Property(t => t.PhoneNumber)
            .HasMaxLength(20);

        builder.Property(t => t.Subject)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.Gender)
            .HasConversion<int>();

        builder.Property(t => t.Status)
            .HasConversion<int>()
            .HasDefaultValue(TeacherStatus.Active);

        builder.HasMany(t => t.Students)
            .WithOne(s => s.Teacher)
            .HasForeignKey(s => s.TeacherId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
