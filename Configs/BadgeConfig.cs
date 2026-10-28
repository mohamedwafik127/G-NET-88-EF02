using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp12
{
    public class BadgeConfig : IEntityTypeConfiguration<Badge>
    {
        public void Configure(EntityTypeBuilder<Badge> builder)
        {
            builder.ToTable("Badges");
            builder.Property(b => b.BadgeNumber).IsRequired();
            builder.HasIndex(b => b.BadgeNumber).IsUnique();
            builder.Property(b => b.IssuedOn).IsRequired();
            builder.Property(b => b.Tier).IsRequired().HasConversion<string>().HasMaxLength(15);
            builder.HasOne(b => b.Attendee).WithOne(b => b.Badge)
                   .HasForeignKey<Badge>(b => b.AttendeeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
