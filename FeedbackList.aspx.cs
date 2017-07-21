using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FeedbackList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin"] == null)
        {
            Response.Redirect("Login.aspx");
            return;
        }

        List<Feedback> feedbackList = FeedbackDB.getAllFeedbackOfRating("Positive");
        List<Feedback> feedbackListPositive = FeedbackDB.getAllFeedbackOfRating("Positive");
        List<Feedback> feedbackListNeutral = FeedbackDB.getAllFeedbackOfRating("Neutral");
        List<Feedback> feedbackListNegative = FeedbackDB.getAllFeedbackOfRating("Negative");


        rptFeedbackList.DataSource = feedbackList;
        rptFeedbackList.DataBind();

        rptFeedbackListPositive.DataSource = feedbackListPositive;
        rptFeedbackListPositive.DataBind();

        rptFeedbackListNeutral.DataSource = feedbackListNeutral;
        rptFeedbackListNeutral.DataBind();

        rptFeedbackListNegative.DataSource = feedbackListNegative;
        rptFeedbackListNegative.DataBind();
    }
}