using GlobalExceptionHandler.Filters;

namespace SystemManagementFactory.Features.Queries.Filters;

public record FarmerGardenFilter(decimal? LandSize) : BaseFilter;