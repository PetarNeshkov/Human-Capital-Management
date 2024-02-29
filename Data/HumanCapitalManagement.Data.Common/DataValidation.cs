namespace HumanCapitalManagement.Data.Common
{
    public static class DataValidation
    {
        public static class Employee
        {
            public const int NameMaxLength = 50;
        }

        public static class Department
        {
            public const int NameMaxLength = 30;
        }
        
        public static class User
        {
            public const int FullNameMaxLength  = 60;
            public const int PasswordMaxLength = 100;
            public const int PasswordMinLength = 6;
        }
        
    }
}