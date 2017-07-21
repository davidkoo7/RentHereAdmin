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
        if (Session["admin"] == null)
        {
            Response.Redirect("Login.aspx");
            return;
        }

        if (Request.QueryString["itemID"] == null)
        {
            Server.Transfer("~/ItemList.aspx");
        }
        else
        {

            List<Item> productDetails = new List<Item>();
            productDetails.Add(ItemDB.getItembyID(Request.QueryString["itemID"].ToString()));
            repeaterItemInformation.DataSource = productDetails;
            repeaterItemInformation.DataBind();
        }
    }
}