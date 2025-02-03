using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace Course_Management_System
{
    public class GradeDataAccess : IDataAccess<Grade>
    {
        private readonly DatabaseHelper _dbHelper;
        public GradeDataAccess(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public bool Add(Grade grade)
        {
            return AddGrade(grade);
        }
        public bool Delete(int gradeId)
        {
            return DeleteGrade(gradeId);
        }
        public bool Update(Grade grade)
        {
            return UpdateGrade(grade);
        }
        public List<Grade> GetAll()
        {
            return GetAllGrades();
        }

        public List<Grade> GetAllGrades()
        {
            List<Grade> grades = new List<Grade>();
            try
            {
                using (MySqlConnection connection = _dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT GradeID, UserID, AssignmentID, Grade FROM Grades";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                grades.Add(new Grade
                                {
                                    GradeID = reader.GetInt32("GradeID"),
                                    UserID = reader.GetInt32("UserID"),
                                    AssignmentID = reader.GetInt32("AssignmentID"),
                                    GradeValue = reader.GetInt32("Grade")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting Grades: {ex.Message}");
            }
            return grades;
        }

        public List<Grade> GetGradesByStudent(string studentName)
        {
            List<Grade> grades = new List<Grade>();
            try
            {
                using (MySqlConnection connection = _dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT g.GradeID, g.UserID, g.AssignmentID, g.Grade, u.Username, a.Title as AssignmentTitle, c.CourseName
                                 FROM Grades g
                                 INNER JOIN Users u ON g.UserID = u.UserID
                                 INNER JOIN Assignments a ON g.AssignmentID = a.AssignmentID
                                  INNER JOIN Courses c ON a.CourseID = c.CourseID
                                 WHERE u.Username = @studentName";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@studentName", studentName);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                grades.Add(new Grade
                                {
                                    GradeID = reader.GetInt32("GradeID"),
                                    UserID = reader.GetInt32("UserID"),
                                    AssignmentID = reader.GetInt32("AssignmentID"),
                                    GradeValue = reader.GetInt32("Grade"),
                                    StudentName = reader.GetString("Username"),
                                    AssignmentTitle = reader.GetString("AssignmentTitle"),
                                    CourseName = reader.GetString("CourseName")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting Grades: {ex.Message}");
            }
            return grades;
        }
        public bool AddGrade(Grade grade)
        {
            try
            {
                using (MySqlConnection connection = _dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO Grades (UserID, AssignmentID, Grade) VALUES (@UserID, @AssignmentID, @Grade)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", grade.UserID);
                        command.Parameters.AddWithValue("@AssignmentID", grade.AssignmentID);
                        command.Parameters.AddWithValue("@Grade", grade.GradeValue);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool UpdateGrade(Grade grade)
        {
            try
            {
                using (MySqlConnection connection = _dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE Grades SET UserID = @UserID, AssignmentID = @AssignmentID, Grade = @Grade WHERE GradeID = @GradeID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@GradeID", grade.GradeID);
                        command.Parameters.AddWithValue("@UserID", grade.UserID);
                        command.Parameters.AddWithValue("@AssignmentID", grade.AssignmentID);
                        command.Parameters.AddWithValue("@Grade", grade.GradeValue);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool DeleteGrade(int gradeId)
        {
            try
            {
                using (MySqlConnection connection = _dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM Grades WHERE GradeID = @GradeID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@GradeID", gradeId);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public Grade GetGradeById(int gradeId)
        {
            try
            {
                using (MySqlConnection connection = _dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT GradeID, UserID, AssignmentID, Grade FROM Grades WHERE GradeID = @GradeID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@GradeID", gradeId);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Grade
                                {
                                    GradeID = reader.GetInt32("GradeID"),
                                    UserID = reader.GetInt32("UserID"),
                                    AssignmentID = reader.GetInt32("AssignmentID"),
                                    GradeValue = reader.GetInt32("Grade")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting grade: {ex.Message}");
            }
            return null;
        }
    }
}