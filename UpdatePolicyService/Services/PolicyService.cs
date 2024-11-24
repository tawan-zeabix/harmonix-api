using Microsoft.EntityFrameworkCore;
using UpdatePolicyService.Models.Database;
using UpdatePolicyService.Repositories.Interfaces;
using UpdatePolicyService.Services.Interfaces;

namespace UpdatePolicyService.Services;

public class PolicyService : IPolicyService
{
    private readonly ILogger<PolicyService> _logger;
    private readonly IPolicyRepository _policyRepository;

    public PolicyService(ILogger<PolicyService> logger, IPolicyRepository policyRepository)
    {
        _logger = logger;
        _policyRepository = policyRepository;
    }

    public async Task<List<TablePolicy>> GetPoliciesAsync()
    {
        List<TablePolicy> policies = await _policyRepository.GetAsQueryable()
            .Where(i => i.Flag == "01").ToListAsync();
        return policies;
    }
}