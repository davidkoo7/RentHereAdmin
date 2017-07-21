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
        if (Session["admin"] == null)
        {
            Response.Redirect("Login.aspx");
            return;
        }

        if (Request.QueryString["disputeID"] == null)
        {
            Response.Redirect("~/DisputeList.aspx");
        }
        else
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

    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (txtMsg.InnerText.Length > 255)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your message cannot exceed 255 characters!')", true);
            return;
        }

        Dispute dis = DisputeDB.getDisputeybyID(Request.QueryString["disputeID"].ToString());
        if (dis.Status == "Resolved")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your page has expired since your disputer has closed the case')", true);
            rptMessages.DataBind();
            setChatControls(false);
            txtMsg.InnerText = "";
            return;
        }
        if (txtMsg.InnerText != "")
        {
            submitMessage(txtMsg.InnerText, dis);

            txtMsg.InnerText = "";

            Response.Redirect(Request.RawUrl);
        }

        Response.Redirect(Request.RawUrl);
    }

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

    private void setChatControls(bool isEnabled)
    {
        btnSend.Enabled = isEnabled;
        txtMsg.Disabled = !isEnabled;
        //btnSubmit.Enabled = isEnabled;
        //btnBanDisputed.Enabled = isEnabled;
        //btnBanDisputer.Enabled = isEnabled;
    }
}