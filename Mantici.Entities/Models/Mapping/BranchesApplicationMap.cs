using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Mantici.Entities.Models.Mapping
{
    public class BranchesApplicationMap : EntityTypeConfiguration<BranchesApplication>
    {
        public BranchesApplicationMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.nameSurname)
                .IsRequired()
                .HasMaxLength(70);

            this.Property(t => t.email)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.phoneNumber)
                .IsRequired()
                .HasMaxLength(11);

            this.Property(t => t.Address)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.message)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("BranchesApplications");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.nameSurname).HasColumnName("nameSurname");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.phoneNumber).HasColumnName("phoneNumber");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.message).HasColumnName("message");
        }
    }
}
