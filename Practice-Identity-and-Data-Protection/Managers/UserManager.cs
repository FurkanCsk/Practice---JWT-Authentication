using Practice_Identity_and_Data_Protection.Context;
using Practice_Identity_and_Data_Protection.Dtos;
using Practice_Identity_and_Data_Protection.Entities;
using Practice_Identity_and_Data_Protection.Services;
using Practice_Identity_and_Data_Protection.Types;

namespace Practice_Identity_and_Data_Protection.Managers
{
    public class UserManager : IUserService
    {
        private readonly CustomIdentityDbContext _dbContext;

        public UserManager(CustomIdentityDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<ServiceMessage> AddUser(AddUserDto user)
        {
            var newUser = new UserEntity
            {
                Email = user.Email,
                Password = user.Password,
            };

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();

            return new ServiceMessage
            {
                IsSucceed = true,
                Message = "The registration was successful."
            };

        }

        public async Task<ServiceMessage<UserInfoDto>> LoginUser(LoginUserDto user)
        {
            var userEntity = _dbContext.Users.Where(x => x.Email.ToLower() == user.Email.ToLower()).FirstOrDefault();

            if(userEntity is null)
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSucceed = false,
                    Message = "Wrong Email or Password."
                };
            }

            if (userEntity.Password == user.Password)
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSucceed = true,
                    Data = new UserInfoDto
                    {
                        Id = userEntity.Id,
                        Email = userEntity.Email,
                        UserType = userEntity.UserType
                    }
                };
            }
            else
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSucceed = false,
                    Message = "Wrong Email or Password."
                };
            }
        }
    }
}
