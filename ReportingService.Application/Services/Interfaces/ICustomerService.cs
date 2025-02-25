using ReportingService.Application.Models;
using ReportingService.Core.Configuration.Filters;

namespace ReportingService.Application.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerModel> AddCustomerAsync(CustomerModel customerModel);
        Task<CustomerModel> GetCustomerByAccountIdAsync(Guid accountId);
        Task<CustomerModel> GetCustomerByIdAsync(Guid id);
        Task<CustomerModel> GetCustomerByTransactionIdAsync(Guid transactionId);
        Task<List<CustomerModel>> GetCustomersByBirthAsync(DateFilter dates);
        Task<CustomerModel> GetFullCustomerByIdAsync(Guid id);
        Task TransactionalAddCustomersAsync(List<CustomerModel> customerModels);
    }
}