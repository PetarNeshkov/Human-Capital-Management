using HumanCapitalManagement.Common.Data;
using HumanCapitalManagement.Common.Data.DependencyInjectionInterfaces;
using HumanCapitalManagement.Data.Models;

namespace HumanCapitalManagement.Business.Interfaces;

public interface IEmployeeDataService : IDataService<Employee>, ITransientService
{
}