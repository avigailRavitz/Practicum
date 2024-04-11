using Microsoft.EntityFrameworkCore;
using Server.Core.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeInRole> EmployeeInRoles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
    

            modelBuilder.Entity<EmployeeInRole>()
                .HasKey(e => new { e.RoleId, e.EmployeeId });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=My_sql");
            optionsBuilder.LogTo((message) => Debug.Write(message));
        }


    }
}
