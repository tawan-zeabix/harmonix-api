using System.Net;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using UpdatePolicyService.Exceptions;
using UpdatePolicyService.Models.Database;
using UpdatePolicyService.Services.Interfaces;

namespace UpdatePolicyService.Controllers;

[ApiController]
[Route("[controller]")]
public class PolicyController : ControllerBase
{
    private readonly IPolicyService _policyService;
    private readonly ILogger<PolicyController> _logger;
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;

    public PolicyController(IPolicyService policyService, IConfiguration configuration, ILogger<PolicyController> logger, HttpClient httpClient)
    {
        _policyService = policyService;
        _logger = logger;
        _configuration = configuration;
        _httpClient = httpClient;
    }
    
    [HttpPost("policies")]
    public async Task<IActionResult> GetTablePolicies()
    {
        List<TablePolicy> policies = await _policyService.GetPoliciesAsync();
        if (policies.Count > 0)
        {
            var harmonixApiUrl = _configuration["Harmonix:API"];
            var jsonPayload = JsonSerializer.Serialize(policies);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(harmonixApiUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    return Ok(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
                }
            }
            catch (HttpRequestException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        return Ok("Policy updated");
    }
}