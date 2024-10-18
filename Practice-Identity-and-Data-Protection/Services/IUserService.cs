using Practice_Identity_and_Data_Protection.Dtos;
using Practice_Identity_and_Data_Protection.Types;

namespace Practice_Identity_and_Data_Protection.Services
{
    public interface IUserService
    {
        Task<ServiceMessage> AddUser(AddUserDto user);
        Task<ServiceMessage<UserInfoDto>> LoginUser(LoginUserDto user);
    }
}
