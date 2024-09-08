using System;
using System.Web.UI;

namespace Prototype__.NET_
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

           
            UserStore.User user = UserStore.GetUser(username);

            if (user != null && user.Password == password)
            {
                
                Response.Redirect("MainMenu.aspx");
            }
            else
            {
               
                Response.Write("<script>alert('Invalid username or password.');</script>");
            }
        }
    }
}
