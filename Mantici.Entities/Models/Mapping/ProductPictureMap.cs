using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Mantici.Entities.Models.Mapping
{
    public class ProductPictureMap : EntityTypeConfiguration<ProductPicture>
    {
        public ProductPictureMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.productPicturePath)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.pictureAlt)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ProductPictures");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.productPicturePath).HasColumnName("productPicturePath");
            this.Property(t => t.pictureAlt).HasColumnName("pictureAlt");
            this.Property(t => t.productID).HasColumnName("productID");

            // Relationships
            this.HasRequired(t => t.Product)
                .WithMany(t => t.ProductPictures)
                .HasForeignKey(d => d.productID);

        }
    }
}
