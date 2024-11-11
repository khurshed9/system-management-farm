using MediatR;
using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Extensions.Mapper;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Commands.FarmerCommmands.FarmerCommandRequest;
using SystemManagementFactory.Repositories.BaseRepository;
using SystemManagementFactory.UOW;

namespace SystemManagementFactory.Features.Commands.FarmerCommmands.FarmerCommandHandler;

public sealed class CreateFarmerHandler(IUnitOfWork<Farmer> unitOfWork) : IRequestHandler<CreateFarmerRequest,BaseResult>
{
    public async Task<BaseResult> Handle(CreateFarmerRequest request, CancellationToken cancellationToken)
    {
        IGenericAddRepository<Farmer> repository = unitOfWork.FarmerAddRepository;
        IGenericFindRepository<Farmer> findRepository = unitOfWork.FarmerFindRepository;

        bool conflict =
            (await findRepository.FindAsync(x => x.FullName.ToLower().Contains(request.FarmerBaseInfo.FullName))).Any();

        if(conflict)
            return BaseResult.Failure(Error.AlreadyExists());

        await repository.AddAsync(request.ToFarmer());

        int res = await unitOfWork.Complete();

        return res > 0
            ? BaseResult.Success()
            : BaseResult.Failure(Error.InternalServerError());
    }
}