using UpdatePolicyService.Models.Database;

namespace UpdatePolicyService.Repositories.Interfaces;

public interface IPolicyRepository : IBaseRepository<TablePolicy>
{
    public IQueryable<TablePolicy> GetAsQueryable();
}