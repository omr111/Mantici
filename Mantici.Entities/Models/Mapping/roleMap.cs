using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Mantici.Entities.Models.Mapping
{
    public class roleMap : EntityTypeConfiguration<role>
    {
        public roleMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.roleName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("roles");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.roleName).HasColumnName("roleName");
        }
    }
}
