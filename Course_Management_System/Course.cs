using System;

namespace Course_Management_System
{
    public class Course
    {
        private int _courseID;
        public int CourseID
        {
            get { return _courseID; }
            set { _courseID = value; }
        }

        private string _courseName;
        public string CourseName
        {
            get { return _courseName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Course name cannot be empty");
                }
                _courseName = value;
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Description cannot be null or empty");
                }
                _description = value;
            }
        }
        private string _duration;
        public string Duration
        {
            get { return _duration; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Duration cannot be null or empty");
                }
                _duration = value;
            }
        }
        private string _syllabus;
        public string Syllabus
        {
            get { return _syllabus; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Syllabus cannot be null or empty");
                }
                _syllabus = value;
            }
        }

        public Course()
        {
        }
        public Course(int courseId, string courseName, string description, string duration, string syllabus)
        {
            this._courseID = courseId;
            this._courseName = courseName;
            this._description = description;
            this._duration = duration;
            this._syllabus = syllabus;
        }
    }
}