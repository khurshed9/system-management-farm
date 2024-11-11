using MediatR;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.BaceInfos;

namespace SystemManagementFactory.Features.Commands.FarmerGardenCommands.FarmerCommandRequest;

public readonly record struct CreateFarmerGardenRequest(
    FarmerGardenBaseInfo FarmerGardenBaseInfo) : IRequest<BaseResult>;