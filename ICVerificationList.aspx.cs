using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ICVerificationList : System.Web.UI.Page
{
   

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["admin"] == null)
        {
            Response.Redirect("Login.aspx");
            return;
        }

        List<Member> memberListRequestVerification = MemberDB.getAllMembertoVerify();
        rptListOfICVerification.DataSource = memberListRequestVerification;
        rptListOfICVerification.DataBind();

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);

    }

    protected void btnViewInfo_Click(object sender, EventArgs e)
    {
    }

    protected void lbViewInfo_Click(object sender, EventArgs e)
    {
        Label lblMemberID = (Label)rptListOfICVerification.Items[0].FindControl("lblMemberID");
        List<Member> memberInfo = new List<Member>();

        Session["MemberIDVerificationRequest"] = lblMemberID.Text;

        memberInfo.Add(MemberDB.getMemberbyID(lblMemberID.Text));
        rptMemberInfo.DataSource = memberInfo;
        rptMemberInfo.DataBind();
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);


    }

    protected void btnApproved_Click(object sender, EventArgs e)
    {
        MemberDB.confirmICVerification(MemberDB.getMemberbyID(Session["MemberIDVerificationRequest"].ToString()).MemberID, DateTime.Now);
    }

    protected void btnReject_Click(object sender, EventArgs e)
    {
        MemberDB.rejectICVerification(MemberDB.getMemberbyID(Session["MemberIDVerificationRequest"].ToString()).MemberID);
        Response.Redirect("ICVerificationList.aspx");
    }
}