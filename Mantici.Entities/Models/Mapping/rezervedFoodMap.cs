using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Mantici.Entities.Models.Mapping
{
    public class rezervedFoodMap : EntityTypeConfiguration<rezervedFood>
    {
        public rezervedFoodMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("rezervedFoods");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.productID).HasColumnName("productID");
            this.Property(t => t.count).HasColumnName("count");

            // Relationships
            this.HasRequired(t => t.Product)
                .WithMany(t => t.rezervedFoods)
                .HasForeignKey(d => d.productID);

        }
    }
}
