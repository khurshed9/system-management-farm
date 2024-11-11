using MediatR;
using SystemManagementFactory.Extensions.PatternResultExtensions;

namespace SystemManagementFactory.Features.Commands.CropCommmands.BusinessOwnerCommandRequest;

public readonly record struct DeleteCropRequest(int Id) : IRequest<BaseResult>;