using MediatR;
using Microsoft.AspNetCore.Mvc;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Filters;
using SystemManagementFactory.Features.Queries.BusinessOwnerQueries.BusinessOwnerViewModels;
using SystemManagementFactory.Features.Queries.CropQueries.BusinessOwnerViewModels;
using SystemManagementFactory.Features.Queries.PurchaseRequestQueries.PurchaseRequestViewModels;
using SystemManagementFactory.Responses;

namespace SystemManagementFactory.API.QueryController;

[Route("api/purchaseRequest")]
public class PurchaseRequestQueryController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetPurchaseRequests([FromQuery] PurchaseRequestFilter filter)
    {
        Result<PaginationResponse<IEnumerable<GetPurchaseRequestVm>>> response = await sender.Send(new GetPurchaseRequestVmRequest(filter));
        return response.ToActionResult();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetPurchaseRequestById( int id)
    {
        Result<GetPurchaseRequestByIdVm> response = await sender.Send(new GetPurchaseRequestByIdVmRequest(id));
        return response.ToActionResult();
    }
}