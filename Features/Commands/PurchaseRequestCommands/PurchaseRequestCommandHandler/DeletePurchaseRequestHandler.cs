using MediatR;
using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Commands.CropCommmands.BusinessOwnerCommandRequest;
using SystemManagementFactory.Features.Commands.PurchaseRequestCommands.PurchaseRequestCommandRequest;
using SystemManagementFactory.Repositories.BaseRepository;
using SystemManagementFactory.UOW;

namespace SystemManagementFactory.Features.Commands.PurchaseRequestCommands.PurchaseRequestCommandHandler;

public class DeletePurchaseRequestHandler(IUnitOfWork<PurchaseRequest> unitOfWork) : IRequestHandler<DeletePurchaseRequestRequest, BaseResult>
{

    public async Task<BaseResult> Handle(DeletePurchaseRequestRequest request, CancellationToken cancellationToken)
    {
        IGenericDeleteRepository<PurchaseRequest> repository = unitOfWork.PurchaseRequestDeleteRepository;
        IGenericFindRepository<PurchaseRequest> findRepository = unitOfWork.PurchaseRequestFindRepository;
        
        PurchaseRequest? purchaseRequest = await findRepository.GetByIdAsync(request.Id);
        if(purchaseRequest is null)
            return BaseResult.Failure(Error.NotFound());

        await repository.DeleteAsync(purchaseRequest);
        int res = await unitOfWork.Complete();
        
        return res > 0
            ? BaseResult.Success()
            : BaseResult.Failure(Error.InternalServerError());
    }
}