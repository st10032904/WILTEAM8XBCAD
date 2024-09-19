using System;
using System.Web.UI;

namespace Prototype__.NET_
{
    public partial class MainMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmitQuery_Click(object sender, EventArgs e)
        {
            Response.Redirect("SubmitQuery.aspx");
        }

        protected void btnTrackStatus_Click(object sender, EventArgs e)
        {
            Response.Redirect("StatusTracking.aspx");
        }

        protected void btnUploadDocs_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnKnowledgeBase_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnAnalytics_Click(object sender, EventArgs e)
        {
            
        }
    }
}
