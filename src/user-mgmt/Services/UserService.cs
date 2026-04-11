using user_mgmt.Data;
using user_mgmt.Models;

namespace user_mgmt.Services;

public class UserService(UserRepository repository)
{
    public Task<IEnumerable<User>> GetAll()
    {
        return repository.GetAll();
    }

    public async Task<User> Get(string id)
    {
        var user = await repository.Get(id);
        if (user == null)
        {
            throw new ArgumentException($"User {id} not found");
        }

        return user;
    }

    public Task<User> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name is required");
        }

        return repository.Create(name);
    }

    public async Task Update(string id, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name is required");
        }

        var user = await repository.Get(id);
        if (user == null)
        {
            throw new ArgumentException($"User {id} not found");
        }

        await repository.Update(id, name);
    }

    public async Task Delete(string id)
    {
        var user = await repository.Get(id);
        if (user == null)
        {
            throw new ArgumentException($"User {id} not found");
        }

        await repository.Delete(id);
    }
}
