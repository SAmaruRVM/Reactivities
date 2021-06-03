using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence 
{
    public sealed class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
                : base (options) {}

        public DbSet<Activity> Activities { get; set; }
    }
}

