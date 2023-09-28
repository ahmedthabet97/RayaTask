using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace TaskContext
{
    public class RayaContext : IdentityDbContext<RayaUser>
    {
       
        public RayaContext(DbContextOptions<RayaContext> opt) : base(opt)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=DB;Integrated Security=True");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}