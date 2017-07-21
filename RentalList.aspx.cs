using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RentalList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["admin"] == null)
        {
            Response.Redirect("Login.aspx");
            return;
        }

        List<Rental> rentalList = RentalDB.getAllRental();
        List<Rental> rentalListOngoing = RentalDB.getAllRentalForStatus("On-going");
        List<Rental> rentalListEnded = RentalDB.getAllRentalForStatus("Ended & Returned");


        rptRentalList.DataSource = rentalList;
        rptRentalList.DataBind();

        rptRentalListEnded.DataSource = rentalListEnded;
        rptRentalListEnded.DataBind();


        rptRentalListOngoing.DataSource = rentalListOngoing;
        rptRentalListOngoing.DataBind();
    }
}