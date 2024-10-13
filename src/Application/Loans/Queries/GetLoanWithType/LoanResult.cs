namespace MyApp.Application.Loans.Queries.GetLoanWithType;

public class LoanResult
{
    public bool? Success { get; set; }
    public List<double>? Installments { get; set; } = [];
    public string? Error { get; set; }
}
