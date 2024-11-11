using MediatR;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.BaceInfos;
using SystemManagementFactory.Features.Queries.Filters;
using SystemManagementFactory.Responses;

namespace SystemManagementFactory.Features.Queries.FarmerGardenQueries.FarmerGardenViewModels;

public readonly record struct GetFarmerGardenVm( 
    int Id,
    FarmerGardenBaseInfo FarmerGardenBaseInfo);
    
    
public record GetFarmerGardenVmRequest(FarmerGardenFilter Filter) : IRequest<Result<PaginationResponse<IEnumerable<GetFarmerGardenVm>>>>;