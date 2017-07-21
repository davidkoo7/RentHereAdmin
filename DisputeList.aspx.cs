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