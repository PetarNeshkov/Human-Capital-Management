using HumanCapitalManagement.Models.Pagination;

namespace HumanCapitalManagement.Models.Admin.Employees;

public class AdminEmployeesViewModel
{
    public IEnumerable<AdminEmployeesListingModel> Employees { get; set; }

    public PaginationViewModel Pagination { get; set; }
}