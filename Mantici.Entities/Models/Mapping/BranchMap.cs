using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Mantici.Entities.Models.Mapping
{
    public class BranchMap : EntityTypeConfiguration<Branch>
    {
        public BranchMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.BranchName)
                .IsRequired()
                .HasMaxLength(70);

            this.Property(t => t.BranchAdress)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.BranchPicture)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Branches");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.BranchName).HasColumnName("BranchName");
            this.Property(t => t.BranchAdress).HasColumnName("BranchAdress");
            this.Property(t => t.BranchPicture).HasColumnName("BranchPicture");
        }
    }
}
