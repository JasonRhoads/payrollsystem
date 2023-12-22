/*******************************************************
   * Programmer Jason Rhoads
   * CIS 407A
   * 04/12/15
   * The main form that has links depending on the login
   * credintials to 
   * frmPersonnel to add a new employee
   * frmSalaryCalculator to calculate an employees salary
   * frmUserActivity to monitor the amount of activity on
   * frmPersonnel
   * frmEditPersonnel, frmViewPersonnel, frmSearchPersonnel
*********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmMain : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Connect the clsDataLayer to the database and frmPersonnel
        clsDataLayer.SaveUserActivity(Server.MapPath("PayrollSystem_DB.accdb"), "frmPersonnel");

        //if the security level is admin then display all of the funtions
        if (Session["SecurityLevel"] == "A")
        {
            linkbtnNewEmployee.Visible = true;
            imgbtnNewEmployee.Visible = true;

            linkbtnViewUserActivity.Visible = true;
            imgbtnViewUserActivity.Visible = true;

            linkbtnEditEmployees.Visible = true;
            imgbtnEditEmployees.Visible = true;

            linkbtnManageUsers.Visible = true;
            imgbtnManageUsers.Visible = true;
           
        }
            //if not then hide administrative functions
        else
        {
            linkbtnNewEmployee.Visible = false;
            imgbtnNewEmployee.Visible = false;

            linkbtnViewUserActivity.Visible = false;
            imgbtnViewUserActivity.Visible = false;

            linkbtnEditEmployees.Visible = false;
            imgbtnEditEmployees.Visible = false;

            linkbtnManageUsers.Visible = false;
            imgbtnManageUsers.Visible = false;
        }
        
    }
}