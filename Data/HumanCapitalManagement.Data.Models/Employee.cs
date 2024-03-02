using System.ComponentModel.DataAnnotations;
using HumanCapitalManagement.Data.Common;

using static HumanCapitalManagement.Data.Common.DataValidation.Employee;

namespace HumanCapitalManagement.Data.Models;

public class Employee: BaseModel<int>
{
    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; }
    
    public DateTime HireDate { get; set; }
    
    public decimal Salary { get; set; }
    
    [Required]
    [MaxLength(PositionMaxLength)]
    public string Position { get; set; }
    public int DepartmentId { get; set; }
    
    public Department Department { get; set; }
}