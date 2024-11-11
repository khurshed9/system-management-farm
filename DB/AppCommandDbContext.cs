using Microsoft.EntityFrameworkCore;

namespace SystemManagementFactory.DB;

public sealed class AppCommandDbContext(DbContextOptions<BaseDbContext> options) : BaseDbContext(options);
