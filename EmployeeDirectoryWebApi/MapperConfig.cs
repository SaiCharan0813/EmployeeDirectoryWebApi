using AutoMapper;

using EmployeeDirectoryApp.Models;
using EmployeeDirectoryApp.ModelDT;

namespace EmployeeDirectoryApp
{
    public class MapperConfig:Profile
    {
        public  MapperConfig()
        {
           //To get
            CreateMap<Employee, EmployeeDT>()
     
            //To post
                .ForMember(dest => dest.ContactNumber, act => act.MapFrom(src => src.CellNumber));

            CreateMap<EmployeeDT, Employee>()
                .ForMember(dest => dest.CellNumber, act => act.MapFrom(src => src.ContactNumber));              
        }
    }
}
