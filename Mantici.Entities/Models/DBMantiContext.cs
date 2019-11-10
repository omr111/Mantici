using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Mantici.Entities.Models.Mapping;

namespace Mantici.Entities.Models
{
    public partial class DBMantiContext : DbContext
    {
        static DBMantiContext()
        {
            Database.SetInitializer<DBMantiContext>(null);
        }

        public DBMantiContext()
            : base("Name=DBMantiContext")
        {
        }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<BranchPhone> BranchPhones { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CompanyInformation> CompanyInformations { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BranchMap());
            modelBuilder.Configurations.Add(new BranchPhoneMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CompanyInformationMap());
            modelBuilder.Configurations.Add(new PhoneMap());
            modelBuilder.Configurations.Add(new ProductPictureMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
        }
    }
}
