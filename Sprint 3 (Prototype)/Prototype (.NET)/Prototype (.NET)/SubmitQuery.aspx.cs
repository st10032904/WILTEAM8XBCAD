using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace Prototype__.NET_
{
    public partial class SubmitQuery : Page
    {
        protected void btnSubmitQuery_Click(object sender, EventArgs e)
        {
            string queryType = ddlQueryType.SelectedValue;
            string title = txtTitle.Text.Trim();
            string description = txtDescription.Text.Trim();
            string userId = Session["UserId"].ToString();

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(queryType) || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
            {
                Response.Write("<script>alert('Please fill in all fields.');</script>");
                return;
            }

            string connectionString = "Server=tcp:aliteam8.database.windows.net,1433;Initial Catalog=wilteam8;Persist Security Info=False;User ID=ali;Password=Drogo101;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Queries (UserId, QueryType, Title, Description) VALUES (@UserId, @QueryType, @Title, @Description)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@QueryType", queryType);
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@Description", description);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        Response.Write("<script>alert('Query submitted successfully.');</script>");
                    }
                    catch (Exception ex)
                    {
                        Response.Write($"<script>alert('Error: {ex.Message}');</script>");
                    }
                }
            }
        }
    }
}
