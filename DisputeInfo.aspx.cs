using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DisputeInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // user has selected a dispute to be viewed. this page displays messages pertaining the dispute selected

        //  checks if user is logged in
        if (Session["admin"] == null) // if not logged in, redirect to login page
        {
            Response.Redirect("Login.aspx");
            return;
        }

        //  check if a dispute is selected
        if (Request.QueryString["disputeID"] == null) // if nothing is selected, redirect back to DisputeList page
        {
            Response.Redirect("~/DisputeList.aspx");
        }
        else // if a dispute is selected, display the correct messages for the dispute selected
        {
            List<MessageDispute> disputeMsg = MessageDisputeDB.getMsgforDispute(Request.QueryString["disputeID"].ToString());
            rptMessages.DataSource = disputeMsg;
            rptMessages.DataBind();


            List<Dispute> disputeMembers = new List<Dispute>();

            disputeMembers.Add(DisputeDB.getDisputeybyID(Request.QueryString["disputeID"].ToString()));


            rptMemberInfoRedirect.DataSource = disputeMembers;
            rptMemberInfoRedirect.DataBind();

        }

    }

    // admin posts message with regards to a dispute
    protected void btnSend_Click(object sender, EventArgs e)
    {
        // check if the length of the message 
        if (txtMsg.InnerText.Length > 255)  // if the length of the message is more than 255, display alert
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your message cannot exceed 255 characters!')", true);
            return;
        }
        
        // gets the dispute being selected
        Dispute dis = DisputeDB.getDisputeybyID(Request.QueryString["disputeID"].ToString()); 
        // checks the status of the dispute
        if (dis.Status == "Resolved") // if status of dispute is resolved, display alert, deny posting of message
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your page has expired since your disputer has closed the case')", true);
            rptMessages.DataBind();
            setChatControls(false);
            txtMsg.InnerText = "";
            return;
        }
        // checks if there is message typed
        if (txtMsg.InnerText != "") // if there is message, post message
        {
            submitMessage(txtMsg.InnerText, dis); 

            txtMsg.InnerText = "";

            Response.Redirect(Request.RawUrl);
        }

        Response.Redirect(Request.RawUrl);
    }

    // gets messages regarding dispute selected 
    protected string retrieveMessage(string memberID, string staffID, string reply, string datePosted)
    {
        if (memberID != "")
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

    // posts message and updates database of the message posted
    private void submitMessage(string message, Dispute dis)
    {
        MessageDispute msgDis = new MessageDispute();

        msgDis.Date = DateTime.Now;
        msgDis.Dispute = dis;
        msgDis.Member = new Member(null, null, null, 0, null, null, 0, null, null, new DateTime(), new DateTime(), null, new DateTime(), null, null);
        msgDis.Staff = StaffDB.getStaffbyEmail(Session["admin"].ToString());

        msgDis.Reply = message;
        MessageDisputeDB.addMsgDispute(msgDis);
    }

    // enables or disables message send button and message box
    private void setChatControls(bool isEnabled)
    {
        btnSend.Enabled = isEnabled;
        txtMsg.Disabled = !isEnabled;
        //btnSubmit.Enabled = isEnabled;
        //btnBanDisputed.Enabled = isEnabled;
        //btnBanDisputer.Enabled = isEnabled;
    }
}