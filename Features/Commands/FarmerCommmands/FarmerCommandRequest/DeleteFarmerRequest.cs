using MediatR;
using SystemManagementFactory.Extensions.PatternResultExtensions;

namespace SystemManagementFactory.Features.Commands.FarmerCommmands.FarmerCommandRequest;

public readonly record struct DeleteFarmerRequest(int Id) : IRequest<BaseResult>;