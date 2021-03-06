﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

public class MemberInboxDB
{
    // gets the connection value from "myConnectionString" in web.config to connect to database
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    // method to get all MemberInbox from the database
    public static List<MemberInbox> getAllMemberInbox()
    {
        List<MemberInbox> memberInboxList = new List<MemberInbox>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from MemberInbox");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                MemberInbox memberInbox = new MemberInbox();
                readAMsg(ref memberInbox, ref reader);

                memberInboxList.Add(memberInbox);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return memberInboxList;
    }

    // method to get all MemberInbox by member, takes in parameter of type Member
    public static List<MemberInbox> getAllMemberInboxByID(Member sender)
    {
        List<MemberInbox> memberInboxList = new List<MemberInbox>();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM MemberInbox M, Item i WHERE M.itemID = i.itemID and (M.senderID = @senderID OR i.itemID IN SELECT itemID FROM Item WHERE renterID = @senderID))");
            command.Parameters.AddWithValue("@senderID", sender.MemberID);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                MemberInbox memberInbox = new MemberInbox();
                readAMsg(ref memberInbox, ref reader);

                memberInboxList.Add(memberInbox);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return memberInboxList;
    }

    // method to get MemberInbox by memberInboxID from the database
    public static MemberInbox getMemberInboxID(string memberInboxID)
    {
        MemberInbox mem = new MemberInbox();
        try
        {
            SqlCommand command = new SqlCommand("Select * from MemberInbox WHERE memberInboxID = @memberInboxID");
            command.Parameters.AddWithValue("@memberInboxID", memberInboxID);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                readAMsg(ref mem, ref reader);

            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return mem;
    }

    // method to add MemberInbox into the database, takes in paramater of type MemberInbox
    public static int AddMsgMember(MemberInbox msgDis)
    {
        try
        {
            SqlCommand command = new SqlCommand("INSERT INTO MemberInbox (date, senderID, itemID) values (@date, @senderID, @itemID)");
            command.Parameters.AddWithValue("@date", msgDis.Date);
            command.Parameters.AddWithValue("@senderID", msgDis.Sender.MemberID);
            command.Parameters.AddWithValue("@itemID", msgDis.Item.ItemID);

            command.Connection = connection;
            connection.Open();


            if (command.ExecuteNonQuery() > 0)
                return 1;
        }
        finally
        {
            connection.Close();
        }
        return -1;
    }

    // method to read the column values in the database (through the referenced reader) and assign it to the correct properties of the referenced MemberInbox object 
    // allows for easier editing of column names if needed, used only for methods with select statments regarding MemberInbox
    private static void readAMsg(ref MemberInbox msg, ref SqlDataReader reader)
    {
        msg.MemberInboxID = Convert.ToInt32(reader["memberInboxID"]);
        msg.Date = Convert.ToDateTime(reader["date"]);
        msg.Sender = MemberDB.getMemberbyID(reader["senderID"].ToString());
        msg.Item = ItemDB.getItembyID(reader["itemID"].ToString());
    }


}