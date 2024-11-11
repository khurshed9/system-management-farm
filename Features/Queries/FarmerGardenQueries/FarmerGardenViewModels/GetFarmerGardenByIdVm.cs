using MediatR;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.BaceInfos;

namespace SystemManagementFactory.Features.Queries.FarmerGardenQueries.FarmerGardenViewModels;

public readonly record struct GetFarmerGardenByIdVm(
    int Id,
    FarmerGardenBaseInfo FarmerGardenBaseInfo);
    
    
public record GetFarmerGardenByIdVmRequest(int Id) :  IRequest<Result<GetFarmerGardenByIdVm>>;