using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MessageList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin"] == null)
        {
            Response.Redirect("Login.aspx");
            return;
        }

        List<MemberInbox> memberInboxList = MemberInboxDB.getAllMemberInbox();
        rptMemberMessage.DataSource = memberInboxList;
        rptMemberMessage.DataBind();
    }
}