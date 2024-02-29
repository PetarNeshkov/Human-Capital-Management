using System.ComponentModel.DataAnnotations;
using HumanCapitalManagement.Data.Common;

using static HumanCapitalManagement.Data.Common.DataValidation.Department;

namespace HumanCapitalManagement.Data.Models;

public class Department: BaseModel<int>
{
    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; }

    public ICollection<Employee> People { get; set; } = new HashSet<Employee>();
}