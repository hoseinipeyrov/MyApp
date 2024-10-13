namespace MyApp.Application.Loans.Queries.GetLoanWithType.Strategy;

public class BankBStrategy : ILoanStrategy
{
    private static readonly Random Random = new Random();

    public LoanResult CalculateInstallments(Loan loan)
    {
        if (loan.Amount < 100 || loan.Amount > 500)
            return new LoanResult { Success = false, Error = "Amount not within the acceptable range for Bank B." };

        var interestRate = Random.NextDouble() * (0.5 - (-0.20)) + -0.20;
        var totalAmount = loan.Amount * (1 + interestRate);
        var installmentAmount = totalAmount / 8;

        return new LoanResult
        {
            Success = true,
            Installments = Enumerable.Repeat(installmentAmount, 8).ToList()
        };
    }
}
