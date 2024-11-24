using UpdatePolicyService.Models.Database;
using UpdatePolicyService.Repositories.Interfaces;

namespace UpdatePolicyService.Repositories;

public class PolicyRepository : BaseRepository<TablePolicy>, IPolicyRepository
{
    public PolicyRepository(DatabaseContext context) : base(context)
    {
        
    }

    public IQueryable<TablePolicy> GetAsQueryable()
    {
        return DbSet.AsQueryable();
    }
    
}