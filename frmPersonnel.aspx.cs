/*************************************************
   * Programmer Jason Rhoads
   * CIS 407A
   * 04/12/15
   * Validates a new employee's information each 
   * field at a time, this is then sent to 
   * frmPersonnelVerified though a Session object
****************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmPersonnel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Check security level. If security is not Admin then redirect the user to the login page.
        if (Session["SecurityLevel"] != "A")
        {
            Response.Redirect("frmLogin.aspx");
        }
        //check the security level of the user and determine their access
        if (Session["SecurityLevel"] == "A")
        {
            //If security level is Admin then display the submit button
            btnSubmit.Visible = true;
            
        }
        else
        {//If security level is not Admin then hide the submit button
            btnSubmit.Visible = false;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //Declare variables to use locally
        String fName = txtFirstName.Text;
        String lName = txtLastName.Text;
        String payRate = txtPayRate.Text;
        
        //Boolean variable to determine if the information is valid
        Boolean valid = false;

        //Wait to set the dates until the name and pay rate have been entered
        DateTime startDate;
        DateTime endDate;


        try
        {
            /*old validation
            //fName validation
            if (fName.Trim() == "")
            {//if fName is empty then change the text box to yellow and print the error message
                txtFirstName.BackColor = System.Drawing.Color.Yellow;
                lblError.BackColor = System.Drawing.Color.Red;
                lblError.Text = "Please enter First Name";
                valid = false;
            }
            else
            {*/
                //Create txtFirstName as a Session object
                Session["txtFirstName"] = txtFirstName.Text;
                txtFirstName.BackColor = System.Drawing.Color.White;
                lblError.Text = "";
               
                /*old validation
                    //lName validation
                    if (lName.Trim() == "")
                    {//if lName is empty then change the text box to yellow and print the error message
                        txtLastName.BackColor = System.Drawing.Color.Yellow;
                        lblError.BackColor = System.Drawing.Color.Red;
                        lblError.Text = "Please enter Last Name";
                        valid = false;
                    }
                    else
                    {*/

                    //Create txtLastName as a Session object
                    Session["txtLastName"] = txtLastName.Text;
                    txtLastName.BackColor = System.Drawing.Color.White;
                    lblError.Text = "";
                    valid = true;

                    /* old validation
                     * //payRate validation
                      if (payRate.Trim() == "")
                      {//if payRate is empty then change the text box to yellow and print the error message
                          txtPayRate.BackColor = System.Drawing.Color.Yellow;
                          lblError.BackColor = System.Drawing.Color.Red;
                          lblError.Text = "Please enter Pay Rate";
                          valid = false;
                      }
                      else
                      {*/
                   
                        
                        //Date format is validtated in the form through a regular expression validator
                        startDate = DateTime.Parse(Request["txtStartDate"]);
                        endDate = DateTime.Parse(Request["txtEndDate"]);
                        if (DateTime.Compare(startDate, endDate) > 0)
                        {//if the end date is before the start date change the text box to yellow and print the error message
                            txtStartDate.BackColor = System.Drawing.Color.Yellow;
                            txtEndDate.BackColor = System.Drawing.Color.Yellow;
                            lblError.Text = "The end date must be a later date than the start date.";
                            valid = false;
                        }
                        else
                        {
                            //if valid create txtStartDate and txtEndDate as Session objects
                            Session["txtStartDate"] = txtStartDate.Text;
                            Session["txtEndDate"] = txtEndDate.Text;
                            txtStartDate.BackColor = System.Drawing.Color.White;
                            txtEndDate.BackColor = System.Drawing.Color.White;
                            lblError.Text = "";
                            valid = true;
                        }

                        //new pay rate validation moved and includes its own try/catch to make sure that pay rate is a number.
                        try
                        {
                            //make sure pay rate is a number
                            int pRate = Convert.ToInt32(payRate);

                            //if valid create txtPayRate as a Session object
                            Session["txtPayRate"] = txtPayRate.Text;
                            txtPayRate.BackColor = System.Drawing.Color.White;
                            lblError.Text = "";
                            valid = true;
                        }
                        catch (FormatException f)
                        {
                            //Let the user know that they need to enter a number
                            lblError.Text = "Please enter a numerical Pay Rate";
                            valid = false;
                        }
                   // }
                //}
           // }
       
        

        //if all of the statements are valid then pass the information to frmPersonnelVerified
        if (valid == true)
        {
            Response.Redirect("frmPersonnelVerified.aspx");
        }
    }
        catch (Exception ex)
        {
            //If any of the information is not correct, or if the dates are blank 
            if (Request["txtStartDate"].ToString().Trim() == "" || Request["txtEndDate"].ToString().Trim() == "")
            {
                lblError.Text = "The start date and end date can not be blank";
            }
            else {
            lblError.Text = "There as been an error! Please try again with correct data";
            }
        }
    }
}