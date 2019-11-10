using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Mantici.Entities.Models.Mapping
{
    public class BranchPhoneMap : EntityTypeConfiguration<BranchPhone>
    {
        public BranchPhoneMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.BranchPhone1)
                .IsRequired()
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("BranchPhones");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.BranchPhone1).HasColumnName("BranchPhone");
            this.Property(t => t.BranchID).HasColumnName("BranchID");

            // Relationships
            this.HasRequired(t => t.Branch)
                .WithMany(t => t.BranchPhones)
                .HasForeignKey(d => d.BranchID);

        }
    }
}
