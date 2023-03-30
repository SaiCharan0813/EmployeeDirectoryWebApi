using Microsoft.AspNetCore.Mvc;
using EmployeeDirectoryApp.Models;
using EmployeeDirectoryApp.Services;
using ServiceLibrary.Context;

namespace EmployeeDirectoryApp.Controllers
{
    public class OfficeController : Controller
    {
        private readonly EmployeeDirectoryContext _dbContext;
        public OfficeController(EmployeeDirectoryContext dbContext) : base()
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public Office Post(string name)
        {
            OfficeService officeService = new OfficeService(_dbContext);
            return officeService.AddOffice(name);
        }
    }
}