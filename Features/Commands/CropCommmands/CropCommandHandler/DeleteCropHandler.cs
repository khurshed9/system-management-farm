using MediatR;
using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Commands.BusinessOwnerCommand.BusinessOwnerCommandRequest;
using SystemManagementFactory.Features.Commands.CropCommmands.BusinessOwnerCommandRequest;
using SystemManagementFactory.Repositories.BaseRepository;
using SystemManagementFactory.UOW;

namespace SystemManagementFactory.Features.Commands.CropCommmands.BusinessOwnerCommandHandler;

public class DeleteCropHandler(IUnitOfWork<Crop> unitOfWork) : IRequestHandler<DeleteCropRequest, BaseResult>
{

    public async Task<BaseResult> Handle(DeleteCropRequest request, CancellationToken cancellationToken)
    {
        IGenericDeleteRepository<Crop> repository = unitOfWork.CropDeleteRepository;
        IGenericFindRepository<Crop> findRepository = unitOfWork.CropFindRepository;
        
        Crop? crop = await findRepository.GetByIdAsync(request.Id);
        if(crop is null)
            return BaseResult.Failure(Error.NotFound());

        await repository.DeleteAsync(crop);
        int res = await unitOfWork.Complete();
        
        return res > 0
            ? BaseResult.Success()
            : BaseResult.Failure(Error.InternalServerError());
    }
}