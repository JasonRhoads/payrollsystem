//Programmer Jason Rhoads
//CIS 407A
//03/22/15
//Requests and displays information from frmPersonnel 
//and saves it to the database

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmPersonnelVerified : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //When the page loads, all of the textboxes form frmPersonnel.aspx get loaded into the new textbox through Session objects.
        txtVerifiedInfo.Text = Session["txtFirstName"].ToString() + "\n" + Session["txtLastName"].ToString() + "\n" + Session["txtPayRate"].ToString() + "\n"
            + Session["txtStartDate"].ToString() + "\n" + Session["txtEndDate"].ToString();

        //Check to see if all of the information is available to save into the database to create a new record
        if (clsDataLayer.SavePersonnel(Server.MapPath("PayrollSystem_DB.accdb"),
        Session["txtFirstName"].ToString(),
        Session["txtLastName"].ToString(),
        Session["txtPayRate"].ToString(),
        Session["txtStartDate"].ToString(),
        Session["txtEndDate"].ToString()))
        {//successfully added a new employee
            txtVerifiedInfo.Text = txtVerifiedInfo.Text +
            "\nThe information was successfully saved!";
        }
        else
        {//Failure, no employee information was added
            txtVerifiedInfo.Text = txtVerifiedInfo.Text +
            "\nThe information was NOT saved.";
        }

    }
}