using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;

namespace Prototype__.NET_
{
    public partial class Register : Page
    {
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string email = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string studentId = txtStudentID.Text.Trim();
            string department = txtDepartment.Text.Trim();
            string course = txtCourse.Text.Trim();
            string userType = ddlUserType.SelectedValue;

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(studentId) || string.IsNullOrEmpty(department) ||
                string.IsNullOrEmpty(course))
            {
                Response.Write("<script>alert('Please fill in all fields.');</script>");
                return;
            }

            string connectionString = "Server=tcp:aliteam8.database.windows.net,1433;Initial Catalog=wilteam8;Persist Security Info=False;User ID=ali;Password=Drogo101;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            string hashedPassword = HashPassword(password);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (Email, PasswordHash, StudentId, Department, Course, UserType) " +
                               "VALUES (@Email, @PasswordHash, @StudentId, @Department, @Course, @UserType)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                    command.Parameters.AddWithValue("@StudentId", studentId);
                    command.Parameters.AddWithValue("@Department", department);
                    command.Parameters.AddWithValue("@Course", course);
                    command.Parameters.AddWithValue("@UserType", userType);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        Response.Write("<script>alert('Registration successful.');</script>");
                    }
                    catch (Exception ex)
                    {
                        Response.Write($"<script>alert('Error: {ex.Message}');</script>");
                    }
                }
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
