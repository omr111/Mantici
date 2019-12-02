using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Mantici.Entities.Models.Mapping
{
    public class sliderProductMap : EntityTypeConfiguration<sliderProduct>
    {
        public sliderProductMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("sliderProduct");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.productId).HasColumnName("productId");
        }
    }
}
