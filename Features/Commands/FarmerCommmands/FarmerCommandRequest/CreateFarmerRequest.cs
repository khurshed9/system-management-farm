using MediatR;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.BaceInfos;

namespace SystemManagementFactory.Features.Commands.FarmerCommmands.FarmerCommandRequest;

public readonly record struct CreateFarmerRequest(
    FarmerBaseInfo FarmerBaseInfo) : IRequest<BaseResult>;