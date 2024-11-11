using MediatR;
using Microsoft.AspNetCore.Mvc;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Queries.FarmerGardenQueries.FarmerGardenViewModels;
using SystemManagementFactory.Features.Queries.FarmerQueries.FarmerViewModels;
using SystemManagementFactory.Features.Queries.Filters;
using SystemManagementFactory.Responses;
using GetFarmerVmRequest = SystemManagementFactory.Features.Queries.FarmerQueries.FarmerViewModels.GetFarmerVmRequest;

namespace SystemManagementFactory.API.QueryController;

[Route("api/farmerGardens")]
public class FarmerGardenQueryController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetFarmerGardens([FromQuery] FarmerGardenFilter filter)
    {
        Result<PaginationResponse<IEnumerable<GetFarmerGardenVm>>> response = await sender.Send(new GetFarmerGardenVmRequest(filter));
        return response.ToActionResult();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetFarmerGardenById( int id)
    {
        Result<GetFarmerGardenByIdVm> response = await sender.Send(new GetFarmerGardenByIdVmRequest(id));
        return response.ToActionResult();
    }
}