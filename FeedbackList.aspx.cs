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
        // displays a full list of all feedbacks from the database

        // checks if user is logged in
        if (Session["admin"] == null) // if user is not logged in, redirect to login page
        {
            Response.Redirect("Login.aspx");
            return;
        }
        
        // allows user to filter feedbacks by rating
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