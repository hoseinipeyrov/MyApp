using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Loans.Queries.GetLoanWithType;
using MyApp.Domain.Entities;

namespace MyApp.Web.Endpoints;

public class Loans : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(RequestLoan);
    }

    public Task<LoanResult> RequestLoan(ISender sender, [FromBody] Loan loan, [FromQuery] string bankChoice)
    {
        var command = new LoanRequest { Loan = loan, BankChoice = bankChoice };
        var response = sender.Send(command);
        return response;
    }


}
