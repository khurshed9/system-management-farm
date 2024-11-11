using MediatR;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.BaceInfos;
using SystemManagementFactory.Features.Queries.Filters;
using SystemManagementFactory.Responses;

namespace SystemManagementFactory.Features.Queries.FarmerQueries.FarmerViewModels;

public readonly record struct GetFarmerVm(
    int Id,
    FarmerBaseInfo FarmerBaseInfo);
    
    
public record GetFarmerVmRequest(FarmerFilter Filter) : IRequest<Result<PaginationResponse<IEnumerable<GetFarmerVm>>>>;