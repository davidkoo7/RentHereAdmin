using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;


public class MemberAnalyticDB
{
    // gets the connection value from "myConnectionString" in web.config to connect to database
    private static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    // gets sum of ratings by member from the database
    public static List<MemberAnalytic> getMemberFeedbackAnalytic()
    {
        List<MemberAnalytic> feedList = new List<MemberAnalytic>();
        try
        {
            SqlCommand command = new SqlCommand("SELECT feedbackTo, sum(case when rating='Positive' then 1 else 0 end) AS positiveCount, sum(case when rating = 'Neutral' then 1 else 0 end) AS neutralCount, sum(case when rating = 'Negative' then 1 else 0 end) AS negativeCount FROM Feedback F, Member M WHERE F.feedbackTo = M.memberID and M.status<>'Banned' GROUP BY feedbackTo");

            command.Connection = connection;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                MemberAnalytic ma = new MemberAnalytic();

                ma.Member = MemberDB.getMemberbyID(reader["feedbackTo"].ToString());
                ma.NoOfPositiveFeedback = Convert.ToInt32(reader["positiveCount"]);
                ma.NoOfNeutralFeedback = Convert.ToInt32(reader["neutralCount"]);
                ma.NoOfNegativeFeedback = Convert.ToInt32(reader["negativeCount"]);
                ma.NoOfRentalAsRenter = RentalDB.getNoofRentalAsRenter(ma.Member.MemberID);
                ma.NoOfRentalAsRentee = RentalDB.getNoofRentalAsRentee(ma.Member.MemberID);

                feedList.Add(ma);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return feedList;
    }

    // gets top 10 most used tag from the database
    public static List<string> getTop10MostUsedTags()
    {
        List<string> tagNameList = new List<string>();
        try
        {
            SqlCommand command = new SqlCommand("SELECT TOP 10 tagName FROM ItemTag GROUP BY tagName ORDER BY COUNT(*) desc");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string tag;
                tag = Convert.ToString(reader["tagName"]);

                tagNameList.Add(tag);
            }

            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return tagNameList;
    }
}