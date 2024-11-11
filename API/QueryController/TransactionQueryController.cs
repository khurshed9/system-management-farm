using MediatR;
using Microsoft.AspNetCore.Mvc;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Queries.Filters;
using SystemManagementFactory.Features.Queries.TransactionQueries.TransactionViewModels;
using SystemManagementFactory.Responses;

namespace SystemManagementFactory.API.QueryController;

[Route("api/transactions")]
public class TransactionQueryController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetTransactions([FromQuery] TransactionFilter filter)
    {
        Result<PaginationResponse<IEnumerable<GetTransactionVm>>> response = await sender.Send(new GetTransactionVmRequest(filter));
        return response.ToActionResult();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetTransactionById( int id)
    {
        Result<GetTransactionByIdVm> response = await sender.Send(new GetTransactionByIdVmRequest(id));
        return response.ToActionResult();
    }
}