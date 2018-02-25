using AngularCoreDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace AngularCoreDemo.DAL
{
    public class DbsContext : DbContext
    {
        public DbsContext(DbContextOptions<DbsContext> options) : base(options)
        { }

        public DbSet<Value> Values { get; set; }
    }
}