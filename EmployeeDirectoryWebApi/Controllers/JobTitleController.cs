using Microsoft.AspNetCore.Mvc;
using EmployeeDirectoryApp.Models;
using EmployeeDirectoryApp.Services;
using ServiceLibrary.Context;

namespace EmployeeDirectoryApp.Controllers
{
    public class JobTitleController : Controller
    {
        private readonly EmployeeDirectoryContext _dbContext;
        public JobTitleController(EmployeeDirectoryContext dbContext) : base()
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public JobTitle Post(string name)
        {
            JobTitleService jobTitleService = new JobTitleService(_dbContext);
            return jobTitleService.AddJobTitle(name);
        }
    }
}
