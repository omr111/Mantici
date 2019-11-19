using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Mantici.Entities.Models.Mapping
{
    public class reviewMap : EntityTypeConfiguration<review>
    {
        public reviewMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.comment)
                .IsRequired();

            this.Property(t => t.visitorName)
                .HasMaxLength(50);

            this.Property(t => t.visitorSurname)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("reviews");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.comment).HasColumnName("comment");
            this.Property(t => t.userID).HasColumnName("userID");
            this.Property(t => t.visitorName).HasColumnName("visitorName");
            this.Property(t => t.visitorSurname).HasColumnName("visitorSurname");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.reviews)
                .HasForeignKey(d => d.userID);

        }
    }
}
