using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace Prototype__.NET_
{
    public partial class StaffLogin : Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Please fill in all fields.";
                return;
            }

            string connectionString = "Server=tcp:aliteam8.database.windows.net,1433;Initial Catalog=wilteam8;Persist Security Info=False;User ID=ali;Password=Drogo101;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT PasswordHash, UserId, Department FROM Users WHERE Email = @Email AND UserType = 'Staff'";

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
                            int userId = Convert.ToInt32(reader["UserId"]);
                            string department = reader["Department"].ToString();

                            if (VerifyPasswordHash(password, storedHash))
                            {
                                Session["UserID"] = userId;
                                Session["Department"] = department;

                                // Redirect to staff dashboard
                                Response.Redirect("StaffDashboard.aspx");
                            }
                            else
                            {
                                lblMessage.Text = "Invalid email or password.";
                            }
                        }
                        else
                        {
                            lblMessage.Text = "Invalid email or password.";
                        }
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = $"Error: {ex.Message}";
                    }
                }
            }
        }

        private bool VerifyPasswordHash(string password, string storedHash)
        {
            // Implement password hash verification logic
            // Example: return BCrypt.Net.BCrypt.Verify(password, storedHash);
            return true; // Replace with actual verification
        }
    }
}
