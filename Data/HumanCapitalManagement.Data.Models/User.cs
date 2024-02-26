using HumanCapitalManagement.Data.Common;
using Microsoft.AspNetCore.Identity;

namespace HumanCapitalManagement.Data.Models;

public class User: IdentityUser, IAuditInfo
{
    public DateTime CreatedOn { get; set; }
    
    public DateTime ModifiedOn { get; set; }
    
    public bool IsDeleted { get; set; }
    
    public string DeletedOn { get; set; }
}