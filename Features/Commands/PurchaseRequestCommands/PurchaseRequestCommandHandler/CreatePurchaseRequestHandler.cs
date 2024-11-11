using MediatR;
using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Extensions.Mapper;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Commands.PurchaseRequestCommands.PurchaseRequestCommandRequest;
using SystemManagementFactory.Repositories.BaseRepository;
using SystemManagementFactory.UOW;

namespace SystemManagementFactory.Features.Commands.PurchaseRequestCommands.PurchaseRequestCommandHandler;

public class CreatePurchaseRequestHandler(IUnitOfWork<PurchaseRequest> unitOfWork) : IRequestHandler<CreatePurchaseRequestRequest, BaseResult>
{
    public async Task<BaseResult> Handle(CreatePurchaseRequestRequest request, CancellationToken cancellationToken)
    {
        IGenericAddRepository<PurchaseRequest> repository = unitOfWork.PurchaseRequestAddRepository;

        if (request.PurchaseRequestBaseInfo.RequestDate > DateTime.Now)
            return BaseResult.Failure(Error.BadRequest());

        await repository.AddAsync(request.ToPurchaseRequest());

        int res = await unitOfWork.Complete();

        return res > 0
            ? BaseResult.Success()
            : BaseResult.Failure(Error.InternalServerError());
    }
}