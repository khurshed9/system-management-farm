using MediatR;
using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.Commands.FarmerCommmands.FarmerCommandRequest;
using SystemManagementFactory.Repositories.BaseRepository;
using SystemManagementFactory.UOW;

namespace SystemManagementFactory.Features.Commands.FarmerCommmands.FarmerCommandHandler;

public class DeleteFarmerHandler(IUnitOfWork<Farmer> unitOfWork) : IRequestHandler<DeleteFarmerRequest,BaseResult>
{
    public async Task<BaseResult> Handle(DeleteFarmerRequest request, CancellationToken cancellationToken)
    {
        IGenericDeleteRepository<Farmer> repository = unitOfWork.FarmerDeleteRepository;
        IGenericFindRepository<Farmer> findRepository = unitOfWork.FarmerFindRepository;

        Farmer? farmer = await findRepository.GetByIdAsync(request.Id);
        if(farmer is null)
            return BaseResult.Failure(Error.NotFound());

        await repository.DeleteAsync(farmer);
        int res = await unitOfWork.Complete();
        
        return res > 0
            ? BaseResult.Success()
             : BaseResult.Failure(Error.InternalServerError());
    }
}