using AutoMapper;
using Microsoft.EntityFrameworkCore;
using user_mgmt.Models;

namespace user_mgmt.Data;

public class UserRepository(UsersDbContext context,IMapper mapper)
{
    public async Task<IEnumerable<User>> GetAll()
    {
        var users = await context.Users.ToListAsync();
        return users.Select(mapper.Map<User>);
    }

    public async Task<User> Get(string id)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
        return mapper.Map<User>(user);
    }

    public async Task<User> Create(string name)
    {
        var user = new UserModel { Id = Guid.NewGuid().ToString(), Name = name };
        context.Users.Add(user);
        await context.SaveChangesAsync();

        return mapper.Map<User>(user);
    }

    public async Task Update(string id, string name)
    {
        var user = await context.Users.FindAsync(id);

        if (user != null)
        {
            user.Name = name;
            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(string id)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (user != null)
        {
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }
    }
}
