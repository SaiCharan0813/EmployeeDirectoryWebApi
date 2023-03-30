using EmployeeDirectoryApp.Models;
using ServiceLibrary.Context;

namespace EmployeeDirectoryApp.Services
{
    public class JobTitleService
    {

        private readonly EmployeeDirectoryContext _dbContext;
        public JobTitleService(EmployeeDirectoryContext dbContext) : base()
        {
            _dbContext = dbContext;
        }
        public JobTitle AddJobTitle(string name)
        {
            JobTitle jobTitle = new JobTitle()
            {
                JobTitleName = name,
            };
            _dbContext.JobTitles.Add(jobTitle);
            _dbContext.SaveChanges();
            return jobTitle;
        }
    }
}
