namespace MyApp.Application.Loans.Queries.GetLoanWithType.Strategy;

public class BankAStrategy : ILoanStrategy
{
    public LoanResult CalculateInstallments(Loan loan)
    {
        var interestRate = 0.20;
        var totalAmount = loan.Amount * (1 + interestRate);
        var installmentAmount = totalAmount / 10;

        return new LoanResult
        {
            Success = true,
            Installments = Enumerable.Repeat(installmentAmount, 10).ToList()
        };
    }
}
