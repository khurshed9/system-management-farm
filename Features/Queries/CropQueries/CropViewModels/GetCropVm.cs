using MediatR;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.BaceInfos;
using SystemManagementFactory.Features.Filters;
using SystemManagementFactory.Responses;

namespace SystemManagementFactory.Features.Queries.CropQueries.BusinessOwnerViewModels;

public readonly record struct GetCropVm(
    int Id,
    CropBaseInfo CropBaseInfo);
    
    
public record GetCropVmRequest(CropFilter Filter) : IRequest<Result<PaginationResponse<IEnumerable<GetCropVm>>>>;