using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CrudOperationsWithExistingDb.Models
{
    public partial class SampleCoreDBContext : DbContext
    {
        public SampleCoreDBContext()
        {
        }

        public SampleCoreDBContext(DbContextOptions<SampleCoreDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-UOENECT\\SQLEXPRESS;Database=SampleCoreDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.PkdepartmentId);

                entity.Property(e => e.PkdepartmentId).HasColumnName("PKDepartmentId");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.PkemployeeId);

                entity.Property(e => e.PkemployeeId).HasColumnName("PKEmployeeId");

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeSalary).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FkdeptId).HasColumnName("FKDeptId");

                entity.Property(e => e.EmployeeAddress).HasMaxLength(250).HasDefaultValue("");

                entity.HasOne(d => d.Fkdept)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.FkdeptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Department");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
