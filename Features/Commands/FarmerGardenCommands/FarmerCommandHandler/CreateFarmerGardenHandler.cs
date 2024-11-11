using MediatR;
using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Domain.Enums;
using SystemManagementFactory.Extensions.Mapper;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Commands.FarmerGardenCommands.FarmerCommandRequest;
using SystemManagementFactory.Repositories.BaseRepository;
using SystemManagementFactory.UOW;

namespace SystemManagementFactory.Features.Commands.FarmerGardenCommands.FarmerCommandHandler;

public sealed class CreateFarmerGardenHandler(IUnitOfWork<FarmerGarden> unitOfWork) : IRequestHandler<CreateFarmerGardenRequest,BaseResult>
{
    public async Task<BaseResult> Handle(CreateFarmerGardenRequest request, CancellationToken cancellationToken)
    {
        IGenericAddRepository<FarmerGarden> repository = unitOfWork.FarmerGardenAddRepository;
        IGenericFindRepository<FarmerGarden> findRepository = unitOfWork.FarmerGardenFindRepository;

        if (request.FarmerGardenBaseInfo.Status == GardenStatus.InActive)
            return BaseResult.Failure(
                Error.BadRequest("You can not open your account, because your garden is not ready yet"));
        
        bool conflict =
            (await findRepository.FindAsync(x => x.Name.ToLower().Contains(request.FarmerGardenBaseInfo.Name))).Any();

        if (conflict)
            return BaseResult.Failure(Error.AlreadyExists("Garden with this name is already exists, please rename it."));
        
        await repository.AddAsync(request.ToFarmerGarden());

        int res = await unitOfWork.Complete();

        return res > 0
            ? BaseResult.Success()
            : BaseResult.Failure(Error.InternalServerError("Data not saved!!!"));
    }
}