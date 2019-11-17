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

            this.Property(t => t.coverPicture)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Products");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.caption).HasColumnName("caption");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.coverPicture).HasColumnName("coverPicture");
            this.Property(t => t.categoryID).HasColumnName("categoryID");
            this.Property(t => t.pictureID).HasColumnName("pictureID");
            this.Property(t => t.price).HasColumnName("price");

            // Relationships
            this.HasRequired(t => t.Category)
                .WithMany(t => t.Products)
                .HasForeignKey(d => d.categoryID);
            this.HasOptional(t => t.Picture)
                .WithMany(t => t.Products)
                .HasForeignKey(d => d.pictureID);

        }
    }
}
