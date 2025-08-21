using Microsoft.EntityFrameworkCore;

namespace testFullStack.Models
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Servicio> Servicio { get; set; }

    }
}
