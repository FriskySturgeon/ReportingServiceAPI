namespace ReportingService.Core.Configuration.Filters;

public class DepositDifferenceFilter
{
    public required DateFilter DateFilter { get; set; }
    public required decimal DepositDifference { get; set; }
}
