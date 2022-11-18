using Microsoft.EntityFrameworkCore;
using Engelstajn.Models;
namespace Engelstajn.Data
{
    public class DBWSAutoContext : DbContext
    {

        public DBWSAutoContext(DbContextOptions<DBWSAutoContext> options):base(options) { }

        //DBSet
        public DbSet<Auto> Autos { get; set; }

    }
}
