using UpdatePolicyService.Models.Database;

namespace UpdatePolicyService.Services.Interfaces;

public interface IPolicyService
{
    Task<List<TablePolicy>> GetPoliciesAsync();
}