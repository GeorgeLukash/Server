﻿namespace FitnessTracker.DataAccess.Entity
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }

        public int Role { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }

        public UserProfileEntity Profile { get; set; }
        public ExpirationTokenEntity Token { get; set; }
    }
}