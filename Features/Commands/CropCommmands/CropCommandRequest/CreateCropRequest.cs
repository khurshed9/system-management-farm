using MediatR;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.BaceInfos;

namespace SystemManagementFactory.Features.Commands.CropCommmands.BusinessOwnerCommandRequest;

public readonly record struct CreateCropRequest(
    CropBaseInfo CropBaseInfo) : IRequest<BaseResult>;