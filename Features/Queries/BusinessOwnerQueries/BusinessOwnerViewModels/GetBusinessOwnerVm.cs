using MediatR;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.BaceInfos;
using SystemManagementFactory.Features.Filters;
using SystemManagementFactory.Responses;

namespace SystemManagementFactory.Features.Queries.BusinessOwnerQueries.BusinessOwnerViewModels;

public readonly record struct GetBusinessOwnerVm(
    int Id,
    BusinessOwnerBaseInfo BusinessOwnerBaseInfo);
    
    
public record GetBusinessOwnerVmRequest(BusinessOwnerFilter Filter) : IRequest<Result<PaginationResponse<IEnumerable<GetBusinessOwnerVm>>>>;