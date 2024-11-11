using GlobalExceptionHandler.Filters;
using SystemManagementFactory.Domain.Enums;

namespace SystemManagementFactory.Features.Filters;

public record PurchaseRequestFilter(PurchaseStatus? Status) : BaseFilter;