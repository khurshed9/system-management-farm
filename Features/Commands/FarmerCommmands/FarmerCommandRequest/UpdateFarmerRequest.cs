using MediatR;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.BaceInfos;

namespace SystemManagementFactory.Features.Commands.FarmerCommmands.FarmerCommandRequest;

public readonly record struct UpdateFarmerRequest(
    int Id,
    FarmerBaseInfo FarmerBaseInfo) : IRequest<BaseResult>;