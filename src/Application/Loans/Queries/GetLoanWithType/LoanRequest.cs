namespace MyApp.Application.Loans.Queries.GetLoanWithType;

public class LoanRequest : IRequest<LoanResult>
{
    public required Loan Loan { get; set; }
    public required string BankChoice { get; set; }
}
