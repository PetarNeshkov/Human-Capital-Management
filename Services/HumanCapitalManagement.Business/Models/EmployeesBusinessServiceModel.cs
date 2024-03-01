using System.ComponentModel.DataAnnotations;
using HumanCapitalManagement.Data.Models;

namespace HumanCapitalManagement.Business.Models;

using static HumanCapitalManagement.Common.GlobalConstants.Employee;
using static HumanCapitalManagement.Common.ErrorMessages.Employee;
public class EmployeesBusinessServiceModel
{
    [Required]
    [StringLength(
        NameMaxLength,
        ErrorMessage = NameLengthErrorMessage,
        MinimumLength = NameMinLength)]
    public string Name { get; init; }

    public Department Department { get; init; }
}