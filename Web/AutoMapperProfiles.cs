using AutoMapper;
using HumanCapitalManagement.Business.Models;
using HumanCapitalManagement.Data.Models;
using HumanCapitalManagement.Web.Models.Departments;
using HumanCapitalManagement.Web.Models.Employees;

namespace HumanCapitalManagement.Web
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Employee, EmployeesViewModel>();
            CreateMap<Employee, CreateEmployeeFormModel>();

            CreateMap<Department, DepartmentsListingModel>();
            CreateMap<CreateEmployeeFormModel, EmployeesBusinessServiceModel>();
        }
    }
}
