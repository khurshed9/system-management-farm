using MediatR;
using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Extensions.Mapper;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Queries.CropQueries.BusinessOwnerViewModels;
using SystemManagementFactory.Features.Queries.PurchaseRequestQueries.PurchaseRequestViewModels;
using SystemManagementFactory.Repositories.BaseRepository;
using SystemManagementFactory.UOW;

namespace SystemManagementFactory.Features.Queries.PurchaseRequestQueries.PurchaseRequestQueriesHandler;

public class GetPurchaseRequestByIdHandler(IUnitOfWork<PurchaseRequest> unitOfWork) : IRequestHandler<GetPurchaseRequestByIdVmRequest, Result<GetPurchaseRequestByIdVm>>
{
    public async Task<Result<GetPurchaseRequestByIdVm>> Handle(GetPurchaseRequestByIdVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<PurchaseRequest> repository = unitOfWork.PurchaseRequestFindRepository;
        PurchaseRequest? purchaseRequest = await repository.GetByIdAsync(request.Id);
        GetPurchaseRequestByIdVm viewModel = purchaseRequest.ToReadByIdInfo();

        return Result<GetPurchaseRequestByIdVm>.Success(viewModel);
    }
}