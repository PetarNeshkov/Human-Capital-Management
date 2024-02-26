using System.ComponentModel.DataAnnotations;
using HumanCapitalManagement.Data.Common;

namespace HumanCapitalManagement.Data.Models;

public class Department: BaseModel<int>
{
    [Required]
    [MaxLength(30)]
    public string Name { get; set; }

    public ICollection<Employee> People { get; set; } = new HashSet<Employee>();
}