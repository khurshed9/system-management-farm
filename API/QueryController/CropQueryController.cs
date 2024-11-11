using MediatR;
using Microsoft.AspNetCore.Mvc;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Filters;
using SystemManagementFactory.Features.Queries.BusinessOwnerQueries.BusinessOwnerViewModels;
using SystemManagementFactory.Features.Queries.CropQueries.BusinessOwnerViewModels;
using SystemManagementFactory.Responses;

namespace SystemManagementFactory.API.QueryController;

[Route("api/crops")]
public class CropsQueryController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetCrops([FromQuery] CropFilter filter)
    {
        Result<PaginationResponse<IEnumerable<GetCropVm>>> response = await sender.Send(new GetCropVmRequest(filter));
        return response.ToActionResult();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCropById( int id)
    {
        Result<GetCropByIdVm> response = await sender.Send(new GetCropByIdVmRequest(id));
        return response.ToActionResult();
    }
}