using AutoMapper;
using ReportingService.Application.Models;
using ReportingService.Application.Services.Interfaces;
using ReportingService.Core;
using ReportingService.Persistence.Entities;
using ReportingService.Persistence.Repositories.Interfaces;

namespace ReportingService.Application.Services
{
    public class TransactionService(
        ITransactionRepository transactionRepository,
        IMapper mapper) : ITransactionService
    {
        public async Task<List<TransactionModel>> SearchTransaction(
            Guid customerId,
            TransactionSearchFilter dates)
        {
            var transactions = await transactionRepository.FindManyAsync(
                x => x.CustomerId == customerId
                && x.Date >= dates.DateFrom
                && x.Date <= dates.DateTo);

            var transactionModels = mapper.Map<List<TransactionModel>>(transactions)
                .OrderByDescending(x => x.Date)
                .ToList();

            return transactionModels;
        }

        public async Task<List<TransactionModel>> SearchTransactionByAccount(Guid accountId)
        {
            var transactions = await transactionRepository.FindManyAsync(
                x => x.AccountId == accountId);

            var transactionModels = mapper.Map<List<TransactionModel>>(transactions)
                .OrderByDescending(x => x.Date)
                .ToList();

            return transactionModels;
        }
    }
}
