using AutoMapper;
using AutoMapper.QueryableExtensions;
using HumanCapitalManagement.Business.BusinessServices.Interfaces;
using HumanCapitalManagement.Business.DataServices.Interfaces;
using HumanCapitalManagement.Data.Models;
using HumanCapitalManagement.Models.Admin.Departments;
using Microsoft.EntityFrameworkCore;

namespace HumanCapitalManagement.Business.BusinessServices;

public class DepartmentBusinessService(
    IDepartmentDataService departmentDataService,
    IMapper mapper)
    : IDepartmentBusinessService
{
    public async Task<IEnumerable<TModel>> GetAllDepartments<TModel>()
        => await departmentDataService.GetQuery()
            .ProjectTo<TModel>(mapper.ConfigurationProvider)
            .ToListAsync();

    public async Task<bool> CreateDepartment(CreateDepartmentFormModel model)
    {
        var exists = await departmentDataService.ExistsByName(model.Name);

        if (exists)
        {
            return false;
        }
        
        var department = new Department
        {
            Name = model.Name,
        };

        await departmentDataService.Add(department);
        await departmentDataService.SaveChanges();

        return true;
    }
}