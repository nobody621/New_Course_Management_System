using System;
namespace Course_Management_System
{
    public class Instructor : Person
    {
        private int _instructorId;
        public int InstructorId
        {
            get { return _instructorId; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Instructor Id cannot be less than 0");
                }
                _instructorId = value;
            }
        }
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