using MediatR;
using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Extensions.Mapper;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Queries.BusinessOwnerQueries.BusinessOwnerViewModels;
using SystemManagementFactory.Repositories.BaseRepository;
using SystemManagementFactory.UOW;

namespace SystemManagementFactory.Features.Queries.BusinessOwnerQueries.BusinessOwnerQueriesHandler;

public class GetBusinessOwnerByIdHandler(IUnitOfWork<BusinessOwner> unitOfWork) : IRequestHandler<GetBusinessOwnerByIdVmRequest, Result<GetBusinessOwnerByIdVm>>
{
    public async Task<Result<GetBusinessOwnerByIdVm>> Handle(GetBusinessOwnerByIdVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<BusinessOwner> repository = unitOfWork.BusinessOwnerFindRepository;
        BusinessOwner? business = await repository.GetByIdAsync(request.Id);
        GetBusinessOwnerByIdVm viewModel = business.ToReadByIdInfo();

        return Result<GetBusinessOwnerByIdVm>.Success(viewModel);
    }
}