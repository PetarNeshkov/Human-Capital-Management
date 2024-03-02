namespace HumanCapitalManagement.Models.Employees;

public class EmployeesListingModel
{
    public string Name { get; init; }
    
    public DateTime HireDate { get; init; }
    
    public decimal Salary { get; init; }
    
    public string Position { get; init; }
    
    public int DepartmentId { get; init; }
    
    public string DepartmentName { get; init; }
}