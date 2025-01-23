using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Course_Management_System
{
    public class ReportDataAccess
    {
        private readonly DatabaseHelper _dbHelper;

        public ReportDataAccess(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<Report> GenerateCourseReport(int courseId, DateTime fromDate, DateTime toDate)
        {
            List<Report> reports = new List<Report>();
            try
            {
                using (MySqlConnection connection = _dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT
                                c.CourseName,
                                 (COUNT(CASE WHEN s.SubmissionDate >= @fromDate AND s.SubmissionDate <= @toDate THEN 1 END) / COUNT(s.SubmissionID) * 100) as CompletionRate,
                                 COUNT(DISTINCT u.UserID) as TotalStudents
                             FROM Courses c
                               INNER JOIN Assignments a ON c.CourseID = a.CourseID
                               LEFT JOIN Submissions s ON a.AssignmentID = s.AssignmentID
                             INNER JOIN Enrollments e ON c.CourseID = e.CourseID
                               INNER JOIN Users u ON e.UserID = u.UserID
                              WHERE c.CourseID = @courseId
                             GROUP BY c.CourseName";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@courseId", courseId);
                        command.Parameters.AddWithValue("@fromDate", fromDate);
                        command.Parameters.AddWithValue("@toDate", toDate);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                reports.Add(new Report
                                {
                                    CourseName = reader.GetString("CourseName"),
                                    CompletionRate = reader.IsDBNull(reader.GetOrdinal("CompletionRate")) ? 0 : reader.GetDouble("CompletionRate"),
                                    TotalStudents = reader.GetInt32("TotalStudents")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting course report: {ex.Message}");
            }
            return reports;
        }
    }
}