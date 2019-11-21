using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Mantici.Entities.Models.Mapping
{
    public class CompanyInformationMap : EntityTypeConfiguration<CompanyInformation>
    {
        public CompanyInformationMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.companyName)
                .HasMaxLength(50);

            this.Property(t => t.companyLogo)
                .HasMaxLength(150);

            this.Property(t => t.email)
                .HasMaxLength(70);

            this.Property(t => t.companyAddress)
                .HasMaxLength(250);

            this.Property(t => t.companyPicturePath)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("CompanyInformations");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.companyName).HasColumnName("companyName");
            this.Property(t => t.companyAbout).HasColumnName("companyAbout");
            this.Property(t => t.companyLogo).HasColumnName("companyLogo");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.companyAddress).HasColumnName("companyAddress");
            this.Property(t => t.companyPicturePath).HasColumnName("companyPicturePath");
        }
    }
}
