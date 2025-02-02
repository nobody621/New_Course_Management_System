using System;

namespace Course_Management_System
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int UserID { get; set; }
        public int CourseID { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; } // e.g., "pending", "approved", "rejected"
    }
}