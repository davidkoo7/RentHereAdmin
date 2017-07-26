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
        // user has selected a support ticket to be viewed. this page displays messages and information regarding support ticket selected


        //checks if user has logged in
        if (Session["admin"] == null) // if user is not logged in, redirect to login page
        {
            Response.Redirect("Login.aspx");
            return;
        }

        // checks if support ticket is selected
        if (Request.QueryString["ticketID"] == null) // if nothing selected, redirect back to SupportTicketList page
        {
            Response.Redirect("~/SupportTicketList.aspx");
        }
        else // if support ticket is selected, display the correct information and meessages related to it
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

    // allows user to send messages 
    protected void btnSend_Click(object sender, EventArgs e)
    {
        MessageSupportTicketDB.insertAdminMessage(txtMsg.InnerText, DateTime.Now, SupportTicketDB.getSupportTicketbyID(Request.QueryString["ticketID"].ToString()), StaffDB.getStaffbyEmail(Session["admin"].ToString()).StaffID);
        Response.Redirect(Request.RawUrl);
    }

    // gets messages regarding supoprt ticket selected 
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