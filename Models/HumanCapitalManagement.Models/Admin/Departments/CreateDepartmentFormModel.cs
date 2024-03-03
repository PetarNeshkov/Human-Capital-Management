using System.ComponentModel.DataAnnotations;

using static HumanCapitalManagement.Common.GlobalConstants.Department;
namespace HumanCapitalManagement.Models.Admin.Departments;

public class CreateDepartmentFormModel
{
    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; init; }
}