using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp12
{
    public class OrganizerConfig : IEntityTypeConfiguration<OrganizerProfile>
    {
        public void Configure(EntityTypeBuilder<OrganizerProfile> builder)
        {
            builder.ToTable("OrganizerProfiles");
            builder.HasKey(b => b.OrganizerId);
            builder.Property(b => b.Biography).IsRequired(false).HasMaxLength(1000);
            builder.Property(b => b.WebsiteUrl).IsRequired(false).HasMaxLength(200);
            builder.Property(b => b.LogoUrl).IsRequired(false).HasMaxLength(200);
            builder.HasOne(b => b.Organizer).WithOne(b => b.Profile)
                   .HasForeignKey<OrganizerProfile>(b => b.OrganizerId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
