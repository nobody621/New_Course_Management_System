using System;

namespace Course_Management_System
{
    public class Instructor : Person
    {
        public int InstructorId { get; set; } // Specific to instructors

        public override bool Login(string password)
        {
            // Implement instructor-specific login logic here
            // This could involve database verification
            return true;  //Placeholder
        }
        public Instructor(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }
        public Instructor()
        {

        }
    }
}