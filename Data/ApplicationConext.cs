using Microsoft.EntityFrameworkCore;
using MvcCrud.Models;

namespace MvcCrud.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext>options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
    
    }
}
