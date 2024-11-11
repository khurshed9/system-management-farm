using MediatR;
using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Extensions.Mapper;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Queries.BusinessOwnerQueries.BusinessOwnerViewModels;
using SystemManagementFactory.Features.Queries.CropQueries.BusinessOwnerViewModels;
using SystemManagementFactory.Repositories.BaseRepository;
using SystemManagementFactory.UOW;

namespace SystemManagementFactory.Features.Queries.CropQueries.BusinessOwnerQueriesHandler;

public class GetCropByIdHandler(IUnitOfWork<Crop> unitOfWork) : IRequestHandler<GetCropByIdVmRequest, Result<GetCropByIdVm>>
{
    public async Task<Result<GetCropByIdVm>> Handle(GetCropByIdVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<Crop> repository = unitOfWork.CropFindRepository;
        Crop? crop = await repository.GetByIdAsync(request.Id);
        GetCropByIdVm viewModel = crop.ToReadByIdInfo();

        return Result<GetCropByIdVm>.Success(viewModel);
    }
}