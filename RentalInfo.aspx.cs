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

        if (Session["admin"] == null)
        {
            Response.Redirect("Login.aspx");
            return;
        }

        if (Request.QueryString["rentalID"] == null)
        {
            Server.Transfer("~/RentalList.aspx");
        }
        else
        {

            List<Rental> rentalDetails = new List<Rental>();
            rentalDetails.Add(RentalDB.getRentalbyID(Request.QueryString["rentalID"].ToString()));
            repeaterRentalInfo.DataSource = rentalDetails;
            repeaterRentalInfo.DataBind();
        }
    }
}