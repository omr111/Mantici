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
            this.Property(t => t.CustomerName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.surname)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.description)
                .IsRequired();

            this.Property(t => t.phoneNo)
                .IsRequired()
                .HasMaxLength(11);

            // Table & Column Mappings
            this.ToTable("rezervations");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.CustomerName).HasColumnName("CustomerName");
            this.Property(t => t.surname).HasColumnName("surname");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.phoneNo).HasColumnName("phoneNo");
            this.Property(t => t.rezerveDate).HasColumnName("rezerveDate");
            this.Property(t => t.personCount).HasColumnName("personCount");
            this.Property(t => t.showed).HasColumnName("showed");
        }
    }
}
