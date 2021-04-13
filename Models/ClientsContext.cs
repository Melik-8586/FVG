using Microsoft.EntityFrameworkCore;

namespace Api_fvg.Models
{
    public class ClientsContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public ClientsContext(DbContextOptions<ClientsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
