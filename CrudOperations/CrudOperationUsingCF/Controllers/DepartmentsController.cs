using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudOperationUsingCF.Models;
using CrudOperationUsingCF.Repositories;

namespace CrudOperationUsingCF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        //private readonly SampleCoreDbContext _context;

        //public DepartmentsController(SampleCoreDbContext context)
        //{
        //    _context = context;
        //}

        //private readonly DepartmentRepository _deptrepo;
        //public DepartmentsController()
        //{
        //    _deptrepo = new DepartmentRepository();
        //}

        private readonly IDepartmentRepository _deptrepo;
        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            _deptrepo = departmentRepository;
        }


        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartment()
        {
            // return await _context.Department.ToListAsync();
            return _deptrepo.GetDepartments();
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            var department = _deptrepo.GetDepartment(id);  //await _context.Department.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }
            return department;
        }

        // PUT: api/Departments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }

            //_context.Entry(department).State = EntityState.Modified;

            try
            {
                _deptrepo.UpdateDept(department);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Departments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Department department)
        {
            //_context.Department.Add(department);
            //await _context.SaveChangesAsync();
            _deptrepo.InsertDept(department);

            return CreatedAtAction("GetDepartment", new { id = department.Id }, department);
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Department>> DeleteDepartment(int id)
        {
            //var department = await _context.Department.FindAsync(id);
            //if (department == null)
            //{
            //    return NotFound();
            //}

            //_context.Department.Remove(department);
            //await _context.SaveChangesAsync();

           var department= _deptrepo.DeleteDept(id);
            return department;
        }

        private bool DepartmentExists(int id)
        {
            // return _context.Department.Any(e => e.Id == id);
            return _deptrepo.DepartmentExists(id);
        }
    }
}
