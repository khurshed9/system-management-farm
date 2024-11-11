using GlobalExceptionHandler.Filters;

namespace SystemManagementFactory.Features.Queries.Filters;

public record TransactionFilter(decimal? TotalAmount) : BaseFilter;