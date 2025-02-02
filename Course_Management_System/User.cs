using System;

namespace Course_Management_System
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } // Should be hashed
        public string Role { get; set; } // e.g., "student", "instructor"
        public string Email { get; set; }

    }
}