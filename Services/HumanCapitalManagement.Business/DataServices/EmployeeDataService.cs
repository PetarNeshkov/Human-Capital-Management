using HumanCapitalManagement.Business.DataServices.Interfaces;
using HumanCapitalManagement.Common.Data;
using HumanCapitalManagement.Data;
using HumanCapitalManagement.Data.Models;

namespace HumanCapitalManagement.Business.DataServices;

public class EmployeeDataService(HumanCapitalManagementDbContext db) 
    : DataService<Employee>(db), IEmployeeDataService
{
    
}