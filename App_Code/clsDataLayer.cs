/*******************************************************
   * Programmer Jason Rhoads
   * CIS 407A
   * 04/12/15
   * clsDataLayer.cs retreives the information from the 
   * database and displays all of the previous user activity
   * on frmUserActivity
*********************************************************/
using System.Data.OleDb;
using System.Net;
using System.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Get and saves user information tp amd from tblUserActivity and displays the information on frmUserActivity
/// </summary>
public class clsDataLayer
{
	public clsDataLayer()
	{
		//
		//Empty at this time 
		//
	}

     
    // This function gets the user activity from the tblUserActivity
    public static dsUserActivity GetUserActivity(string Database)
    {
        //Create variables
        dsUserActivity DS;
        OleDbConnection sqlConn;
        OleDbDataAdapter sqlDA;
        //Establish new a new connection to the database
        sqlConn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + Database);
        //Create a new query for the database
        sqlDA = new OleDbDataAdapter("select * from tblUserActivity", sqlConn);
        //Create a new instance of dsUserActivity
        DS = new dsUserActivity();
        //Fills in the table to see the previous activity
        sqlDA.Fill(DS.tblUserActivity);
        //Return the most recent copy of DS incorporating all of the previous user activity
        return DS;
    }
    // This function saves the user activity
    public static void SaveUserActivity(string Database, string FormAccessed)
    {
        //Establish connection with the database
        OleDbConnection conn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;" +
        "Data Source=" + Database);
        conn.Open();
        OleDbCommand command = conn.CreateCommand();
        string strSQL;
        strSQL = "Insert into tblUserActivity (UserIP, FormAccessed) values ('" +
        GetIP4Address() + "', '" + FormAccessed + "')";
        command.CommandType = CommandType.Text;
        command.CommandText = strSQL;
        command.ExecuteNonQuery();
        conn.Close();
    }
    // This function gets the IP Address
    public static string GetIP4Address()
    {
        string IP4Address = string.Empty;
        foreach (IPAddress IPA in
        Dns.GetHostAddresses(HttpContext.Current.Request.UserHostAddress))
        {
            if (IPA.AddressFamily.ToString() == "InterNetwork")
            {
                IP4Address = IPA.ToString();
                break;
            }
        }
        if (IP4Address != string.Empty)
        {
            return IP4Address;
        }
        foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
        {
            if (IPA.AddressFamily.ToString() == "InterNetwork")
            {
                IP4Address = IPA.ToString();
                break;
            }
        }
        return IP4Address;
    }

    // This function saves the personnel data
    public static bool SavePersonnel(string Database, string FirstName, string LastName,
    string PayRate, string StartDate, string EndDate)
    {
        bool recordSaved;
        
        // Create and set myTransaction to null
        OleDbTransaction myTransaction = null;

        try
        {
            // Establish connection to the database
            OleDbConnection conn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;" +
            "Data Source=" + Database);
            
            //Open the connection
            conn.Open();
            OleDbCommand command = conn.CreateCommand();
            string strSQL;
           
            //Establish myTransaction and set command equal to myTransaction
            myTransaction = conn.BeginTransaction();
            command.Transaction = myTransaction;

            // create SQL insert statement for frist and last name into tblPersonnel
            strSQL = "Insert into tblPersonnel " +
            "(FirstName, LastName) values ('" +
            FirstName + "', '" + LastName + "')";

            // Set the insert statement to command
            command.CommandType = CommandType.Text;
            command.CommandText = strSQL;

            // Run the SQL insert statement
            command.ExecuteNonQuery();

            // Creat update statement that gets the last record entered and update the payRate, StartDate, and EndDate
            strSQL = "Update tblPersonnel " +
            "Set PayRate=" + PayRate + ", " +
            "StartDate='" + StartDate + "', " +
            "EndDate='" + EndDate + "' " +
            "Where ID=(Select Max(ID) From tblPersonnel)";

            // Set the update statement to command
            command.CommandType = CommandType.Text;
            command.CommandText = strSQL;

            // Run the SQL update statment 
            command.ExecuteNonQuery();

            //Commit the transaction to tblPersonnel, saving the data
            myTransaction.Commit();

            // Close connection
            conn.Close();

            recordSaved = true;
        }
        catch (Exception ex)
        {
            //If the transaction is no successfull rollback to the previous commit
            myTransaction.Rollback();

            recordSaved = false;
        }
        return recordSaved;
    }

    // This function gets the user activity from the tblpersonnel
    public static dsPersonnel GetPersonnel(string Database, string strSearch)
    {
        //create variables
        dsPersonnel DS;
        OleDbConnection sqlConn;
        OleDbDataAdapter sqlDA;
        //Establish a new connection to the database
        sqlConn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + Database);
        //Create a new query for the database
        //If the seach field is blank or null then select the entire table
        if (strSearch == null || strSearch.Trim() == "")
        {
            sqlDA = new OleDbDataAdapter("select * from tblPersonnel", sqlConn);
        }
        //Else search using the last name that is given by the user
        else
        {
            sqlDA = new OleDbDataAdapter("select * from tblPersonnel where LastName = '" + strSearch + "'", sqlConn);
        }
        //Create a new instance of dsPersonnel
        DS = new dsPersonnel();
        //Fills in the table to see the data
        sqlDA.Fill(DS.tblPersonnel);
        //Return the most recent copt of DS
        return DS;
    }

    // This function verifies a user in the tblUser table
    public static dsUser VerifyUser(string Database, string UserName, string UserPassword)
    {
        // create variables for the user and connections
        dsUser DS;
        OleDbConnection sqlConn;
        OleDbDataAdapter sqlDA;
        // create connection to the database
        sqlConn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;" +
        "Data Source=" + Database);
        // create sql statement
        sqlDA = new OleDbDataAdapter("Select SecurityLevel from tblUserLogin " +
        "where UserName like '" + UserName + "' " +
        "and UserPassword like '" + UserPassword + "'", sqlConn);
        // create a new user object
        DS = new dsUser();
        // Fill in the table
        sqlDA.Fill(DS.tblUserLogin);
        // return the object
        return DS;
    }    

    public static bool SaveUser(string Database, string UserName, string Password, string SecurityLevel)
    {
        bool recordSaved;

        try
        {
            // Establish connection to the database
            OleDbConnection conn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;" +
            "Data Source=" + Database);

            conn.Open();
            OleDbCommand command = conn.CreateCommand();
            string strSQL;

            // create SQL insert statement for UserName, Password and SecurityLevel
            strSQL = "Insert into tblUserLogin " +
            "(UserName, UserPassword, SecurityLevel) values ('" +
            UserName + "', '" + Password + "', '" + SecurityLevel + "')";

            // Set the insert statement to command
            command.CommandType = CommandType.Text;
            command.CommandText = strSQL;

            // Run the SQL insert statement
            command.ExecuteNonQuery();
                              
            // Close connection
            conn.Close();

            recordSaved = true;
        }
        catch (Exception ex)
        {
            
            recordSaved = false;
        }
        return recordSaved;
    }
}