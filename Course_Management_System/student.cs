using System;

namespace Course_Management_System
{
    public class Student : Person
    {
        public int StudentID { get; set; } // Specific to students

        public override bool Login(string password)
        {
            // Implement student-specific login logic here (e.g., authentication steps)
            // This could involve database verification
            return true; //Placeholder
        }
        public Student(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }
        public Student()
        {

        }
    }
}