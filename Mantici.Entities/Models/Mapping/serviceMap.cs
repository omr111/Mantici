using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Mantici.Entities.Models.Mapping
{
    public class serviceMap : EntityTypeConfiguration<service>
    {
        public serviceMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.serviceIcon)
                .HasMaxLength(150);

            this.Property(t => t.serviceName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.serviceInfo)
                .IsRequired()
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("services");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.serviceIcon).HasColumnName("serviceIcon");
            this.Property(t => t.serviceName).HasColumnName("serviceName");
            this.Property(t => t.serviceInfo).HasColumnName("serviceInfo");
        }
    }
}
