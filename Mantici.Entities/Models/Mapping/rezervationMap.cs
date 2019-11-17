using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Mantici.Entities.Models.Mapping
{
    public class rezervationMap : EntityTypeConfiguration<rezervation>
    {
        public rezervationMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("rezervations");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.rezerveFoodID).HasColumnName("rezerveFoodID");
            this.Property(t => t.rezerveDate).HasColumnName("rezerveDate");
            this.Property(t => t.personCount).HasColumnName("personCount");

            // Relationships
            this.HasRequired(t => t.rezervedFood)
                .WithMany(t => t.rezervations)
                .HasForeignKey(d => d.rezerveFoodID);

        }
    }
}
