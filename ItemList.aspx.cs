using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ItemList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // displays a full list of all the items in the database

        // check if user is logged in 
        if (Session["admin"] == null) // if user is not logged in, redirect to login page
        {
            Response.Redirect("Login.aspx");
            return;
        }

        List<Item> itemList = ItemDB.getAllItem();
        Repeater1.DataSource = itemList;
        Repeater1.DataBind();
    }
}