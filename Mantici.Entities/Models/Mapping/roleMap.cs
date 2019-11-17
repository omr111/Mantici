using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Mantici.Entities.Models.Mapping
{
    public class roleMap : EntityTypeConfiguration<role>
    {
        public roleMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id, t.role1 });

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.role1)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("roles");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.role1).HasColumnName("role");

            // Relationships
            this.HasRequired(t => t.roleOfUser)
                .WithMany(t => t.roles)
                .HasForeignKey(d => d.id);

        }
    }
}
