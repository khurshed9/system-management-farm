using MediatR;
using SystemManagementFactory.Extensions.PatternResultExtensions;

namespace SystemManagementFactory.Features.Commands.FarmerGardenCommands.FarmerCommandRequest;

public readonly record struct DeleteFarmerGardenRequest(
    int Id) : IRequest<BaseResult>;