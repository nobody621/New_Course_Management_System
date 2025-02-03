using System;

namespace Course_Management_System
{
    public class Assignment
    {
        private int _assignmentID;
        public int AssignmentID
        {
            get { return _assignmentID; }
            set { _assignmentID = value; }
        }

        private int _courseID;
        public int CourseID
        {
            get { return _courseID; }
            set { _courseID = value; }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Assignment title cannot be null or empty.");
                }
                _title = value;
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Assignment description cannot be null or empty.");
                _description = value;
            }
        }

        private DateTime _dueDate;
        public DateTime DueDate
        {
            get { return _dueDate; }
            set
            {
                if (value < DateTime.Now)
                {
                    throw new ArgumentException("Due Date cannot be in the past.");
                }
                _dueDate = value;
            }
        }
    }
}