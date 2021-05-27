using DotaGrid.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DotaGrid.DataAccess
{
    public class HeroContext : DbContext
    {

        /// <summary>
        /// Klassen som lager databasen, den forklarer også hvordan hero ser ut
        /// </summary>
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Mainattribute> MainAttributes { get; set; }
       
        public HeroContext(DbContextOptions<HeroContext> options) : base(options) { }


        /// <summary>
        /// Database connection
        /// </summary>
         public class HeroContextFactory : IDesignTimeDbContextFactory<HeroContext>
        {
            public HeroContext CreateDbContext(string[] args)
            {
                //local
                //var connection = @"Server=(localdb)\MSSQLLocalDB;Database=sjriis;Trusted_Connection=True;ConnectRetryCount=0";
                
                
                var connection = @"Server=donau.hiof.no;
                                 Database=sjriis;
                                 User id=sjriis;
                                 Password=a^4<A-U/;;
                                 MultipleActiveResultSets=True";
                

                var optionsBuilder = new DbContextOptionsBuilder<HeroContext>();
                optionsBuilder.UseSqlServer(connection, x => x.MigrationsAssembly("DotaGrid.DataAccess.Maintenance"));

                return new HeroContext(optionsBuilder.Options);
        
            }
        } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Mange til en forhold mainattribute -> heroes
            modelBuilder.Entity<Mainattribute>()
                .HasMany(m => m.Heroes)
                .WithOne(h => h.Mainattribute);

        }
    }
}
