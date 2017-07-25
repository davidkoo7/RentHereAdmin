using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

public class RentalDB
{
    // gets the connection value from "myConnectionString" in web.config to connect to database
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    // method to get all rentals from the database
    public static List<Rental> getAllRental()
    {
        List<Rental> rentalList = new List<Rental>();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Rental");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Rental i = new Rental();
                readARental(ref i, ref reader);

                rentalList.Add(i);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return rentalList;
    }

    // method to get all rentals by status from the database
    public static List<Rental> getAllRentalForStatus(string status)
    {
        List<Rental> rentalList = new List<Rental>();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Rental WHERE status = @status");
            command.Parameters.AddWithValue("@status", status);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Rental i = new Rental();
                readARental(ref i, ref reader);

                rentalList.Add(i);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return rentalList;
    }

    // method to get all rentals by member from the database, takes in parameter of type Member
    public static List<Rental> getRentalforMember(Member member)
    {
        List<Rental> rentalList = new List<Rental>();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Rental R, Item I WHERE R.itemID = I.itemID and (renteeID = @renteeID or renterID = @renterID)");
            command.Parameters.AddWithValue("@renteeID", member.MemberID);
            command.Parameters.AddWithValue("@renterID", member.MemberID);
            command.Connection = connection;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Rental rent = new Rental();
                readARental(ref rent, ref reader);

                rentalList.Add(rent);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return rentalList;
    }

    // method to get all rentals by item from the database
    public static List<Rental> getRentalofItem(string itemID)
    {
        List<Rental> rentList = new List<Rental>();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Rental WHERE itemID = @itemID");
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@itemID", itemID);
            command.Connection = connection;

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Rental rent = new Rental();
                readARental(ref rent, ref reader);
                rentList.Add(rent);
            }

            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return rentList;
    }

    // method to get rentee from rental record from the database
    public static Member getRenteeforRental(string rentalID)
    {
        Member m = new Member();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Rental WHERE rentalID = @rentalID");
            command.Parameters.AddWithValue("@rentalID", rentalID);
            command.Connection = connection;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
                m = MemberDB.getMemberbyID(reader["renteeID"].ToString());

            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return m;
    }

    // method to get rental by rentalIS from the database
    public static Rental getRentalbyID(string rentalID)
    {
        Rental rent = new Rental();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Rental WHERE rentalID = @rentalID");
            command.Parameters.AddWithValue("@rentalID", rentalID);
            command.Connection = connection;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
                readARental(ref rent, ref reader);
            else
                rent = new Rental(null, null, new TimeSpan(), null, new TimeSpan(), 0, null, 0, new DateTime(), new DateTime(), new DateTime(), null, null, null, new Item(), new Payment(), new Member());

            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return rent;
    }

    // methof to change sttus of rental in the database
    public static int updateRentStatus(string rentalID, string status)
    {
        try
        {
            SqlCommand command = new SqlCommand("UPDATE Rental SET status=@status WHERE rentalID=@rentalID");
            command.Parameters.AddWithValue("@status", status);
            command.Parameters.AddWithValue("@rentalID", rentalID);

            command.Connection = connection;
            connection.Open();

            if (command.ExecuteNonQuery() > 0)
                return 1;
        } finally
        {
            connection.Close();
        }
        return -1;
    }

    // method to read the column values in the database (through the referenced reader) and assign it to the correct properties of the referenced Rental object 
    // allows for easier editing of column names if needed, used only for methods with select statments regarding Rental
    private static void readARental(ref Rental rent, ref SqlDataReader reader)
    {
        rent.RentalID = Convert.ToString(reader["rentalID"]);
        rent.PickUpLocation = Convert.ToString(reader["pickUpLocation"]);
        rent.PickUpTime = (TimeSpan)reader["pickUpTime"];
        rent.RentalFee = Convert.ToDecimal(reader["rentalFee"]);
        rent.Unit = reader["unit"].ToString();
        rent.Deposit = Convert.ToDecimal(reader["deposit"]);
        rent.DateCreated = Convert.ToDateTime(reader["dateCreated"]);
        rent.StartDate = Convert.ToDateTime(reader["startDate"]);
        rent.EndDate = Convert.ToDateTime(reader["endDate"]);
        rent.Status = Convert.ToString(reader["status"]);
        rent.PaymentReleaseCode = Convert.ToString(reader["paymentReleaseCode"]);
        rent.DepositRetrievalCode = Convert.ToString(reader["depositRetrievalCode"]);

        if (reader["returnLocation"] != DBNull.Value)
            rent.ReturnLocation = reader["returnLocation"].ToString();
        else
            rent.ReturnLocation = "";

        if (reader["returnTime"] != DBNull.Value)
            rent.ReturnTime = (TimeSpan)reader["returnTime"];
        else
            rent.ReturnTime = new TimeSpan(0, 0, 0);

        rent.Rentee = MemberDB.getMemberbyID(reader["renteeID"].ToString());

        rent.Item = ItemDB.getItembyID(reader["itemID"].ToString());

        rent.PaymentID = PaymentDB.getPaymentbyID(reader["paymentID"].ToString());
    }
}