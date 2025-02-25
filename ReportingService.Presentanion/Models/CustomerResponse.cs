using ReportingService.Core.Configuration;

namespace ReportingService.Presentanion.Models;

public class CustomerResponse
{
    public Guid Id { get; set; }
    public Role Role { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public DateTime? CustomVipDueDate { get; set; }
    public DateTime BirthDate { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsDeactivated { get; set; }
}
