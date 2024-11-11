using MediatR;
using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Extensions.Mapper;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Commands.CropCommmands.BusinessOwnerCommandRequest;
using SystemManagementFactory.Repositories.BaseRepository;
using SystemManagementFactory.UOW;

namespace SystemManagementFactory.Features.Commands.CropCommmands.CropCommandHandler;

public class CreateCropHandler(IUnitOfWork<Crop> unitOfWork) : IRequestHandler<CreateCropRequest, BaseResult>
{
    public async Task<BaseResult> Handle(CreateCropRequest request, CancellationToken cancellationToken)
    {
        IGenericAddRepository<Crop> repository = unitOfWork.CropAddRepository;
        IGenericFindRepository<Crop> findRepository = unitOfWork.CropFindRepository;

        if (request.CropBaseInfo.Quantity < 0)
            return BaseResult.Failure(Error.BadRequest());

        await repository.AddAsync(request.ToCrop());

        int res = await unitOfWork.Complete();

        return res > 0
            ? BaseResult.Success()
            : BaseResult.Failure(Error.InternalServerError());
    }
}