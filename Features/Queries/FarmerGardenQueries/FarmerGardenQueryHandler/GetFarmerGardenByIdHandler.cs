using MediatR;
using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Extensions.Mapper;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Queries.FarmerGardenQueries.FarmerGardenViewModels;
using SystemManagementFactory.Repositories.BaseRepository;
using SystemManagementFactory.UOW;

namespace SystemManagementFactory.Features.Queries.FarmerGardenQueries.FarmerGardenQueryHandler;

public class GetFarmerGardenByIdHandler(IUnitOfWork<FarmerGarden> unitOfWork) : IRequestHandler<GetFarmerGardenByIdVmRequest,Result<GetFarmerGardenByIdVm>>
{
    public async Task<Result<GetFarmerGardenByIdVm>> Handle(GetFarmerGardenByIdVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<FarmerGarden> repository = unitOfWork.FarmerGardenFindRepository;
        FarmerGarden? farmerGarden = await repository.GetByIdAsync(request.Id);
        GetFarmerGardenByIdVm viewModel = farmerGarden.ToReadByIdInfo();

        return Result<GetFarmerGardenByIdVm>.Success(viewModel);
    }
}