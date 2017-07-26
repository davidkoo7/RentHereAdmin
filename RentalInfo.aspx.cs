using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RentalInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // user has selected a rental to be viewed. this page displays information regarding the rental selected

        // checks if user has logged in
        if (Session["admin"] == null) // if user is not logged in, redirect to login page
        {
            Response.Redirect("Login.aspx");
            return;
        }

        // checks if rental is selected
        if (Request.QueryString["rentalID"] == null) // if nothing is selected, redirect back to RentalList page
        {
            Server.Transfer("~/RentalList.aspx");
        }
        else // if rental is selected, display the correct information
        {

            List<Rental> rentalDetails = new List<Rental>();
            rentalDetails.Add(RentalDB.getRentalbyID(Request.QueryString["rentalID"].ToString()));
            repeaterRentalInfo.DataSource = rentalDetails;
            repeaterRentalInfo.DataBind();
        }
    }
}