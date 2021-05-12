﻿namespace SharedLib.Models
{
    public class UserAccount
    {
        public UserAccount(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}