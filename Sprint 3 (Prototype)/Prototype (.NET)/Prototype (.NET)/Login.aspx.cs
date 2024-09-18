using System;
using System.Web.UI;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using System.Threading.Tasks;

namespace Prototype__.NET_
{
    public partial class Login : System.Web.UI.Page
    {
        private static FirebaseAuth firebaseAuth;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Initialize Firebase only once when the app loads
            if (FirebaseApp.DefaultInstance == null)
            {
                FirebaseApp.Create(new AppOptions
                {
                    Credential = GoogleCredential.FromFile(Server.MapPath("~/App_Start/wilteam8xbcad-firebase-adminsdk-jkssd-e97e11b234.json"))
                });
            }

            if (firebaseAuth == null)
            {
                firebaseAuth = FirebaseAuth.DefaultInstance;
            }
        }

        protected async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim(); 
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                Response.Write("<script>alert('Please fill in all fields.');</script>");
                return;
            }

            try
            {
                
                var userCredential = await firebaseAuth.GetUserByEmailAsync(username);

                
                Response.Redirect("MainMenu.aspx");
            }
            catch (FirebaseAuthException ex)
            {
                
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }
    }
}
