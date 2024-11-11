using MediatR;
using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Extensions.Mapper;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Queries.FarmerQueries.FarmerViewModels;
using SystemManagementFactory.Repositories.BaseRepository;
using SystemManagementFactory.UOW;

namespace SystemManagementFactory.Features.Queries.FarmerQueries.FarmerQueryHandler;

public class GetFarmerByIdHandler(IUnitOfWork<Farmer> unitOfWork) : IRequestHandler<GetFarmerByIdVmRequest,Result<GetFarmerByIdVm>>
{
    public async Task<Result<GetFarmerByIdVm>> Handle(GetFarmerByIdVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<Farmer> repository = unitOfWork.FarmerFindRepository;
        Farmer? farmer = await repository.GetByIdAsync(request.Id);
        GetFarmerByIdVm viewModel = farmer.ToReadByIdInfo();

        return Result<GetFarmerByIdVm>.Success(viewModel);
    }
}
        
