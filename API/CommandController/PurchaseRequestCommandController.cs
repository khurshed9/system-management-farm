using MediatR;
using Microsoft.AspNetCore.Mvc;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Commands.BusinessOwnerCommand.BusinessOwnerCommandRequest;
using SystemManagementFactory.Features.Commands.PurchaseRequestCommands.PurchaseRequestCommandRequest;

namespace SystemManagementFactory.API.CommandController;

[Route("api/purchaseRequests")]
public class PurchaseRequestCommandController(ISender sender) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePurchaseRequestRequest entity)
    {
        BaseResult result = await sender.Send(entity);
        return result.ToActionResult();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdatePurchaseRequestRequest entity)
    {
        BaseResult result = await sender.Send(entity);
        return result.ToActionResult();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        BaseResult result = await sender.Send(new DeletePurchaseRequestRequest(id));
        return result.ToActionResult();
    }
}