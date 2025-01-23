using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Course_Management_System
{
    public class EnrollmentDataAccess
    {
        private readonly DatabaseHelper _dbHelper;

        public EnrollmentDataAccess(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<Enrollment> GetAllEnrollmentRequests()
        {
            List<Enrollment> enrollments = new List<Enrollment>();
            try
            {
                using (MySqlConnection connection = _dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT EnrollmentID, UserID, CourseID, RequestDate, Status FROM Enrollments";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                enrollments.Add(new Enrollment
                                {
                                    EnrollmentID = reader.GetInt32("EnrollmentID"),
                                    UserID = reader.GetInt32("UserID"),
                                    CourseID = reader.GetInt32("CourseID"),
                                    RequestDate = reader.GetDateTime("RequestDate"),
                                    Status = reader.GetString("Status")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting Enrollments: {ex.Message}");
            }
            return enrollments;
        }

        public bool AddEnrollment(Enrollment enrollment)
        {
            try
            {
                using (MySqlConnection connection = _dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO Enrollments (UserID, CourseID, RequestDate, Status) VALUES (@UserID, @CourseID, @RequestDate, @Status)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", enrollment.UserID);
                        command.Parameters.AddWithValue("@CourseID", enrollment.CourseID);
                        command.Parameters.AddWithValue("@RequestDate", enrollment.RequestDate);
                        command.Parameters.AddWithValue("@Status", enrollment.Status);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding Enrollment: {ex.Message}");
                return false;
            }
        }

        public bool UpdateEnrollment(Enrollment enrollment)
        {
            try
            {
                using (MySqlConnection connection = _dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE Enrollments SET UserID = @UserID, CourseID = @CourseID, RequestDate = @RequestDate, Status = @Status WHERE EnrollmentID = @EnrollmentID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EnrollmentID", enrollment.EnrollmentID);
                        command.Parameters.AddWithValue("@UserID", enrollment.UserID);
                        command.Parameters.AddWithValue("@CourseID", enrollment.CourseID);
                        command.Parameters.AddWithValue("@RequestDate", enrollment.RequestDate);
                        command.Parameters.AddWithValue("@Status", enrollment.Status);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating Enrollment: {ex.Message}");
                return false;
            }
        }

        public bool DeleteEnrollment(int enrollmentId)
        {
            try
            {
                using (MySqlConnection connection = _dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM Enrollments WHERE EnrollmentID = @EnrollmentID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EnrollmentID", enrollmentId);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting enrollment: {ex.Message}");
                return false;
            }
        }

        public Enrollment GetEnrollmentById(int enrollmentId)
        {
            try
            {
                using (MySqlConnection connection = _dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT EnrollmentID, UserID, CourseID, RequestDate, Status FROM Enrollments WHERE EnrollmentID = @EnrollmentID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EnrollmentID", enrollmentId);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Enrollment
                                {
                                    EnrollmentID = reader.GetInt32("EnrollmentID"),
                                    UserID = reader.GetInt32("UserID"),
                                    CourseID = reader.GetInt32("CourseID"),
                                    RequestDate = reader.GetDateTime("RequestDate"),
                                    Status = reader.GetString("Status")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting enrollment: {ex.Message}");
            }
            return null;
        }
    }
}