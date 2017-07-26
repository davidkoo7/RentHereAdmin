using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MemberList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // displays a full list of all member from the database

        // checks if user is logged in
        if (Session["admin"] == null) // if user is not logged in, redirect to login page
        {
            Response.Redirect("Login.aspx");
            return;
        }

        List<Member> memberList = MemberDB.getAllMember();
        rptMemberInfo.DataSource = MemberDB.getAllMember();
        rptMemberInfo.DataBind();
    }


    protected void rptMemberInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        Label item = (Label)e.Item.FindControl("lblmemberID");
        Label item2 = (Label)e.Item.FindControl("lblName");

    }
}