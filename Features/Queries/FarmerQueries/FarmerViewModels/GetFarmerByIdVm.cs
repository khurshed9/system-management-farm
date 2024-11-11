using MediatR;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.BaceInfos;

namespace SystemManagementFactory.Features.Queries.FarmerQueries.FarmerViewModels;

public readonly record struct GetFarmerByIdVm(
    int Id,
    FarmerBaseInfo FarmerBaseInfo);
    
    
public record GetFarmerByIdVmRequest(int Id) :   IRequest<Result<GetFarmerByIdVm>>;