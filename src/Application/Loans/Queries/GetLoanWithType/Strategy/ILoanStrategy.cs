namespace MyApp.Application.Loans.Queries.GetLoanWithType.Strategy;

public interface ILoanStrategy
{
    LoanResult CalculateInstallments(Loan loan);
}
