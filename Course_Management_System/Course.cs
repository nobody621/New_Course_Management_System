using System;

namespace Course_Management_System
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string Syllabus { get; set; }

        public Course()
        {
        }
        public Course(int courseId, string courseName, string description, string duration, string syllabus)
        {
            this.CourseID = courseId;
            this.CourseName = courseName;
            this.Description = description;
            this.Duration = duration;
            this.Syllabus = syllabus;
        }
    }
}
