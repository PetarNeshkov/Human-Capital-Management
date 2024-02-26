using HumanCapitalManagement.Data.Common;
using HumanCapitalManagement.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HumanCapitalManagement.Data;

public class HumanCapitalManagementDbContext(DbContextOptions<HumanCapitalManagementDbContext> options)
    : IdentityDbContext<User>(options)
{
    public DbSet<Employee> Employees { get; init; }
    
    public DbSet<Department> Departments { get; init; }
    
    public override Task<int> SaveChangesAsync(
        bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken = default)
    {
        ApplyAuditForRules();
        
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        var entityTypes = builder.Model.GetEntityTypes().ToList();

        var foreignKeys = entityTypes
            .SelectMany(e => e.GetForeignKeys()
                .Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));

        foreach (var foreignKey in foreignKeys)
        {
            foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
    
    private void ApplyAuditForRules()
    {
        var changedEntries = ChangeTracker
            .Entries()
            .Where(e =>
                e is { Entity: IAuditInfo, State: EntityState.Added or EntityState.Modified });

        foreach (var entry in changedEntries)
        {
            var entity = (IAuditInfo)entry.Entity;

            if (entry.State == EntityState.Added && entity.CreatedOn == default)
            {
                entity.CreatedOn = DateTime.UtcNow;
            }
            else
            {
                entity.ModifiedOn = DateTime.UtcNow;
            }
        }
    }
}
