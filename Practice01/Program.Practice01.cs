using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Practice01
{
    partial class Program
    {
        public class Practice01:DbContext
        {
            public DbSet<Person> People { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("server =.; initial catalog = Practice01; integrated security = true");
            }
            public override int SaveChanges()
            {
                var entities = ChangeTracker.Entries();
                foreach (var item in entities)
                {
                    if (item.State == EntityState.Added || item.State == EntityState.Modified) 
                    {
                        var stringProperty = item.Properties.Where(a => a.Metadata.ClrType == typeof(string));
                        foreach (var itemlist in stringProperty)
                        {
                            itemlist.CurrentValue = itemlist.CurrentValue.ToString().Replace('\u06CC', '\u064A').Replace('\u0643', '\u06A9');
                        }
                    }
                }
                return base.SaveChanges();
            }
        }
    }
}
