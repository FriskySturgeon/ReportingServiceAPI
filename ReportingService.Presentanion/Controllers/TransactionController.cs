using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReportingService.Application.Models;
using ReportingService.Application.Services;
using ReportingService.Application.Services.Interfaces;
using ReportingService.Core;
using ReportingService.Core.Configuration;
using ReportingService.Presentanion.Models;
//GET (monthCount transCount) => List<Guid> Ids
//GET (monthCount money) => List<Guid> Ids
// GET (day month) => List<Guid> Ids
// 
namespace ReportingService.Presentanion.Controllers;

[Route("api/transactions")]
public class TransactionController(
    ITransactionService transactionService,
    IMapper mapper) : Controller
{
    [HttpPost("by-customer")]
    public async Task<List<TransactionResponse>> SearchTransactions(
        [FromQuery] Guid customerId, 
        [FromBody] TransactionSearchFilter request)
    {
        var transactions = await transactionService.SearchTransaction(customerId, request);

        var response = mapper.Map<List<TransactionResponse>>(transactions);
            
        return response;
    }

    [HttpPost("by-account")]
    public async Task<List<TransactionResponse>> SearchTransactionsByAccount(
        [FromQuery] Guid accountId)
    {
        var transactions = await transactionService.SearchTransactionByAccount(accountId);

        var response = mapper.Map<List<TransactionResponse>>(transactions);

        return response;
    }
}
