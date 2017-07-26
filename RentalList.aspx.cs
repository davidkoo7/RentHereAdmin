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
        //  displays a full list of all rentals from the database to be reviewed

        // checks if user is logged on
        if (Session["admin"] == null) // if user is not logged, redirect to login page
        {
            Response.Redirect("Login.aspx");
            return;
        }

        // allows user to filter list by rental status
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