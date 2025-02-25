using AutoMapper;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using ReportingService.Application.Services;
using ReportingService.Application.Services.Interfaces;
using ReportingService.Core.Configuration.Filters;
using ReportingService.Presentanion.Models;

namespace ReportingService.Presentanion.Controllers;

[Route("api")]
public class AccountController(
IAccountService accountService,
IMapper mapper) : Controller
{

    [HttpGet("accounts")]
    public async Task<ActionResult<List<AccountResponse>>> GetAccountsByCustomerIdAsync([FromQuery] Guid customerId)
    {
        var accounts = await accountService.GetAccountsByCustomerIdAsync(customerId);
        
        var response = mapper.Map<List<AccountResponse>>(accounts);

        return Ok(response);
    }
}
