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

            Dispute dis = DisputeDB.getDisputeybyID(Request.QueryString["disputeID"].ToString());

            if (dis.Status == "Resolved")
                setChatControls(false);
            else
                setChatControls(true);

            disputeMembers.Add(dis);

            Member targetMember = new Member();

            if (dis.SubmittedBy.MemberID != dis.Rental.Rentee.MemberID)
                targetMember = dis.Rental.Rentee;
            else
                targetMember = dis.Rental.Item.Renter;

            btnBanDisputer.Text = "Ban " + dis.SubmittedBy.Name.Substring(0, dis.SubmittedBy.Name.IndexOf(" "));
            btnBanDisputed.Text = "Ban " + targetMember.Name.Substring(0, targetMember.Name.IndexOf(" "));

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

    protected void btnBanDisputer_Click(object sender, EventArgs e)
    {
        Dispute dis = DisputeDB.getDisputeybyID(Request.QueryString["disputeID"].ToString());
        if (dis.Status == "Resolved")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your page has expired since the disputer has closed the case')", true);
            rptMessages.DataBind();
            setChatControls(false);
            txtMsg.Value = "";
            return;
        }

        submitMessage("=======" + dis.SubmittedBy.Name + " has been banned, dispute resolved=======", dis);

        MemberDB.updateMemberStatus(dis.SubmittedBy.MemberID, "Banned");
        DisputeDB.resolveDispute(dis.DisputeID);

        setChatControls(false);

        Response.Redirect(Request.RawUrl);
    }

    protected void btnBanDisputed_Click(object sender, EventArgs e)
    {
        Dispute dis = DisputeDB.getDisputeybyID(Request.QueryString["disputeID"].ToString());
        if (dis.Status == "Resolved")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your page has expired since the disputer has closed the case')", true);
            rptMessages.DataBind();
            setChatControls(false);
            txtMsg.Value = "";
            return;
        }

        Member targetMember = new Member();

        if (dis.SubmittedBy.MemberID != dis.Rental.Rentee.MemberID)
            targetMember = dis.Rental.Rentee;
        else
            targetMember = dis.Rental.Item.Renter;

        if (targetMember.Status == "Banned")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Form resubmission is not allowed')", true);
            rptMessages.DataBind();
            return;
        }

        MemberDB.updateMemberStatus(targetMember.MemberID, "Banned");
        submitMessage("=======" + targetMember.Name + " has been banned, dispute resolved=======", dis);

        DisputeDB.resolveDispute(dis.DisputeID);

        setChatControls(false);

        Response.Redirect(Request.RawUrl);
    }

    // enables or disables message send button and message box
    private void setChatControls(bool isEnabled)
    {
        btnSend.Enabled = isEnabled;
        txtMsg.Disabled = !isEnabled;
        //btnSubmit.Enabled = isEnabled;
        btnBanDisputed.Enabled = isEnabled;
        btnBanDisputer.Enabled = isEnabled;
    }
}