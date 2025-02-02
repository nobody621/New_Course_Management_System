using System;

namespace Course_Management_System
{
    public abstract class Person
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } // Should be hashed
        public string Email { get; set; }

        // Abstract login method for child classes to implement
        public abstract bool Login(string password);
    }
}