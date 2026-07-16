using Microsoft.EntityFrameworkCore;

namespace SmPlanner.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
}
