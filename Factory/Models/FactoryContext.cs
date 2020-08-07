using Microsoft.EntityFrameworkCore;
namespace Factory.Models
{
  public class FactoryContext : DbContext
  {
    public virtual DbSet<Machine> Machines { get; set; }
    public DbSet<Technician> Technicians { get; set; }
    public DbSet<Qualification> Qualifications { get; set; }
    public FactoryContext(DbContextOptions options) : base(options) { }
  }
}