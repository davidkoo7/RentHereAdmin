using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Messages : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["admin"] == null)
        {
            Response.Redirect("Login.aspx");
            return;
        }

        if (Request.QueryString["memberInboxID"] == null)
        {
            Response.Redirect("~/messageList.aspx");
        }
        else
        {

            List<MemberMessage> memberMessageList = MemberMessageDB.getMsgforMember(Request.QueryString["memberInboxID"].ToString());
            List<MemberInbox> memberInbox = new List<MemberInbox>();

            memberInbox.Add(MemberInboxDB.getMemberInboxID(Request.QueryString["memberInboxID"].ToString()));

            lblInboxID.Text = MemberInboxDB.getMemberInboxID(Request.QueryString["memberInboxID"].ToString()).MemberInboxID.ToString();

            rptMemberInfoRedirect.DataSource = memberInbox;
            rptMemberInfoRedirect.DataBind();

            rptMessages.DataSource = memberMessageList;
            rptMessages.DataBind();
        }



    }

    protected string retrieveMessage(string senderID, string reply, string datePosted)
    {
        if (MemberDB.getMemberbyID(senderID).Email == MemberInboxDB.getMemberInboxID(Request.QueryString["memberInboxID"].ToString()).Sender.Email)
        {
            return " <div class='item '> \n" +
                   " <div class='image'> \n" +
                   " <img src='assets/images/users/user2.jpg' > \n" +
                   " </div> \n" +
                   " <div class='text' > \n" +
                   " <div class='heading' > \n" +
                   " <a href='#'>" + MemberDB.getMemberbyID(senderID).Name + "</a> \n" +
                   " <span class='date' >" + datePosted + "</span> \n" +
                   " </div> \n" +
                   reply +                   " </div> \n" +
                   " </div> \n";
        }
        else
        {
            return " <div class='item in'> \n" +
                   " <div class='image' > \n" +
                   " <img src='assets/images/users/user.jpg'> \n" +
                   " </div> \n" +
                   " <div class='text'> \n" +
                   " <div class='heading' > \n" +
                   " <a href='#'>" + MemberDB.getMemberbyID(senderID).Name + "</a> \n" +
                   " <span class='date' >" + datePosted + "</span> \n" +
                   " </div> \n" +
                   reply +
                   " </div> \n" +
                   " </div> \n";

        }
    }
}