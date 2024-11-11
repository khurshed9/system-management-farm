using MediatR;
using Microsoft.EntityFrameworkCore;
using SystemManagementFactory.DB;
using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Extensions.Mapper;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Commands.CropCommmands.BusinessOwnerCommandRequest;
using SystemManagementFactory.Features.Commands.PurchaseRequestCommands.PurchaseRequestCommandRequest;

namespace SystemManagementFactory.Features.Commands.PurchaseRequestCommands.PurchaseRequestCommandHandler;

public class UpdatePurchaseRequestHandler(AppCommandDbContext context) : IRequestHandler<UpdatePurchaseRequestRequest,BaseResult>
{

    public async Task<BaseResult> Handle(UpdatePurchaseRequestRequest request, CancellationToken cancellationToken)
    {
        PurchaseRequest? existingP = await context.PurchaseRequests
            .FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.Id, cancellationToken);

        if(existingP is null)
            return BaseResult.Failure(Error.NotFound());

        existingP.ToUpdatePurchaseRequest(request);
        int res = await context.SaveChangesAsync(cancellationToken);

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data not saved"))
            : BaseResult.Success();
    }
}