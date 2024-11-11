using MediatR;
using Microsoft.AspNetCore.Mvc;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Filters;
using SystemManagementFactory.Features.Queries.BusinessOwnerQueries.BusinessOwnerViewModels;
using SystemManagementFactory.Responses;

namespace SystemManagementFactory.API.QueryController;

[Route("api/businessOwners")]
public class BusinessOwnerQueryController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBusinessOwners([FromQuery] BusinessOwnerFilter filter)
    {
        Result<PaginationResponse<IEnumerable<GetBusinessOwnerVm>>> response = await sender.Send(new GetBusinessOwnerVmRequest(filter));
        return response.ToActionResult();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetBusinessOwnerById( int id)
    {
        Result<GetBusinessOwnerByIdVm> response = await sender.Send(new GetBusinessOwnerByIdVmRequest(id));
        return response.ToActionResult();
    }
}