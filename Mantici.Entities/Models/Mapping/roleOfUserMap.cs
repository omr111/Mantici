using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Mantici.Entities.Models.Mapping
{
    public class roleOfUserMap : EntityTypeConfiguration<roleOfUser>
    {
        public roleOfUserMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("roleOfUsers");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.userID).HasColumnName("userID");
            this.Property(t => t.roleID).HasColumnName("roleID");

            // Relationships
            this.HasRequired(t => t.role)
                .WithMany(t => t.roleOfUsers)
                .HasForeignKey(d => d.roleID);
            this.HasRequired(t => t.user)
                .WithMany(t => t.roleOfUsers)
                .HasForeignKey(d => d.userID);

        }
    }
}
