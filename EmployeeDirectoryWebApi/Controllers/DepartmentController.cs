using EmployeeDirectoryApp.DTO;
using EmployeeDirectoryApp.Models;
using EmployeeDirectoryApp.Services;
using Microsoft.AspNetCore.Mvc;
using ServiceLibrary.Context;

namespace EmployeeDirectoryApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly EmployeeDirectoryContext _dbContext;
        public DepartmentController(EmployeeDirectoryContext dbContext) : base()
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public Department Post(string name)
        {
            DepartmentService departmentService = new DepartmentService(_dbContext);
            return departmentService.AddDepartment(name);
        }
    }
}
