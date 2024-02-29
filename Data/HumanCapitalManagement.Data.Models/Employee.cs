using System.ComponentModel.DataAnnotations;
using HumanCapitalManagement.Data.Common;

using static HumanCapitalManagement.Data.Common.DataValidation.Employee;

namespace HumanCapitalManagement.Data.Models;

public class Employee: BaseModel<int>
{
    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; }
    
    public int DepartmentId { get; set; }
    
    public Department Department { get; set; }
}