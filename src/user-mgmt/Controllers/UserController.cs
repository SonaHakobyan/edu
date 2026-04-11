using Microsoft.AspNetCore.Mvc;
using user_mgmt.Models;
using user_mgmt.Services;

namespace user_mgmt.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(UserService service) : ControllerBase
{
    [HttpGet]
    public Task<IEnumerable<User>> GetAll()
    {
        return service.GetAll();
    }

    [HttpGet("{id}")]
    public Task<User> Get(string id)
    {
        return service.Get(id);
    }

    [HttpPost]
    public Task<User> Create(string name)
    {
        return service.Create(name);
    }

    [HttpPut("{id}")]
    public Task Update(string id, string name)
    {
        return service.Update(id, name);
    }

    [HttpDelete("{id}")]
    public async Task Delete(string id)
    {
        await service.Delete(id);
    }
}
