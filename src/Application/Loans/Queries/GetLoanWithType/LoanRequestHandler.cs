using MyApp.Application.Loans.Queries.GetLoanWithType.Strategy;

namespace MyApp.Application.Loans.Queries.GetLoanWithType;

public class LoanRequestHandler : IRequestHandler<LoanRequest, LoanResult>
{
    private readonly IDictionary<string, ILoanStrategy> _strategies;

    public LoanRequestHandler()
    {
        _strategies = new Dictionary<string, ILoanStrategy>
        {
            { "A", new BankAStrategy() },
            { "B", new BankBStrategy() },
            { "C", new BankCStrategy() }
        };
    }

    public Task<LoanResult> Handle(LoanRequest request, CancellationToken cancellationToken)
    {
        if (_strategies.TryGetValue(request.BankChoice, out var strategy))
        {
            return Task.FromResult(strategy.CalculateInstallments(request.Loan));
        }

        return Task.FromResult(new LoanResult { Success = false, Error = "Invalid bank choice." });
    }
}
