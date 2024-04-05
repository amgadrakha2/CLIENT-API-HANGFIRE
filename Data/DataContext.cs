using ClientApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientApp.Data
{
    public class DataContext : DbContext
    { 

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<StockData> Stocks { get; set; }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
     
                
        }
    }
}
