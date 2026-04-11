using System.ComponentModel.DataAnnotations;

namespace user_mgmt.Data;

public class UserModel
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string Name { get; set; }
}
