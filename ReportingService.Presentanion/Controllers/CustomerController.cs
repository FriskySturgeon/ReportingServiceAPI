using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReportingService.Application.Services.Interfaces;
using ReportingService.Core.Configuration;
using ReportingService.Core.Configuration.Filters;
using ReportingService.Presentanion.Models;

namespace ReportingService.Presentanion.Controllers;
[Route("api/customers")]
public class CustomerController(
    ICustomerService customerService,
    IMapper mapper) : Controller
{
    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerResponse>> GetCustomerByIdAsync([FromRoute] Guid id)
    {
        var customer = mapper.Map<CustomerResponse>(
                       await customerService.GetCustomerByIdAsync(id));

        return Ok(customer);
    }

    [HttpGet("birth-date")]
    public async Task<ActionResult<List<CustomerResponse>>> GetCustomersByBirthAsync([FromQuery] DateFilter dates)
    {
        var customers = mapper.Map<List<CustomerResponse>>(
                       await customerService.GetCustomersByBirthAsync(dates));
        return Ok(customers);
    }

    [HttpGet("{id}/transactions")]
    public async Task<ActionResult<CustomerResponse>> GetTransactionsByCustomerIdAsync(
            [FromRoute] Guid Id, [FromQuery] int? monthCount)
    {
        return Ok(new CustomerResponse());
    }
}
