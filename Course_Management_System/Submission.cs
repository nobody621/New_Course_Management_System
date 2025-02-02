using System;
namespace Course_Management_System
{
    public class Submission
    {
        public int SubmissionID { get; set; }
        public int AssignmentID { get; set; }
        public int UserID { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string FilePath { get; set; } // Or any representation of submission data

    }
}