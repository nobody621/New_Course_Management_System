using System;

namespace Course_Management_System
{
    public class Grade
    {
        private int _gradeID;
        public int GradeID
        {
            get { return _gradeID; }
            set { _gradeID = value; }
        }
        private int _userID;
        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        private int _assignmentID;
        public int AssignmentID
        {
            get { return _assignmentID; }
            set { _assignmentID = value; }
        }
        private int _gradeValue;
        public int GradeValue
        {
            get { return _gradeValue; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Grade value cannot be negative");
                _gradeValue = value;
            }
        }
        private string _studentName;
        public string StudentName
        {
            get { return _studentName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Student name cannot be null or empty.");
                _studentName = value;
            }
        }
        private string _assignmentTitle;
        public string AssignmentTitle
        {
            get { return _assignmentTitle; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Assignment title cannot be null or empty.");
                _assignmentTitle = value;
            }
        }
        private string _courseName;
        public string CourseName
        {
            get { return _courseName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Course name cannot be null or empty.");
                _courseName = value;
            }
        }
    }
}