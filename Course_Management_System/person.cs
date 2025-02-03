using System;

namespace Course_Management_System
{
    public abstract class Person
    {
        private int _userID;
        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Username cannot be empty.");
                }
                _username = value;
            }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Password cannot be empty.");
                }
                _password = value;
            }
        }
        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Email cannot be empty.");
                }
                _email = value;
            }
        }
        // Abstract login method for child classes to implement
        public abstract bool Login(string password);
    }
}