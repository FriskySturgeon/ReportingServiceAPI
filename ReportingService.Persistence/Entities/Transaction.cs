
using ReportingService.Core.Configuration;

namespace ReportingService.Persistence.Entities;

public class Transaction
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public decimal AmountRUB { get; set; }
    public TransactionType TransactionType { get; set; }
    //DENORMALIZED
    public Currency Currency { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }

}
