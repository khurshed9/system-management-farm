using MediatR;
using Microsoft.AspNetCore.Mvc;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Commands.FarmerCommmands.FarmerCommandRequest;
using SystemManagementFactory.Features.Commands.FarmerGardenCommands.FarmerCommandRequest;

namespace SystemManagementFactory.API.CommandController;

[Route("api/farmerGardens")]
public class FarmerGardenCommandController(ISender sender) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateFarmerGardenRequest entity)
    {
        BaseResult result = await sender.Send(entity);
        return result.ToActionResult();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateFarmerGardenRequest entity)
    {
        BaseResult result = await sender.Send(entity);
        return result.ToActionResult();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        BaseResult result = await sender.Send(new DeleteFarmerGardenRequest(id));
        return result.ToActionResult();
    }
}