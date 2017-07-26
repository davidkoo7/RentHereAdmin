using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ItemInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // user has selected an item to be viewed. this page displays information about the item selected

        // checks if user is logged in 
        if (Session["admin"] == null) // if user is not logged in, redirect to login page
        {
            Response.Redirect("Login.aspx");
            return;
        }

        // check if item is selected 
        if (Request.QueryString["itemID"] == null) // if nothing is selected, redirect back to ItemList page
        {
            Server.Transfer("~/ItemList.aspx");
        }
        else
        {
            // if item is selected, display the correct information regarding the item selected
            List<Item> productDetails = new List<Item>();
            productDetails.Add(ItemDB.getItembyID(Request.QueryString["itemID"].ToString()));
            repeaterItemInformation.DataSource = productDetails;
            repeaterItemInformation.DataBind();
        }
    }
}