using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Mantici.Entities.Models.Mapping
{
    public class PictureMap : EntityTypeConfiguration<Picture>
    {
        public PictureMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.smallPath)
                .HasMaxLength(150);

            this.Property(t => t.bigPath)
                .HasMaxLength(150);

            this.Property(t => t.pictureAlt)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Pictures");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.smallPath).HasColumnName("smallPath");
            this.Property(t => t.bigPath).HasColumnName("bigPath");
            this.Property(t => t.pictureAlt).HasColumnName("pictureAlt");
        }
    }
}
