using AutoMapper;
using EmployeeDirectoryApp.DTO;
using EmployeeDirectoryApp.ModelDT;
using EmployeeDirectoryApp.Models;
using EmployeeDirectoryApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLibrary.Context;

namespace EmployeeDirectoryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly EmployeeDirectoryContext _dbContext;
        private IMapper _mapper;
        public ValuesController(EmployeeDirectoryContext dbContext,IMapper mapper) : base()
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public List<EmployeeDT> Get()
        {
            Services.User user = new Services.User(_dbContext,_mapper);
            return user.GetAllEmployees();
        }
        [HttpGet]
        [Route("{Email}")]
        public Employee Get(string EmailId)
        {
            Services.User user = new Services.User(_dbContext,_mapper);
            return user.GetEmployee(EmailId);
        }
        [HttpPost]
        public Employee Post(EmployeeDT employee)
        {
            Services.User user = new Services.User(_dbContext, _mapper);
            return user.Post(employee);
        }

        [HttpPut]
        public Employee Put([FromQuery]Guid EmployeeId ,[FromBody]EmployeeDT employee)
        {
            Services.User user = new Services.User(_dbContext, _mapper);
            return user.Put(EmployeeId, employee);
        }
        [HttpDelete]
        public void DeleteEmployee(string EmailId)
        {
            Services.User user = new Services.User(_dbContext, _mapper);
            user.DeleteEmployee(EmailId);
        }
        [HttpGet]
        [Route("Department/{Department}")]
        public List<Employee> GetEmployeeByDepartment(string DepartmentId)
        {
            Services.User user = new Services.User(_dbContext, _mapper);
            return user.GetEmployeesByDepartment(DepartmentId);
        }
        [HttpGet]
        [Route("Office/{Office}")]
        public List<Employee> GetEmployeeByOffice(string OfficeId)
        {
            Services.User user = new Services.User(_dbContext, _mapper);
            return user.GetEmployeesByOffice(OfficeId);
        }
        [HttpGet]
        [Route("JobTitle/{JobTitle}")]
        public List<Employee> GetEmployeeByJobTitle(string JobTitleId)
        {
            Services.User user = new Services.User(_dbContext, _mapper);
            return user.GetEmployeesByJobTitle(JobTitleId);
        }
        [HttpGet]
        [Route("api/[controller]/EmployeesDepartment")]
        public Dictionary<string, int> GetEmployeesCountByDepartment()
        {
            Services.User user = new Services.User(_dbContext, _mapper);
            return user.GetEmployeesCountByDepartment();
        }
        [HttpGet]
        [Route("api/[controller]/EmployeesOffice")]
        public Dictionary<string, int> GetEmployeesCountByOffice()
        {
            Services.User user = new Services.User(_dbContext, _mapper);
            return user.GetEmployeesCountByOffice();
        }
        [HttpGet]
        [Route("api/[controller]/EmployeesJobTitle")]
        public Dictionary<string, int> GetEmployeesCountByJobTitle()
        {
            Services.User user = new Services.User(_dbContext, _mapper);
            return user.GetEmployeesCountByJobTitle();
        }
        [HttpGet]
        [Route("api/[controller]/TotalDepartments")]
        public List<string> GetDepartmentNames()
        {
            Services.User user = new Services.User(_dbContext, _mapper);
            return user.GetDepartmentNames();
        }
        [HttpGet]
        [Route("api/[controller]/TotalOffices")]
        public List<string> GetOfficeNames()
        {
            Services.User user = new Services.User(_dbContext, _mapper);
            return user.GetOfficeNames();
        }
        [HttpGet]
        [Route("api/[controller]/TotalJobTitles")]
        public List<string> GetJobTitleNames()
        {
            Services.User user = new Services.User(_dbContext, _mapper);
            return user.GetJobTitleNames();
        }
    }
}
