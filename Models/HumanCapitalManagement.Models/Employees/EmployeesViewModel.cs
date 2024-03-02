using HumanCapitalManagement.Models.Pagination;

namespace HumanCapitalManagement.Models.Employees;

public class EmployeesViewModel
{
    public IEnumerable<EmployeesListingModel> Employees { get; set; }

    public PaginationViewModel Pagination { get; set; }
}