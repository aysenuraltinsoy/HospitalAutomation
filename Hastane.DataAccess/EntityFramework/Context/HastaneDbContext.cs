using Hastane.DataAccess.EntityFramework.Mapping;
using Hastane.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.DataAccess.EntityFramework.Context
{
    public class HastaneDbContext : DbContext 
    {
        public HastaneDbContext(DbContextOptions<HastaneDbContext> options):base(options)
        {

        }
     
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Admin> Admins { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdminMapping())
                .ApplyConfiguration(new EmployeeMapping());
            
            base.OnModelCreating(modelBuilder);
        }
        public class HastaneDbContextFactory : IDesignTimeDbContextFactory<HastaneDbContext>
        {
            public HastaneDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<HastaneDbContext>();
                optionsBuilder.UseSqlServer("Server=DESKTOP-ORUQO20;Database=NRM1HastaneDb;Trusted_Connection=True;TrustServerCertificate=True;");



                return new HastaneDbContext(optionsBuilder.Options);
            }
        }
    }
}
