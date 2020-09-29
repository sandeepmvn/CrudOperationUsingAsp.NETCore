using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using CrudOperationUsingCF.Models;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CrudOperationUsingCF.Repositories
{

    public interface IDepartmentRepository
    {
        List<Department> GetDepartments();
        Department GetDepartment(int id);
        void InsertDept(Department department);
        void UpdateDept(Department department);
        Department DeleteDept(int id);
        bool DepartmentExists(int id);

    }


    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly SampleCoreDbContext _dbContext;
        public DepartmentRepository(SampleCoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Department> GetDepartments()
        {
            //using (SampleCoreDbContext dbContext = new SampleCoreDbContext())
            //{
            //    return dbContext.Department.ToList();
            //}

            return _dbContext.Department.ToList();
        }


        public Department GetDepartment(int id)
        {
            //using (SampleCoreDbContext dbContext = new SampleCoreDbContext())
            //{
            //    return dbContext.Department.FirstOrDefault(x => x.Id == id);
            //}

            // return _dbContext.Department.FirstOrDefault(x => x.Id == id);
            try
            {
                var dept = _dbContext.Department.FirstOrDefault(x => x.Id == id);
                if (dept is null)
                    throw new ApplicationException("Dept record is not available");
                return dept;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public void InsertDept(Department department)
        {
            //using (SampleCoreDbContext dbContext = new SampleCoreDbContext())
            //{
            //    dbContext.Department.Add(department);
            //    dbContext.SaveChanges();
            //}

            try
            {
                _dbContext.Department.Add(department);
                _dbContext.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        public void UpdateDept(Department department)
        {
            //using (SampleCoreDbContext dbContext = new SampleCoreDbContext())
            //{
            //    dbContext.Department.Update(department);
            //    dbContext.SaveChanges();
            //}
            try
            {
                _dbContext.Department.Update(department);
                _dbContext.SaveChanges();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public Department DeleteDept(int id)
        {
            //using (SampleCoreDbContext dbContext = new SampleCoreDbContext())
            //{
            //    var dept = GetDepartment(id);
            //    dbContext.Department.Remove(dept);
            //    dbContext.SaveChanges();

            //    return dept;
            //}
            try
            {
                var dept = GetDepartment(id);
                _dbContext.Department.Remove(dept);
                _dbContext.SaveChanges();

                return dept;
            }
            catch(Exception)
            {
                throw;
            }
        }


        public bool DepartmentExists(int id)
        {
            //using (SampleCoreDbContext dbContext = new SampleCoreDbContext())
            //{
            //    return dbContext.Department.Any(e => e.Id == id);
            //}

            return _dbContext.Department.Any(e => e.Id == id);
        }

    }
}
