using System.ComponentModel.DataAnnotations;
using HumanCapitalManagement.Data.Common;

namespace HumanCapitalManagement.Data.Models;

public class Employee: BaseModel<int>
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    public int DepartmentId { get; set; }
    
    public Department Department { get; set; }
}