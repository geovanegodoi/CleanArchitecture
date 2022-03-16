using CleanIntegration.Core.ReclameAqui.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanIntegration.Infrastructure.ReclameAqui.EFDbContext
{
    public class ReclameAquiDbContext : DbContext
    {
        public DbSet<ExecutionRecord> ExecutionRecords { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
