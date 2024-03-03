using System.ComponentModel.DataAnnotations;

namespace HumanCapitalManagement.Models.Employees;

using static Common.GlobalConstants.Employee;
using static Common.ErrorMessages.Employee;
public class CreateEmployeeFormModel
{
    [Required]
    [StringLength(
        NameMaxLength,
        ErrorMessage = NameLengthErrorMessage,
        MinimumLength = NameMinLength)]
    public string Name { get; init; }
    
    public DateTime HireDate { get; set; }
    
    public decimal Salary { get; set; }
    
    [Required]
    [MaxLength(PositionMaxLength)]
    public string Position { get; set; }

    public int DepartmentId { get; init; }
    
}