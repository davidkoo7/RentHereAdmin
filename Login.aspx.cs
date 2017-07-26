using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // checks if user-entered credentials exists in database
        if (StaffDB.isPermittedLogin(tbxEmail.Value, tbxPassword.Value)) // if exists in database, redirect to default page
        {
            Session["admin"] = tbxEmail.Value;
            Response.Redirect("Default.aspx");
        }
    }
}