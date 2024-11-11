using MediatR;
using Microsoft.EntityFrameworkCore;
using SystemManagementFactory.DB;
using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Extensions.Mapper;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Commands.FarmerGardenCommands.FarmerCommandRequest;
using SystemManagementFactory.UOW;

namespace SystemManagementFactory.Features.Commands.FarmerGardenCommands.FarmerCommandHandler;

public sealed class UpdateFarmerGardenHandler(AppCommandDbContext context) : IRequestHandler<UpdateFarmerGardenRequest,BaseResult>
{
    public async Task<BaseResult> Handle(UpdateFarmerGardenRequest request, CancellationToken cancellationToken)
    {
        FarmerGarden? existingFarmerGarden = await context.FarmerGardens
            .FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.Id, cancellationToken);

        if(existingFarmerGarden is null)
            return BaseResult.Failure(Error.NotFound());

        bool conflict = await context.FarmerGardens.AnyAsync(x
            => x.Id != request.Id && x.Name.ToLower() ==
            request.FarmerGardenBaseInfo.Name.ToLower(), cancellationToken);

        if(conflict)
            return BaseResult.Failure(Error.Conflict());

        existingFarmerGarden.ToUpdateFarmerGarden(request);
        int res = await context.SaveChangesAsync(cancellationToken);

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data not saved"))
            : BaseResult.Success();
    }
}