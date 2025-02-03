using System;

namespace Course_Management_System
{
    public class Report
    {
        private string _courseName;
        public string CourseName
        {
            get { return _courseName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Course Name cannot be empty.");
                }
                _courseName = value;
            }
        }
        private double _completionRate;
        public double CompletionRate
        {
            get { return _completionRate; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Completion Rate cannot be negative.");
                }
                _completionRate = value;
            }
        }
        private int _totalStudents;
        public int TotalStudents
        {
            get { return _totalStudents; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Total students cannot be negative.");
                }
                _totalStudents = value;
            }
        }
    }
}