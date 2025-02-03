using System;

namespace Course_Management_System
{
    public class User
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
        private string _role;
        public string Role
        {
            get { return _role; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Role cannot be empty.");
                }
                if (value != "student" && value != "instructor")
                {
                    throw new ArgumentException("Role has to be either student or instructor");
                }
                _role = value;
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
    }
}