using GlobalExceptionHandler.Filters;

namespace SystemManagementFactory.Features.Queries.Filters;

public record FarmerFilter(int? Experience) : BaseFilter;