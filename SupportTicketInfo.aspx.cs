using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SupportTicketInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin"] == null)
        {
            Response.Redirect("Login.aspx");
            return;
        }


        if (Request.QueryString["ticketID"] == null)
        {
            Response.Redirect("~/SupportTicketList.aspx");
        }
        else
        {
            List<MessageSupportTicket> supportTicketMsg = MessageSupportTicketDB.getMessage(SupportTicketDB.getSupportTicketbyID(Request.QueryString["ticketID"].ToString()));
            rptMessages.DataSource = supportTicketMsg;
            rptMessages.DataBind();


            List<SupportTicket> supportTicketList = new List<SupportTicket>();

            supportTicketList.Add(SupportTicketDB.getSupportTicketbyID(Request.QueryString["ticketID"].ToString()));


            rptMemberInfoRedirect.DataSource = supportTicketList;
            rptMemberInfoRedirect.DataBind();

        }

    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        MessageSupportTicketDB.insertAdminMessage(txtMsg.InnerText, DateTime.Now, SupportTicketDB.getSupportTicketbyID(Request.QueryString["ticketID"].ToString()), StaffDB.getStaffbyEmail(Session["admin"].ToString()).StaffID);
        Response.Redirect(Request.RawUrl);
    }

    protected string retrieveMessage(string memberID, string staffID, string reply, string datePosted)
    {
        if (MemberDB.getMemberbyID(memberID).Email == SupportTicketDB.getSupportTicketbyID(Request.QueryString["ticketID"].ToString()).Member.Email)
        {
            return " <div class='item'> \n " +
                " <div class='text'> \n " +
                " <div class='heading'> \n " +
                " <a class='text-success' href='#'>" + MemberDB.getMemberbyID(memberID).Name + "</a> \n " +
                " <span class='date'>" + Convert.ToString(datePosted) + "</span> \n " +
                " </div> \n " +
                    reply +
                " </div> \n " +
                " </div> \n ";
        }
        else
        {
            return " <div class='item'> \n " +
                " <div class='text'> \n " +
                " <div class='heading'> \n " +
                " <a href='#'> <Strong> (Staff) " + StaffDB.getStaffbyID(staffID).Name + " </strong> </a> \n " +
                " <span class='date'>" + Convert.ToString(datePosted) + "</span> \n " +
                " </div> \n " +
                    reply +
                " </div> \n " +
                " </div> \n ";

        }
    }
}