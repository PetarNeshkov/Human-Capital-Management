using System.ComponentModel.DataAnnotations;

namespace HumanCapitalManagement.Web.Areas.Models;

public class LoginInputModel
{
        [Required]
        public string Username { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
        

}