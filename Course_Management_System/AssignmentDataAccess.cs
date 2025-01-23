using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Course_Management_System
{
    public class AssignmentDataAccess
    {
        private readonly DatabaseHelper _dbHelper;

        public AssignmentDataAccess(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<Assignment> GetAllAssignments()
        {
            List<Assignment> assignments = new List<Assignment>();
            try
            {
                using (MySqlConnection connection = _dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT AssignmentID, CourseID, Title, Description, DueDate FROM Assignments";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                assignments.Add(new Assignment
                                {
                                    AssignmentID = reader.GetInt32("AssignmentID"),
                                    CourseID = reader.GetInt32("CourseID"),
                                    Title = reader.GetString("Title"),
                                    Description = reader.GetString("Description"),
                                    DueDate = reader.GetDateTime("DueDate")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting assignments: {ex.Message}");
            }
            return assignments;
        }

        public bool AddAssignment(Assignment assignment)
        {
            try
            {
                using (MySqlConnection connection = _dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO Assignments (CourseID, Title, Description, DueDate) VALUES (@CourseID, @Title, @Description, @DueDate)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CourseID", assignment.CourseID);
                        command.Parameters.AddWithValue("@Title", assignment.Title);
                        command.Parameters.AddWithValue("@Description", assignment.Description);
                        command.Parameters.AddWithValue("@DueDate", assignment.DueDate);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding assignment: {ex.Message}");
                return false;
            }
        }

        public bool UpdateAssignment(Assignment assignment)
        {
            try
            {
                using (MySqlConnection connection = _dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE Assignments SET CourseID = @CourseID, Title = @Title, Description = @Description, DueDate = @DueDate WHERE AssignmentID = @AssignmentID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AssignmentID", assignment.AssignmentID);
                        command.Parameters.AddWithValue("@CourseID", assignment.CourseID);
                        command.Parameters.AddWithValue("@Title", assignment.Title);
                        command.Parameters.AddWithValue("@Description", assignment.Description);
                        command.Parameters.AddWithValue("@DueDate", assignment.DueDate);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating assignment: {ex.Message}");
                return false;
            }
        }

        public bool DeleteAssignment(int assignmentId)
        {
            try
            {
                using (MySqlConnection connection = _dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM Assignments WHERE AssignmentID = @AssignmentID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AssignmentID", assignmentId);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting assignment: {ex.Message}");
                return false;
            }
        }

        public Assignment GetAssignmentById(int assignmentId)
        {
            try
            {
                using (MySqlConnection connection = _dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT AssignmentID, CourseID, Title, Description, DueDate FROM Assignments WHERE AssignmentID = @AssignmentID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AssignmentID", assignmentId);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Assignment
                                {
                                    AssignmentID = reader.GetInt32("AssignmentID"),
                                    CourseID = reader.GetInt32("CourseID"),
                                    Title = reader.GetString("Title"),
                                    Description = reader.GetString("Description"),
                                    DueDate = reader.GetDateTime("DueDate")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting assignment: {ex.Message}");
            }
            return null;
        }

    }
}