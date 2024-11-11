using MediatR;
using Microsoft.AspNetCore.Mvc;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Commands.FarmerGardenCommands.FarmerCommandRequest;
using SystemManagementFactory.Features.Commands.TransactionCommands.TransactionCommandRequest;

namespace SystemManagementFactory.API.CommandController;

[Route("api/transactions")]
public class TransactionCommandController(ISender sender) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTransactionRequest entity)
    {
        BaseResult result = await sender.Send(entity);
        return result.ToActionResult();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTransactionRequest entity)
    {
        BaseResult result = await sender.Send(entity);
        return result.ToActionResult();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        BaseResult result = await sender.Send(new DeleteTransactionRequest(id));
        return result.ToActionResult();
    }
}