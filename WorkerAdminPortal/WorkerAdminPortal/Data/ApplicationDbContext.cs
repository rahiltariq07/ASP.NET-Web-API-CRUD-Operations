using Microsoft.EntityFrameworkCore;
using WorkerAdminPortal.Models.Entities;

namespace WorkerAdminPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<Worker> Workers { get; set; }
    }
}
