using user_mgmt.Data;
using AutoMapper;

namespace user_mgmt.Models;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserModel>().ReverseMap();
    }
}
