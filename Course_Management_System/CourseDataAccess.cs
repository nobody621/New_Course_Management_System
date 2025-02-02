using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Windows.Forms; //Needed for the messagebox

namespace Course_Management_System
{
    public class CourseDataAccess
    {
        private readonly DatabaseHelper _dbHelper;

        public CourseDataAccess(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<Course> GetAllCourses()
        {
            List<Course> courses = new List<Course>();
            try
            {
                using (MySqlConnection connection = _dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT CourseID, CourseName, Description, Duration, Syllabus FROM Courses";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                courses.Add(new Course(
                                reader.GetInt32("CourseID"),
                                reader.GetString("CourseName"),
                                reader.GetString("Description"),
                                reader.GetString("Duration"),
                                reader.GetString("Syllabus")
                            ));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting courses: {ex.Message}");
            }
            return courses;
        }

        public bool AddCourse(Course course)
        {
            if (string.IsNullOrEmpty(course.CourseName) || string.IsNullOrEmpty(course.Description) ||
                string.IsNullOrEmpty(course.Duration) || string.IsNullOrEmpty(course.Syllabus))
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Indicate failure due to invalid input
            }
            try
            {
                using (MySqlConnection connection = _dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO Courses (CourseName, Description, Duration, Syllabus) VALUES (@CourseName, @Description, @Duration, @Syllabus)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CourseName", course.CourseName);
                        command.Parameters.AddWithValue("@Description", course.Description);
                        command.Parameters.AddWithValue("@Duration", course.Duration);
                        command.Parameters.AddWithValue("@Syllabus", course.Syllabus);

                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Indicate failure due to database error
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Indicate failure due to unexpected error
            }
        }

        public bool UpdateCourse(Course course)
        {
            if (string.IsNullOrEmpty(course.CourseName) || string.IsNullOrEmpty(course.Description) ||
               string.IsNullOrEmpty(course.Duration) || string.IsNullOrEmpty(course.Syllabus))
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Indicate failure due to invalid input
            }
            try
            {
                using (MySqlConnection connection = _dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE Courses SET CourseName = @CourseName, Description = @Description, Duration = @Duration, Syllabus = @Syllabus WHERE CourseID = @CourseID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CourseID", course.CourseID);
                        command.Parameters.AddWithValue("@CourseName", course.CourseName);
                        command.Parameters.AddWithValue("@Description", course.Description);
                        command.Parameters.AddWithValue("@Duration", course.Duration);
                        command.Parameters.AddWithValue("@Syllabus", course.Syllabus);

                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Indicate failure due to database error
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Indicate failure due to unexpected error
            }
        }

        public bool DeleteCourse(int courseId)
        {
            try
            {
                using (MySqlConnection connection = _dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM Courses WHERE CourseID = @CourseID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CourseID", courseId);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Indicate failure due to database error
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Indicate failure due to unexpected error
            }
        }
    }
}