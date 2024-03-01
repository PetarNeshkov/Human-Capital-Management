using AutoMapper;
using AutoMapper.QueryableExtensions;
using HumanCapitalManagement.Business.BusinessServices.Interfaces;
using HumanCapitalManagement.Business.DataServices.Interfaces;
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
}