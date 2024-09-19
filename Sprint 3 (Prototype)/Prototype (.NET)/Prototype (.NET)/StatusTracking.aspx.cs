using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prototype__.NET_
{
    public partial class StatusTracking : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] != null)
                {
                    int userId = Convert.ToInt32(Session["UserID"]);
                    LoadUserQueries(userId);
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        private void LoadUserQueries(int userId)
        {
            string connectionString = "Server=tcp:aliteam8.database.windows.net,1433;Initial Catalog=wilteam8;Persist Security Info=False;User ID=ali;Password=Drogo101;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT QueryId, QueryType, Title, Status, CreatedAt FROM Queries WHERE UserId = @UserId ORDER BY CreatedAt DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);

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
        protected void btnBack_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("MainMenu.aspx"); 
        }
    }
}
