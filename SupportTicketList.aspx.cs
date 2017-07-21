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

        if (Session["admin"] == null)
        {
            Response.Redirect("Login.aspx");
            return;
        }

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