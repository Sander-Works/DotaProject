using DotaGrid.model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DotaGrid.DataAccess
{
    public class HeroContext : DbContext
    {
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Mainattribute> MainAttributes { get; set; }
       

        public HeroContext(DbContextOptions<HeroContext> options) : base(options) { }
        /// <summary>
        /// Local Database
        /// </summary>
        /// 

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = "(localdb)\\MSSQLLocalDB",
                InitialCatalog = "sjriis",
                IntegratedSecurity = true
                /*
                / DataSource = "Donau.hiof.no",
                InitialCatalog = "sjriis",
                UserID = "sjriis",
                Password = "yT2>ahH6" /BYTT
                
            };

            optionsBuilder.UseSqlServer(builder.ConnectionString.ToString());
        }
            */

        
         public class HeroContextFactory : IDesignTimeDbContextFactory<HeroContext>
        {
            public HeroContext CreateDbContext(string[] args)
            {
                var connection = @"Server=(localdb)\MSSQLLocalDB;Database=sjriis;Trusted_Connection=True;ConnectRetryCount=0";
                
                /*
                var connection = @"Server=donau.hiof.no;
                                 Database=sjriis;
                                 User id=sjriis;
                                 Password=et4S3W9J;
                                 MultipleActiveResultSets=True";
                */

                var optionsBuilder = new DbContextOptionsBuilder<HeroContext>();
                optionsBuilder.UseSqlServer(connection, x => x.MigrationsAssembly("DotaGrid.DataContext.Migrations"));

                return new HeroContext(optionsBuilder.Options);
        
            }
 
       
        } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Mainattribute and Hero relationship
            modelBuilder.Entity<Mainattribute>()
                .HasMany(m => m.Heroes)
                .WithOne(h => h.Mainattribute);

        }
    }
}
