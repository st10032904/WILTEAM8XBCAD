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
           
            string selectedCategory = ddlQueryCategory.SelectedValue;
            Response.Write($"<script>alert('Submitting query for category: {selectedCategory}');</script>");
        }

        protected void btnTrackStatus_Click(object sender, EventArgs e)
        {
            
            Response.Write("<script>alert('Status tracking button clicked.');</script>");
        }

        protected void btnUploadDocs_Click(object sender, EventArgs e)
        {
            
            Response.Write("<script>alert('Upload Documents button clicked.');</script>");
        }

        protected void btnKnowledgeBase_Click(object sender, EventArgs e)
        {
           
            Response.Write("<script>alert('Browse FAQs button clicked.');</script>");
        }

        protected void btnAnalytics_Click(object sender, EventArgs e)
        {
            
            Response.Write("<script>alert('Analytics & Reporting button clicked.');</script>");
        }
    }
}
