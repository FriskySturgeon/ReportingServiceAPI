using ReportingService.Application.Models;
using ReportingService.Core;

namespace ReportingService.Application.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<List<TransactionModel>> SearchTransaction(Guid customerId, TransactionSearchFilter dates);
        Task<List<TransactionModel>> SearchTransactionByAccount(Guid accountId);
    }
}