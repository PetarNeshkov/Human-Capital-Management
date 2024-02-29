using System.ComponentModel.DataAnnotations;
using static HumanCapitalManagement.Data.Common.DataValidation.User;
using static HumanCapitalManagement.Common.ErrorMessages.Register;

namespace HumanCapitalManagement.Web.Areas.Models;

public class RegisterInputModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [MaxLength(FullNameMaxLength, ErrorMessage = InvalidFullNameLength)]
    [Display(Name = "Full name")]
    public string FullName { get; set; }


    [Required]
    [StringLength(PasswordMaxLength, ErrorMessage = InvalidPasswordLength, MinimumLength = PasswordMinLength)]
    [DataType(DataType.Password)]
    public string Password { get; set; }
            
            
    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = PasswordsDontMatch)]
    public string ConfirmPassword { get; set; }
    
}