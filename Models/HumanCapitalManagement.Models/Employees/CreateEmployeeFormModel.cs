using System.ComponentModel.DataAnnotations;
using HumanCapitalManagement.Data.Models;
using HumanCapitalManagement.Models.Departments;

namespace HumanCapitalManagement.Models.Employees;

using static HumanCapitalManagement.Common.GlobalConstants.Employee;
using static HumanCapitalManagement.Common.ErrorMessages.Employee;
public class CreateEmployeeFormModel
{
    [Required]
    [StringLength(
        NameMaxLength,
        ErrorMessage = NameLengthErrorMessage,
        MinimumLength = NameMinLength)]
    public string Name { get; init; }

    public Department Department { get; init; }

    public IEnumerable<DepartmentsListingModel> Departments { get; set; } 

}