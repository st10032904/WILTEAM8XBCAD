using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;

namespace Prototype__.NET_
{
    public partial class Login : Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                Response.Write("<script>alert('Please fill in all fields.');</script>");
                return;
            }

            string connectionString = "Server=tcp:aliteam8.database.windows.net,1433;Initial Catalog=wilteam8;Persist Security Info=False;User ID=ali;Password=Drogo101;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT UserID, PasswordHash, UserType FROM Users WHERE Email = @Email";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            string storedHash = reader["PasswordHash"].ToString();
                            string userType = reader["UserType"].ToString();
                            string userID = reader["UserID"].ToString(); 

                            if (VerifyPasswordHash(password, storedHash))
                            {
                                Session["UserEmail"] = email;
                                Session["UserType"] = userType;
                                Session["UserID"] = userID; 
                                Response.Redirect("MainMenu.aspx");
                            }
                            else
                            {
                                Response.Write("<script>alert('Invalid email or password.');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Invalid email or password.');</script>");
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write($"<script>alert('Error: {ex.Message}');</script>");
                    }
                }
            }
        }

        private bool VerifyPasswordHash(string password, string storedHash)
        {
            string hashedInput = HashPassword(password);
            return hashedInput.Equals(storedHash, StringComparison.OrdinalIgnoreCase);
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
