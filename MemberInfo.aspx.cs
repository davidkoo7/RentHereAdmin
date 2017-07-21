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
        if (Session["admin"] == null)
        {
            Response.Redirect("Login.aspx");
            return;
        }

        if (Request.QueryString["memberID"] == null)
        {
            Server.Transfer("~/memberList.aspx");
        }
        else
        {

            List<Member> memberList = new List<Member>();
            memberList.Add(MemberDB.getMemberbyID(Request.QueryString["memberID"].ToString()));
            rptMemberInfo.DataSource = memberList;
            rptMemberInfo.DataBind();
        }

        List<Item> itemList = ItemDB.getAllItemofMember(MemberDB.getMemberbyID(Request.QueryString["memberID"].ToString()).MemberID);
        rptItemList.DataSource = itemList;
        rptItemList.DataBind();
    }

}