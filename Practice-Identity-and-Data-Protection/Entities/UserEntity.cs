namespace Practice_Identity_and_Data_Protection.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserType UserType  { get; set; }

    }

    public enum UserType
    {
        User,Admin
    }
}
