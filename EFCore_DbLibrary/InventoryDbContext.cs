using InventoryModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCore_DbLibrary
{
    public class InventoryDbContext : DbContext
    {
        //Roll: adicionaesto
        private static IConfigurationRoot _configuration;

        public DbSet<Item> Items { get; set; }  // adicionó Roll
        //Add a default constructor if scaffolding is needed
        public InventoryDbContext() { }
        //Add the complex constructor for allowing Dependency Injection
        public InventoryDbContext(DbContextOptions options) : base(options)
        {
            //intentionally empty.
        }
        /*EsteCodigo*/
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=InventoryManagerDb; Trusted_Connection = True");
        //    }
        //}
        /*EsteCodigo*/

        //Roll: adicionaesto
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true,
                reloadOnChange: true);
                _configuration = builder.Build();
                var cnstr = _configuration.GetConnectionString("InventoryManager");
                optionsBuilder.UseSqlServer(cnstr);
            }
        }

    }

}
