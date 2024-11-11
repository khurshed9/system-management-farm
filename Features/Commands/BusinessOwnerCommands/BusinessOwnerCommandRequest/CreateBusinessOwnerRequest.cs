using MediatR;
using SystemManagementFactory.Extensions.PatternResultExtensions;
using SystemManagementFactory.Features.BaceInfos;

namespace SystemManagementFactory.Features.Commands.BusinessOwnerCommand.BusinessOwnerCommandRequest;

public readonly record struct CreateBusinessOwnerRequest(
    BusinessOwnerBaseInfo BusinessOwnerBaseInfo) : IRequest<BaseResult>;