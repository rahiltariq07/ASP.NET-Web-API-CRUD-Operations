using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WorkerAdminPortal.Data;

namespace WorkerAdminPortal.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Create a new instance of DbContextOptionsBuilder with the appropriate DbContext type
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // Configure the options for the DbContext (e.g., SQL Server with a connection string)
            optionsBuilder.UseSqlServer("Server=RAHIL\\SQLEXPRESS01;Database=WorkersDb;Trusted_connection=true;TrustServerCertificate=true;");

            // Return a new instance of your ApplicationDbContext with the configured options
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
