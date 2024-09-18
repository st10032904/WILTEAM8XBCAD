using System;
using System.Web.UI;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Firebase.Database;
using Google.Apis.Auth.OAuth2;
using System.Threading.Tasks;
using Firebase.Database.Query;

namespace Prototype__.NET_
{
    public partial class Register : System.Web.UI.Page
    {
        private static FirebaseClient firebaseClient;

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

            if (firebaseClient == null)
            {
                firebaseClient = new FirebaseClient("https://wilteam8xbcad-default-rtdb.firebaseio.com/");
            }
        }

        protected async void btnRegister_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                Response.Write("<script>alert('Please fill in all fields.');</script>");
                return;
            }

            try
            {
                // Create a new user in Firebase 
                UserRecordArgs userRecordArgs = new UserRecordArgs
                {
                    Email = username,
                    Password = password,
                    DisplayName = $"{firstName} {lastName}"
                };

                UserRecord userRecord = await FirebaseAuth.DefaultInstance.CreateUserAsync(userRecordArgs);

               
                await StoreUserDetailsInDatabase(userRecord.Uid, firstName, lastName);

                
                Response.Redirect("Login.aspx");
            }
            catch (FirebaseAuthException ex)
            {
               
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }

       
        public async Task StoreUserDetailsInDatabase(string uid, string firstName, string lastName)
        {
            
            await firebaseClient
                .Child("users")
                .Child(uid)
                .PutAsync(new
                {
                    FirstName = firstName,
                    LastName = lastName,
                    CreatedAt = DateTime.UtcNow
                });
        }
    }
}
