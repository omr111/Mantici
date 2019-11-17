using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Mantici.Entities.Models.Mapping
{
    public class userMap : EntityTypeConfiguration<user>
    {
        public userMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.surname)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.nick)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.email)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.userPicturePath)
                .IsRequired()
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("users");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.surname).HasColumnName("surname");
            this.Property(t => t.nick).HasColumnName("nick");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.userPicturePath).HasColumnName("userPicturePath");
        }
    }
}
