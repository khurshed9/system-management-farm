using MediatR;
using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Extensions.Mapper;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Commands.BusinessOwnerCommands.BusinessOwnerCommandRequest;
using SystemManagementFactory.Repositories.BaseRepository;
using SystemManagementFactory.UOW;

namespace SystemManagementFactory.Features.Commands.BusinessOwnerCommands.BusinessOwnerCommandHandler;

public class CreateBusinessOwnerHandler(IUnitOfWork<BusinessOwner> unitOfWork) : IRequestHandler<CreateBusinessOwnerRequest, BaseResult>
{
    public async Task<BaseResult> Handle(CreateBusinessOwnerRequest request, CancellationToken cancellationToken)
    {
        IGenericAddRepository<BusinessOwner> repository = unitOfWork.BusinessOwnerAddRepository;
        IGenericFindRepository<BusinessOwner> findRepository = unitOfWork.BusinessOwnerFindRepository;
        
        bool conflict =
            (await findRepository.FindAsync(x => x.FullName.ToLower().Contains(request.BusinessOwnerBaseInfo.FullName))).Any();

        if(conflict)
            return BaseResult.Failure(Error.AlreadyExists());

        await repository.AddAsync(request.ToBusinessOwner());

        int res = await unitOfWork.Complete();

        return res > 0
            ? BaseResult.Success()
            : BaseResult.Failure(Error.InternalServerError());
    }
}