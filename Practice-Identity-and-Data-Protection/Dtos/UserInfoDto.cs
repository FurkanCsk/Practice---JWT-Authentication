using Practice_Identity_and_Data_Protection.Entities;

namespace Practice_Identity_and_Data_Protection.Dtos
{
    public class UserInfoDto
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public UserType UserType { get; set; }
    }
}
