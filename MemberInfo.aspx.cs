using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MemberInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // user has selected a member to be viewed. this page displays information about the member selected

        // checks if user is logged in
        if (Session["admin"] == null) // if user is not logged in, redirect to login page
        {
            Response.Redirect("Login.aspx");
            return;
        }

        // check if member is selected 
        if (Request.QueryString["memberID"] == null) // if nothing is selected, redirect to MemberList page
        {
            Server.Transfer("~/memberList.aspx");
        }
        else
        {
            // if member is selected, display the correct information for the item selected
            List<Member> memberList = new List<Member>();
            memberList.Add(MemberDB.getMemberbyID(Request.QueryString["memberID"].ToString()));
            rptMemberInfo.DataSource = memberList;
            rptMemberInfo.DataBind();
        }
        // allows user to see items listed by member
        List<Item> itemList = ItemDB.getAllItemofMember(MemberDB.getMemberbyID(Request.QueryString["memberID"].ToString()).MemberID);
        rptItemList.DataSource = itemList;
        rptItemList.DataBind();
    }

}