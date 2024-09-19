using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prototype__.NET_
{
    public partial class StaffDashboard : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] != null && Session["Department"] != null)
                {
                    int userId = Convert.ToInt32(Session["UserID"]);
                    string department = Session["Department"].ToString();
                    LoadUserQueries(department);
                }
                else
                {
                    Response.Redirect("StaffLogin.aspx");
                }
            }
        }

        private void LoadUserQueries(string department)
        {
            string connectionString = "Server=tcp:aliteam8.database.windows.net,1433;Initial Catalog=wilteam8;Persist Security Info=False;User ID=ali;Password=Drogo101;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT QueryId, QueryType, Title, Status, CreatedAt FROM Queries WHERE QueryType = @Department ORDER BY CreatedAt DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Department", department);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            GridViewQueries.DataSource = reader;
                            GridViewQueries.DataBind();
                        }
                        else
                        {
                            lblMessage.Text = "No queries found.";
                        }
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = $"Error: {ex.Message}";
                    }
                }
            }
        }

        protected void GridViewQueries_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UpdateStatus")
            {
                int queryId = Convert.ToInt32(e.CommandArgument);
                UpdateQueryStatus(queryId);
            }
        }

        private void UpdateQueryStatus(int queryId)
        {
            string newStatus = "Closed"; 

            string connectionString = "Server=tcp:aliteam8.database.windows.net,1433;Initial Catalog=wilteam8;Persist Security Info=False;User ID=ali;Password=Drogo101;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Queries SET Status = @Status WHERE QueryId = @QueryId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Status", newStatus);
                    command.Parameters.AddWithValue("@QueryId", queryId);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            lblMessage.Text = "Status updated successfully.";
                            LoadUserQueries(Session["Department"].ToString()); 
                        }
                        else
                        {
                            lblMessage.Text = "Error updating status.";
                        }
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = $"Error: {ex.Message}";
                    }
                }
            }
        }
    }
}
