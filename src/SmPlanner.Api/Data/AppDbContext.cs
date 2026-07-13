using Microsoft.EntityFrameworkCore;

namespace SmPlanner.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
}
