using MediatR;
using Microsoft.AspNetCore.Mvc;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Commands.BusinessOwnerCommand.BusinessOwnerCommandRequest;
using SystemManagementFactory.Features.Commands.CropCommmands.BusinessOwnerCommandRequest;

namespace SystemManagementFactory.API.CommandController;

[Route("api/crops")]
public class CropCommandController(ISender sender) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCropRequest entity)
    {
        BaseResult result = await sender.Send(entity);
        return result.ToActionResult();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCropRequest entity)
    {
        BaseResult result = await sender.Send(entity);
        return result.ToActionResult();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        BaseResult result = await sender.Send(new DeleteCropRequest(id));
        return result.ToActionResult();
    }
}