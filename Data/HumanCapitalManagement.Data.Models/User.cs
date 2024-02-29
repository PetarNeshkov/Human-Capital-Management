using System.ComponentModel.DataAnnotations;
using HumanCapitalManagement.Data.Common;
using Microsoft.AspNetCore.Identity;

using static HumanCapitalManagement.Data.Common.DataValidation.User;

namespace HumanCapitalManagement.Data.Models;

public class User: IdentityUser, IAuditInfo
{
    [Required]
    [MaxLength(FullNameMaxLength)]
    public string FullName { get; set; }
    
    public DateTime CreatedOn { get; set; }
    
    public DateTime ModifiedOn { get; set; }
    
    public bool IsDeleted { get; set; }
    
    public string DeletedOn { get; set; }
}