using System;
namespace Course_Management_System
{
    public class Submission
    {
        private int _submissionID;
        public int SubmissionID
        {
            get { return _submissionID; }
            set { _submissionID = value; }
        }
        private int _assignmentID;
        public int AssignmentID
        {
            get { return _assignmentID; }
            set { _assignmentID = value; }
        }
        private int _userID;
        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        private DateTime _submissionDate;
        public DateTime SubmissionDate
        {
            get { return _submissionDate; }
            set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("Submission Date cannot be in the future");
                }
                _submissionDate = value;
            }
        }
        private string _filePath;
        public string FilePath
        {
            get { return _filePath; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("File Path cannot be empty");
                }
                _filePath = value;
            }
        }
    }
}