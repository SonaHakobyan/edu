namespace user_mgmt.Data;

using Microsoft.EntityFrameworkCore;

public class UsersDbContext(DbContextOptions<UsersDbContext> options) : DbContext(options)
{
    public DbSet<UserModel> Users => Set<UserModel>();
}
