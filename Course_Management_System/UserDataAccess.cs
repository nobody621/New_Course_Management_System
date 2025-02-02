using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Course_Management_System
{
    public class UserDataAccess
    {
        private readonly DatabaseHelper _dbHelper;

        public UserDataAccess(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool AddStudent(Student student)
        {
            try
            {
                using (MySqlConnection connection = _dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO Users (Username, Password, Role, Email) VALUES (@Username, @Password, @Role, @Email)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", student.Username);
                        command.Parameters.AddWithValue("@Password", student.Password); // Store plain text password
                        command.Parameters.AddWithValue("@Role", "student");
                        command.Parameters.AddWithValue("@Email", student.Email);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding student: {ex.Message}");
                return false;
            }
        }

        public bool AddInstructor(Instructor instructor)
        {
            try
            {
                using (MySqlConnection connection = _dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO Users (Username, Password, Role, Email) VALUES (@Username, @Password, @Role, @Email)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", instructor.Username);
                        command.Parameters.AddWithValue("@Password", instructor.Password); // Store plain text password
                        command.Parameters.AddWithValue("@Role", "instructor");
                        command.Parameters.AddWithValue("@Email", instructor.Email);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding instructor: {ex.Message}");
                return false;
            }
        }
        public Person GetUserByUsername(string username)
        {
            try
            {
                using (MySqlConnection connection = _dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT UserID, Username, Password, Role, Email FROM Users WHERE Username = @Username";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string role = reader.GetString("Role");
                                if (role == "student")
                                {
                                    return new Student
                                    {
                                        UserID = reader.GetInt32("UserID"),
                                        Username = reader.GetString("Username"),
                                        Password = reader.GetString("Password"), // This is PLAIN PW
                                        Email = reader.GetString("Email")
                                    };
                                }
                                else if (role == "instructor")
                                {
                                    return new Instructor
                                    {
                                        UserID = reader.GetInt32("UserID"),
                                        Username = reader.GetString("Username"),
                                        Password = reader.GetString("Password"), // This is PLAIN PW
                                        Email = reader.GetString("Email")
                                    };

                                }

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting user: {ex.Message}");
            }
            return null;
        }
        // This is insecure, as we are not verifying the password.
        public bool ValidateUser(string password, string hashedPasswordFromDb)
        {
            return password == hashedPasswordFromDb;
        }

        public bool UpdateStudent(Student student)
        {
            try
            {
                using (MySqlConnection connection = _dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE Users SET Username = @Username, Password = @Password, Email = @Email WHERE UserID = @UserID";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", student.UserID);
                        command.Parameters.AddWithValue("@Username", student.Username);
                        command.Parameters.AddWithValue("@Password", student.Password);
                        command.Parameters.AddWithValue("@Email", student.Email);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating student: {ex.Message}");
                return false;
            }

        }
        // Add any other user related methods here
    }
}