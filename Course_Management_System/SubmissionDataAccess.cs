using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Course_Management_System
{
    public class SubmissionDataAccess
    {
        private readonly DatabaseHelper _dbHelper;

        public SubmissionDataAccess(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<Submission> GetAllSubmissions()
        {
            List<Submission> submissions = new List<Submission>();
            try
            {
                using (MySqlConnection connection = _dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT SubmissionID, AssignmentID, UserID, SubmissionDate, FilePath FROM Submissions";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                submissions.Add(new Submission
                                {
                                    SubmissionID = reader.GetInt32("SubmissionID"),
                                    AssignmentID = reader.GetInt32("AssignmentID"),
                                    UserID = reader.GetInt32("UserID"),
                                    SubmissionDate = reader.GetDateTime("SubmissionDate"),
                                    FilePath = reader.GetString("FilePath")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting submissions: {ex.Message}");
            }
            return submissions;
        }

        public bool AddSubmission(Submission submission)
        {
            try
            {
                using (MySqlConnection connection = _dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO Submissions (AssignmentID, UserID, SubmissionDate, FilePath) VALUES (@AssignmentID, @UserID, @SubmissionDate, @FilePath)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AssignmentID", submission.AssignmentID);
                        command.Parameters.AddWithValue("@UserID", submission.UserID);
                        command.Parameters.AddWithValue("@SubmissionDate", submission.SubmissionDate);
                        command.Parameters.AddWithValue("@FilePath", submission.FilePath);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding submission: {ex.Message}");
                return false;
            }
        }

        public bool UpdateSubmission(Submission submission)
        {
            try
            {
                using (MySqlConnection connection = _dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE Submissions SET AssignmentID = @AssignmentID, UserID = @UserID, SubmissionDate = @SubmissionDate, FilePath = @FilePath WHERE SubmissionID = @SubmissionID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SubmissionID", submission.SubmissionID);
                        command.Parameters.AddWithValue("@AssignmentID", submission.AssignmentID);
                        command.Parameters.AddWithValue("@UserID", submission.UserID);
                        command.Parameters.AddWithValue("@SubmissionDate", submission.SubmissionDate);
                        command.Parameters.AddWithValue("@FilePath", submission.FilePath);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating submission: {ex.Message}");
                return false;
            }
        }

        public bool DeleteSubmission(int submissionId)
        {
            try
            {
                using (MySqlConnection connection = _dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM Submissions WHERE SubmissionID = @SubmissionID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SubmissionID", submissionId);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting submission: {ex.Message}");
                return false;
            }
        }

        public Submission GetSubmissionById(int submissionId)
        {
            try
            {
                using (MySqlConnection connection = _dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT SubmissionID, AssignmentID, UserID, SubmissionDate, FilePath FROM Submissions WHERE SubmissionID = @SubmissionID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SubmissionID", submissionId);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Submission
                                {
                                    SubmissionID = reader.GetInt32("SubmissionID"),
                                    AssignmentID = reader.GetInt32("AssignmentID"),
                                    UserID = reader.GetInt32("UserID"),
                                    SubmissionDate = reader.GetDateTime("SubmissionDate"),
                                    FilePath = reader.GetString("FilePath")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting submission: {ex.Message}");
            }
            return null;
        }
    }
}