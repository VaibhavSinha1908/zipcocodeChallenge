using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ZipCoCodeChallenge.Models
{
    public class ZipPayContext : DbContext
    {
        public ZipPayContext(DbContextOptions<ZipPayContext> options)
           : base(options)
        {
        }

        public DbSet<AccountDetails> Accounts { get; set; }
        public DbSet<UserDetails> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal)))
            {
                property.Relational().ColumnType = "decimal(10, 2)";
            }


            base.OnModelCreating(modelBuilder);

        }
    }
}
