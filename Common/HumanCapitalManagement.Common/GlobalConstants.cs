namespace HumanCapitalManagement.Common;

public static class GlobalConstants
{
    public static class Employee
    {
        public const int NameMaxLength = 50;
        public const int NameMinLength = 3;
        public const int PositionMaxLength = 50;
        public const int EmployeesPerPage = 5;
    }
    
    public static class Administrator
    {
        public const string AdministratorRoleName = "Administrator";
        public const string AdministratorUsername = "Admin";
        public const string AdministratorEmail = "admin@humancapitalmanagement.net";
        public const string AdministratorPassword = "admin567";
    }
}