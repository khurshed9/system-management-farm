using MediatR;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.BaceInfos;

namespace SystemManagementFactory.Features.Queries.CropQueries.BusinessOwnerViewModels;

public readonly record struct GetCropByIdVm(
    int Id,
    CropBaseInfo CropBaseInfo);
    
    
public record GetCropByIdVmRequest(int Id) :   IRequest<Result<GetCropByIdVm>>;