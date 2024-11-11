using Microsoft.EntityFrameworkCore;
using SystemManagementFactory.Domain.Entities;

namespace SystemManagementFactory.DB;

public sealed class AppQueryDbContext(DbContextOptions<BaseDbContext> options) : BaseDbContext(options);