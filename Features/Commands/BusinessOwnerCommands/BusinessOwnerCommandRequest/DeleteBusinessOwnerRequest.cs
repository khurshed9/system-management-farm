using MediatR;
using SystemManagementFactory.Extensions.PatternResultExtensions;

namespace SystemManagementFactory.Features.Commands.BusinessOwnerCommands.BusinessOwnerCommandRequest;

public readonly record struct DeleteBusinessOwnerRequest(int Id) : IRequest<BaseResult>;