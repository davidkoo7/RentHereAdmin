﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

public class FAQDB
{
    // gets the connection value from "myConnectionString" in web.config to connect to database
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    // method to get FAQ by faqID from the database
    public static FAQ getFAQbyID(string faqid)
    {
        FAQ faq = new FAQ();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM FAQ WHERE faqID = @faqID");
            command.Parameters.AddWithValue("@faqID", faqid);
            command.Connection = connection;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
                readAFAQ(ref faq, ref reader);
            else
                faq = new FAQ(null, null, null, new DateTime(), new Staff());
            
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return faq;
    }

    // method to get FAQ by staffID from the database 
    public static FAQ getFAQbyStaff(string staffID)
    {
        FAQ faq = new FAQ();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM FAQ WHERE staffID = @staffID");
            command.Parameters.AddWithValue("@staffID", staffID);
            command.Connection = connection;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
                readAFAQ(ref faq, ref reader);
            else
                faq = new FAQ(null, null, null, new DateTime(), new Staff());

            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return faq;
    }

    // method to add FAQ into the database, takes in parameter of type FAQ
    public static int addFAQ(FAQ faq)
    {
        try
        {
            SqlCommand command = new SqlCommand("INSERT INTO FAQ (title, description, date, staffID) VALUES (@title, @description, @date, @staffID)");
            command.Parameters.AddWithValue("@title", faq.Title);
            command.Parameters.AddWithValue("@description", faq.Description);
            command.Parameters.AddWithValue("@date", faq.Date);            
            command.Parameters.AddWithValue("@staffID", faq.Staff.StaffID);

            command.Connection = connection;
            connection.Open();

            if (command.ExecuteNonQuery() > 0)
            {
                return 1;
            }
        }
        finally
        {
            connection.Close();
        }
        return 0;
    }

    // method to read the column values in the database (through the referenced reader) and assign it to the correct properties of the referenced FAQ object 
    // allows for easier editing of column names if needed, used only for methods with select statments regarding FAQ
    private static void readAFAQ (ref FAQ faq, ref SqlDataReader reader)
    {
        faq.FaqID = reader["faqID"].ToString();
        faq.Title = reader["title"].ToString();
        faq.Description = reader["description"].ToString();
        faq.Date = Convert.ToDateTime(reader["date"]);
        faq.Staff = StaffDB.getStaffbyID(reader["staffID"].ToString());
    }
}