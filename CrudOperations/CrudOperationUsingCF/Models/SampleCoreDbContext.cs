using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using CrudOperationUsingCF.Models;

namespace CrudOperationUsingCF.Models
{
    public class SampleCoreDbContext : DbContext
    {
        public SampleCoreDbContext()
        {
        }

        public SampleCoreDbContext(DbContextOptions<SampleCoreDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-UOENECT\\SQLEXPRESS;Database=SampleCFCoreDB;Trusted_Connection=True;");
            }
        }

        public DbSet<Employee> Employees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(emp =>
            {
                //
                emp.HasKey(e => e.Id);

                emp.Property(e => e.EmployeeName).IsRequired().HasMaxLength(50);

                emp.Property(e => e.EmployeeSalary).IsRequired().HasColumnType("decimal(18, 2)");

                emp.Property(e => e.IsActive).IsRequired();

                //using Fluent api
                emp.HasOne(e => e.Department)
                .WithMany(emp => emp.Employees)
                .HasForeignKey(emp => emp.FKDeptId).OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<Department>(dept =>
            {
                dept.HasKey(d => d.Id);
                dept.Property(d => d.DepartmentName).IsRequired().HasMaxLength(100);
                dept.Property(d => d.IsActive).IsRequired();

            });

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<CrudOperationUsingCF.Models.Department> Department { get; set; }

    }
}
