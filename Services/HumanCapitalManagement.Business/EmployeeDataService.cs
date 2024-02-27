using HumanCapitalManagement.Business.Interfaces;
using HumanCapitalManagement.Common.Data;
using HumanCapitalManagement.Data;
using HumanCapitalManagement.Data.Models;

namespace HumanCapitalManagement.Business;

public class EmployeeDataService(HumanCapitalManagementDbContext db) 
    : DataService<Employee>(db), IEmployeeDataService
{
    
}