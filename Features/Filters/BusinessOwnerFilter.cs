using GlobalExceptionHandler.Filters;

namespace SystemManagementFactory.Features.Filters;

public record BusinessOwnerFilter(string? CompanyName) : BaseFilter;