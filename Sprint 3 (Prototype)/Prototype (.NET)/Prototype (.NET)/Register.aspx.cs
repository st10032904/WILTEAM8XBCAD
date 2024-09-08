using System;
using System.Web.UI;

namespace Prototype__.NET_
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegister_Click(object sender, EventArgs e)
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

            
            UserStore.AddUser(username, password, firstName, lastName);

            // Redirect to login page after successful registration
            Response.Redirect("Login.aspx");
        }
    }
}
