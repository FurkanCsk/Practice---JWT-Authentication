﻿using Practice_Identity_and_Data_Protection.Entities;

namespace Practice_Identity_and_Data_Protection.Dtos
{
    public class JwtDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpireMinutes { get; set; }
        public UserType UserType { get; set; }
    }
}
