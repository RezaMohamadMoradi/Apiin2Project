using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Category2.Models
{
    public class DB : DbContext
    {
        public DB(DbContextOptions <DB> options) : base (options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Categoryes> Categoryes { get; set; }

    }
}
