using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

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
            catch (Exception ex)
            {
                Console.WriteLine($"Error Adding Course: {ex.Message}");
            }
            return false;
        }

        public bool UpdateCourse(Course course)
        {
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error Updating course: {ex.Message}");
            }
            return false;
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting course: {ex.Message}");
            }
            return false;
        }
    }
}