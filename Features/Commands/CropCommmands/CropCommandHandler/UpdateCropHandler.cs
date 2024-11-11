using MediatR;
using Microsoft.EntityFrameworkCore;
using SystemManagementFactory.DB;
using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Extensions.Mapper;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Commands.CropCommmands.BusinessOwnerCommandRequest;

namespace SystemManagementFactory.Features.Commands.CropCommmands.BusinessOwnerCommandHandler;

public class UpdateCropHandler(AppCommandDbContext context) : IRequestHandler<UpdateCropRequest,BaseResult>
{

    public async Task<BaseResult> Handle(UpdateCropRequest request, CancellationToken cancellationToken)
    {
        Crop? existingCrop = await context.Crops
            .FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.Id, cancellationToken);

        if(existingCrop is null)
            return BaseResult.Failure(Error.NotFound());

        bool conflict = await context.Crops.AnyAsync(x
            => x.Id != request.Id && x.Name.ToLower() ==
            request.CropBaseInfo.Name.ToLower(), cancellationToken);

        if(conflict)
            return BaseResult.Failure(Error.Conflict());

        existingCrop.ToUpdateCrop(request);
        int res = await context.SaveChangesAsync(cancellationToken);

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Data not saved"))
            : BaseResult.Success();
    }
}