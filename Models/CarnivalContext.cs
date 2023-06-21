using System.Data.Entity;

namespace Carnival.Models
{
    public class CarnivalContext : DbContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodStallRelationship>().HasKey(p => new { p.FoodID, p.StallID });
        }

        public DbSet<Stall> Stalls { get; set; }
        public DbSet<Food_Product> FoodProducts { get; set; }
        public DbSet<FoodStallRelationship> FoodStallRelationships { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public System.Data.Entity.DbSet<Carnival.Models.Login> Logins { get; set; }

        public System.Data.Entity.DbSet<Carnival.Models.GetOrderLinq> GetOrderLinqs { get; set; }
    }
}