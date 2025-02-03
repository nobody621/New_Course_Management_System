using System;
namespace Course_Management_System
{
    public class Student : Person
    {
        private int _studentID;
        public int StudentID
        {
            get { return _studentID; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Student ID cannot be less than 0");
                }
                _studentID = value;
            }
        }
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