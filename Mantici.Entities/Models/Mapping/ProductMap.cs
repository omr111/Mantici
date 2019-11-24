using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Mantici.Entities.Models.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.caption)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.coverPicturePath)
                .HasMaxLength(150);

            this.Property(t => t.pictureAlt)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Products");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.caption).HasColumnName("caption");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.coverPicturePath).HasColumnName("coverPicturePath");
            this.Property(t => t.pictureAlt).HasColumnName("pictureAlt");
            this.Property(t => t.categoryID).HasColumnName("categoryID");
            this.Property(t => t.pictureID).HasColumnName("pictureID");
            this.Property(t => t.price).HasColumnName("price");

            // Relationships
            this.HasRequired(t => t.Category)
                .WithMany(t => t.Products)
                .HasForeignKey(d => d.categoryID);

        }
    }
}
