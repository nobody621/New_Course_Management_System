using System;

namespace Course_Management_System
{
    public class Enrollment
    {
        private int _enrollmentID;
        public int EnrollmentID
        {
            get { return _enrollmentID; }
            set { _enrollmentID = value; }
        }
        private int _userID;
        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        private int _courseID;
        public int CourseID
        {
            get { return _courseID; }
            set { _courseID = value; }
        }
        private DateTime _requestDate;
        public DateTime RequestDate
        {
            get { return _requestDate; }
            set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("Request Date cannot be in the future.");
                }
                _requestDate = value;
            }
        }
        private string _status;
        public string Status
        {
            get { return _status; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Status cannot be empty.");
                }
                if (value != "pending" && value != "approved" && value != "rejected")
                {
                    throw new ArgumentException("Status can only be 'pending', 'approved', or 'rejected'");

                }
                _status = value;
            }
        }

    }
}