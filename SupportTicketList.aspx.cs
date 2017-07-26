using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SupportTicketList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // displays a full list of all support tickets from the database to be reviewed

        // checks if user is logged in
        if (Session["admin"] == null) // if user is not logged in, redirect to login page
        {
            Response.Redirect("Login.aspx");
            return;
        }

        // allows user to filter list by support ticket status
        List<SupportTicket> supportTicketList = SupportTicketDB.getAllSupportTicket();
        List<SupportTicket> supportTicketListStatus = SupportTicketDB.getAnsweredSupportTicket();
        List<SupportTicket> supportTicketListUrgency = SupportTicketDB.getClosedSupportTicket();


        rptSupportTicketList.DataSource = supportTicketList;
        rptSupportTicketList.DataBind();

        rptSupportTicketListStatus.DataSource = supportTicketListStatus;
        rptSupportTicketListStatus.DataBind();


        rptSupportTicketListUrgency.DataSource = supportTicketListUrgency;
        rptSupportTicketListUrgency.DataBind();
    }
}