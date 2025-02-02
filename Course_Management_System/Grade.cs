using System;

namespace Course_Management_System
{
    public class Grade
    {
        public int GradeID { get; set; }
        public int UserID { get; set; }
        public int AssignmentID { get; set; }
        public int GradeValue { get; set; }
        public string StudentName { get; set; }
        public string AssignmentTitle { get; set; }
        public string CourseName { get; set; }
    }
}