using MediatR;
using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Commands.BusinessOwnerCommands.BusinessOwnerCommandRequest;
using SystemManagementFactory.Repositories.BaseRepository;
using SystemManagementFactory.UOW;

namespace SystemManagementFactory.Features.Commands.BusinessOwnerCommands.BusinessOwnerCommandHandler;

public class DeleteBusinessOwnerHandler(IUnitOfWork<BusinessOwner> unitOfWork) : IRequestHandler<DeleteBusinessOwnerRequest, BaseResult>
{
    public async Task<BaseResult> Handle(DeleteBusinessOwnerRequest request, CancellationToken cancellationToken)
    {
        IGenericDeleteRepository<BusinessOwner> repository = unitOfWork.BusinessOwnerDeleteRepository;
        IGenericFindRepository<BusinessOwner> findRepository = unitOfWork.BusinessOwnerFindRepository;

        BusinessOwner? business = await findRepository.GetByIdAsync(request.Id);
        if(business is null)
            return BaseResult.Failure(Error.NotFound());

        await repository.DeleteAsync(business);
        int res = await unitOfWork.Complete();
        
        return res > 0
            ? BaseResult.Success()
            : BaseResult.Failure(Error.InternalServerError());
    }
}