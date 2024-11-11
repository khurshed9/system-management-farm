using MediatR;
using Microsoft.EntityFrameworkCore;
using SystemManagementFactory.DB;
using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Extensions.Mapper;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Commands.BusinessOwnerCommands.BusinessOwnerCommandRequest;

namespace SystemManagementFactory.Features.Commands.BusinessOwnerCommands.BusinessOwnerCommandHandler;

public class UpdateBusinessOwnerHandler(AppCommandDbContext context) : IRequestHandler<UpdateBusinessOwnerRequest,BaseResult>
{
    public async Task<BaseResult> Handle(UpdateBusinessOwnerRequest request, CancellationToken cancellationToken)
    {
        BusinessOwner? existingBO = await context.BusinessOwners
            .FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.Id, cancellationToken);

        if(existingBO is null)
            return BaseResult.Failure(Error.NotFound());

        bool conflict = await context.BusinessOwners.AnyAsync(x
            => x.Id != request.Id && x.FullName.ToLower() ==
            request.BusinessOwnerBaseInfo.FullName.ToLower(), cancellationToken);

        if(conflict)
            return BaseResult.Failure(Error.Conflict());

        existingBO.ToUpdateBusinessOwner(request);
        int res = await context.SaveChangesAsync(cancellationToken);

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data not saved"))
            : BaseResult.Success();
    }
}