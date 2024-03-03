namespace HumanCapitalManagement.Models.Admin.Employees;

public class AdminEmployeesListingModel
{
    public int Id { get; init; }
    
    public string Name { get; init; }
    
    public DateTime HireDate { get; init; }
    
    public decimal Salary { get; init; }
    
    public string Position { get; init; }
    
    public int DepartmentId { get; init; }
    
    public string DepartmentName { get; init; }
}