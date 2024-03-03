using System.ComponentModel.DataAnnotations;

namespace HumanCapitalManagement.Data.Common;

public class BaseModel<TKey>: IAuditInfo
{
    [Key]
    public TKey Id { get; init; }
    
    public DateTime CreatedOn { get; set; }
    
    public DateTime ModifiedOn { get; set; }
    
    public bool IsDeleted { get; set; }
    
    public DateTime DeletedOn { get; set; }
}