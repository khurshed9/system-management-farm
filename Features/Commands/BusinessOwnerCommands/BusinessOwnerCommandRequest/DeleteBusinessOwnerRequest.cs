using MediatR;
using SystemManagementFactory.Extensions.PatternResultExtensions;

namespace SystemManagementFactory.Features.Commands.BusinessOwnerCommand.BusinessOwnerCommandRequest;

public readonly record struct DeleteBusinessOwnerRequest(int Id) : IRequest<BaseResult>;