using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace product.Models
{
    public class DBp : DbContext
    {
        public DBp(DbContextOptions<DBp> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<productmodel> products { get; set; }
    }
}
