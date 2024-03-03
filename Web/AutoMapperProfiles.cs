using AutoMapper;
using HumanCapitalManagement.Data.Models;
using HumanCapitalManagement.Models.Admin.Employees;
using HumanCapitalManagement.Models.Departments;
using HumanCapitalManagement.Models.Employees;

namespace HumanCapitalManagement.Web
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Employee, AdminEmployeesListingModel>()
                .ForMember(x => x.DepartmentName,
                    src => src.MapFrom(dest => dest.Department.Name));
            
            CreateMap<Employee, EmployeesListingModel>()
                .ForMember(x => x.DepartmentName,
                    src => src.MapFrom(dest => dest.Department.Name));
            CreateMap<Employee, CreateEmployeeFormModel>();

            CreateMap<Department, DepartmentsListingModel>();
        }
    }
}
