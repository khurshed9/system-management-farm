using MediatR;
using Microsoft.AspNetCore.Mvc;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Queries.FarmerQueries.FarmerViewModels;
using SystemManagementFactory.Features.Queries.Filters;
using SystemManagementFactory.Responses;

namespace SystemManagementFactory.API.QueryController;

[Route("api/farmers")]
public class FarmerQueryController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetFarmers([FromQuery] FarmerFilter filter)
    {
        Result<PaginationResponse<IEnumerable<GetFarmerVm>>> response = await sender.Send(new GetFarmerVmRequest(filter));
        return response.ToActionResult();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetFarmerById( int id)
    {
        Result<GetFarmerByIdVm> response = await sender.Send(new GetFarmerByIdVmRequest(id));
        return response.ToActionResult();
    }
}