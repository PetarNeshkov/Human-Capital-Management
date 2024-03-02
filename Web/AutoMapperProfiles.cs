using AutoMapper;
using HumanCapitalManagement.Data.Models;
using HumanCapitalManagement.Models.Departments;
using HumanCapitalManagement.Models.Employees;

namespace HumanCapitalManagement.Web
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Employee, EmployeesViewModel>();
            CreateMap<Employee, CreateEmployeeFormModel>();

            CreateMap<Department, DepartmentsListingModel>();
        }
    }
}
