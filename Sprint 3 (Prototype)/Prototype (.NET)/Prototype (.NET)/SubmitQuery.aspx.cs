using System;
using System.Threading.Tasks;
using System.Web.UI;
using Firebase.Database;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;

namespace Prototype__.NET_
{
    public partial class SubmitQuery : Page
    {
        private static FirebaseClient firebaseClient;
        private static FirebaseAuth firebaseAuth;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (firebaseClient == null)
            {
                firebaseClient = new FirebaseClient("https://your-database-url.firebaseio.com/");
            }

            if (firebaseAuth == null)
            {
                InitializeFirebase();
            }
        }

        private void InitializeFirebase()
        {
            if (FirebaseApp.DefaultInstance == null)
            {
                FirebaseApp.Create(new AppOptions
                {
                    Credential = GoogleCredential.FromFile(Server.MapPath("~/App_Start/wilteam8xbcad-firebase-adminsdk-jkssd-e97e11b234.json"))
                });
                firebaseAuth = FirebaseAuth.DefaultInstance;
            }
        }

        protected async void btnSubmitQuery_Click(object sender, EventArgs e)
        {
            string category = ddlCategory.SelectedValue;
            string title = txtTitle.Text.Trim();
            string description = txtDescription.Text.Trim();
            string userId = Session["UserId"] as string;

            if (category == "Select a Category")
            {
                Response.Write("<script>alert('Please select a category.');</script>");
                return;
            }

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
            {
                Response.Write("<script>alert('Please fill in all fields.');</script>");
                return;
            }

            var query = new
            {
                Category = category,
                Title = title,
                Description = description,
                UserId = userId,
                Timestamp = DateTime.UtcNow
            };

            try
            {
                var result = await firebaseClient
                    .Child("queries")
                    .PostAsync(query);

                Response.Write("<script>alert('Your query has been submitted successfully.');</script>");
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }
    }
}
