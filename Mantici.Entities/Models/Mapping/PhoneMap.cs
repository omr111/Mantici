using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Mantici.Entities.Models.Mapping
{
    public class PhoneMap : EntityTypeConfiguration<Phone>
    {
        public PhoneMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.phone1)
                .IsRequired()
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("Phones");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.phone1).HasColumnName("phone");

            // Relationships
            this.HasRequired(t => t.CompanyInformation)
                .WithMany(t => t.Phones)
                .HasForeignKey(d => d.CompanyID);

        }
    }
}
