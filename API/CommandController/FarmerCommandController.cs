using MediatR;
using Microsoft.AspNetCore.Mvc;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Commands.FarmerCommmands.FarmerCommandRequest;

namespace SystemManagementFactory.API.CommandController;

[Route("api/farmers")]
public class FarmerCommandController(ISender sender) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateFarmerRequest entity)
    {
        BaseResult result = await sender.Send(entity);
        return result.ToActionResult();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateFarmerRequest entity)
    {
        BaseResult result = await sender.Send(entity);
        return result.ToActionResult();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        BaseResult result = await sender.Send(new DeleteFarmerRequest(id));
        return result.ToActionResult();
    }
}