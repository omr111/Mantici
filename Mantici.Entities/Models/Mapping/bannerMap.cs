using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Mantici.Entities.Models.Mapping
{
    public class bannerMap : EntityTypeConfiguration<banner>
    {
        public bannerMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.bannerPath)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.altName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.text)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("banners");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.bannerPath).HasColumnName("bannerPath");
            this.Property(t => t.altName).HasColumnName("altName");
            this.Property(t => t.text).HasColumnName("text");
        }
    }
}
