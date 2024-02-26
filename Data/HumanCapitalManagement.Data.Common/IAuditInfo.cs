namespace HumanCapitalManagement.Data.Common;

public interface IAuditInfo
{
    DateTime CreatedOn { get; set; }

    DateTime ModifiedOn { get; set; }

    bool IsDeleted { get; set; }

    string DeletedOn { get; set; }
}