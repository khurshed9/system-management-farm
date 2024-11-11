using MediatR;
using Microsoft.EntityFrameworkCore;
using SystemManagementFactory.DB;
using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Extensions.Mapper;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Commands.FarmerCommmands.FarmerCommandRequest;

namespace SystemManagementFactory.Features.Commands.FarmerCommmands.FarmerCommandHandler;

public class UpdateFarmerHandler(AppCommandDbContext context) : IRequestHandler<UpdateFarmerRequest,BaseResult>
{
    public async Task<BaseResult> Handle(UpdateFarmerRequest request, CancellationToken cancellationToken)
    {
        Farmer? existingFarmer = await context.Farmers
            .FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.Id, cancellationToken);

        if(existingFarmer is null)
            return BaseResult.Failure(Error.NotFound());

        bool conflict = await context.Farmers.AnyAsync(x
            => x.Id != request.Id && x.FullName.ToLower() ==
            request.FarmerBaseInfo.FullName.ToLower(), cancellationToken);

        if(conflict)
            return BaseResult.Failure(Error.Conflict());

        existingFarmer.ToUpdateFarmer(request);
        int res = await context.SaveChangesAsync(cancellationToken);

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data not saved"))
             : BaseResult.Success();
    }
}
