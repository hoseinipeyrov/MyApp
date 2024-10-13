namespace MyApp.Application.Loans.Queries.GetLoanWithType.Strategy;

public class BankCStrategy : ILoanStrategy
{
    public LoanResult CalculateInstallments(Loan loan)
    {
        var squaredAmount = loan.Amount * loan.Amount;

        if (squaredAmount < 1) // Ensure it's a valid input  
            return new LoanResult { Success = false, Error = "Invalid loan amount; must result in a natural number." };

        // Search for two unique integers whose squares sum to squaredAmount  
        for (int i = 1; i < squaredAmount; i++)
        {
            for (int j = i + 1; j < squaredAmount; j++)
            {
                if (i * i + j * j == squaredAmount)
                {
                    return new LoanResult
                    {
                        Success = true,
                        Installments = new List<double> { i, j }
                    };
                }
            }
        }

        return new LoanResult { Success = false, Error = "No valid unique installments found for Bank C." };
    }
}
