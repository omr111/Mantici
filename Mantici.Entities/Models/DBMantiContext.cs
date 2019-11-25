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

        public DbSet<banner> banners { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<BranchesApplication> BranchesApplications { get; set; }
        public DbSet<BranchPhone> BranchPhones { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CompanyInformation> CompanyInformations { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<review> reviews { get; set; }
        public DbSet<rezervation> rezervations { get; set; }
        public DbSet<rezervedFood> rezervedFoods { get; set; }
        public DbSet<roleOfUser> roleOfUsers { get; set; }
        public DbSet<role> roles { get; set; }
        public DbSet<service> services { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new bannerMap());
            modelBuilder.Configurations.Add(new BranchMap());
            modelBuilder.Configurations.Add(new BranchesApplicationMap());
            modelBuilder.Configurations.Add(new BranchPhoneMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CompanyInformationMap());
            modelBuilder.Configurations.Add(new PhoneMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new reviewMap());
            modelBuilder.Configurations.Add(new rezervationMap());
            modelBuilder.Configurations.Add(new rezervedFoodMap());
            modelBuilder.Configurations.Add(new roleOfUserMap());
            modelBuilder.Configurations.Add(new roleMap());
            modelBuilder.Configurations.Add(new serviceMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new userMap());
        }
    }
}
