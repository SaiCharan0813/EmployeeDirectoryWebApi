using EmployeeDirectoryApp.Models;
using ServiceLibrary.Context;

namespace EmployeeDirectoryApp.Services
{
    public class DepartmentService
    {

        private readonly EmployeeDirectoryContext _dbContext;
        public DepartmentService(EmployeeDirectoryContext dbContext) : base()
        {
            _dbContext = dbContext;
        }
        public Department AddDepartment(string name)
        {
            Department department = new Department()
            {
                DepartmentName = name,
            };
            _dbContext.Departments.Add(department);
            _dbContext.SaveChanges();
            return department;
        }
    }
}
