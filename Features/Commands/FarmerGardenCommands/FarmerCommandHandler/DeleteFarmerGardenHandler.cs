using MediatR;
using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Commands.FarmerGardenCommands.FarmerCommandRequest;
using SystemManagementFactory.Repositories.BaseRepository;
using SystemManagementFactory.UOW;

namespace SystemManagementFactory.Features.Commands.FarmerGardenCommands.FarmerCommandHandler;

public sealed class DeleteFarmerGardenHandler(IUnitOfWork<FarmerGarden> unitOfWork) : IRequestHandler<DeleteFarmerGardenRequest, BaseResult>
{
    public async Task<BaseResult> Handle(DeleteFarmerGardenRequest request, CancellationToken cancellationToken)
    {
        IGenericDeleteRepository<FarmerGarden> repository = unitOfWork.FarmerGardenDeleteRepository;
        IGenericFindRepository<FarmerGarden> findRepository = unitOfWork.FarmerGardenFindRepository;

        FarmerGarden? farmerGarden = await findRepository.GetByIdAsync(request.Id);
        if(farmerGarden is null)
            return BaseResult.Failure(Error.NotFound());

        await repository.DeleteAsync(farmerGarden);
        int res = await unitOfWork.Complete();
        
        return res > 0
            ? BaseResult.Success()
            : BaseResult.Failure(Error.InternalServerError());
    }
}