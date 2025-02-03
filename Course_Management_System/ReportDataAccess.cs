using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Course_Management_System
{
    public class ReportDataAccess : IDataAccess<Report>
    {
        private readonly DatabaseHelper _dbHelper;

        public ReportDataAccess(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public bool Add(Report entity)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int entityId)
        {
            throw new NotImplementedException();
        }
        public bool Update(Report entity)
        {
            throw new NotImplementedException();
        }
        public List<Report> GetAll()
        {
            throw new NotImplementedException();
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
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return reports;
        }
    }
}