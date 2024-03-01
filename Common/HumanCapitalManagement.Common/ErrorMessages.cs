namespace HumanCapitalManagement.Common;

public class ErrorMessages
{
    public static class Login
    {
        public const string UserAlreadyLoggedIn = "User logged in.";
        
        public const string UserLockedOut = "User account locked out.";

        public const string InvalidCredentials =
            "The username or password supplied are incorrect. Please check your spelling and try again.";
    }
    
    public static class Register
    {
        public const string InvalidFullNameLength = "The {0} must be max {1} characters long.";
        public const string InvalidPasswordLength = "The {0} must be at least {2} and at max {1} characters long.";
        public const string PasswordsDontMatch = "The password and confirmation password do not match.";
        public const string ExistingUsername = "There is already user with that username.";
        public const string ExistingEmail = "There is already user with that email.";
    }
    
    public static class Employee
    {
        public const string NameLengthErrorMessage= "The {0} must be at least {2} and at max {1} characters long.";
        public const string EmployeeExistsErrorMessage = "There is already an employee with this name.";


    }
}