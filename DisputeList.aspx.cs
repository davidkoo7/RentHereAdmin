using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DisputeList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // displays a full list of all disputes from the database to be reviewed

        // checks if user is logged on
        if (Session["admin"] == null) // if user is not logged, redirect to login page
        {
            Response.Redirect("Login.aspx");
            return;
        }
        
        // allows user to filter list by dispute status
        List<Dispute> disputeList = DisputeDB.getAllDisputeforRentals(null);
        List<Dispute> disputeListPending = DisputeDB.getAllDisputeforRentals("PendingDispute");
        List<Dispute> disputeListResolved = DisputeDB.getAllDisputeforRentals("ResolvedDispute");


        rptDisputeList.DataSource = disputeList;
        rptDisputeList.DataBind();

        rptDisputeListPending.DataSource = disputeListPending;
        rptDisputeListPending.DataBind();


        rptDisputeListResolved.DataSource = disputeListResolved;
        rptDisputeListResolved.DataBind();
    }
}