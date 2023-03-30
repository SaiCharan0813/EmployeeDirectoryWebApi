using EmployeeDirectoryApp.Models;
using ServiceLibrary.Context;

namespace EmployeeDirectoryApp.Services
{
    public class OfficeService
    {

        private readonly EmployeeDirectoryContext _dbContext;
        public OfficeService(EmployeeDirectoryContext dbContext) : base()
        {
            _dbContext = dbContext;
        }
        public Office AddOffice(string name)
        {
            Office office = new Office()
            {
                OfficeName = name,
            };
            _dbContext.Offices.Add(office);
            _dbContext.SaveChanges();
            return office;
        }
    }
}
