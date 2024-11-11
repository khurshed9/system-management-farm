using MediatR;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.BaceInfos;

namespace SystemManagementFactory.Features.Queries.BusinessOwnerQueries.BusinessOwnerViewModels;

public readonly record struct GetBusinessOwnerByIdVm(
    int Id,
    BusinessOwnerBaseInfo BusinessOwnerBaseInfo);
    
    
public record GetBusinessOwnerByIdVmRequest(int Id) :   IRequest<Result<GetBusinessOwnerByIdVm>>;