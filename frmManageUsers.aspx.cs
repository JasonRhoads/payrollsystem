/*******************************************************
   * Programmer Jason Rhoads
   * CIS 407A
   * 04/12/15
   * frmManageUsers lets users add and edit/delete user
   * login information and change their security level
*********************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmManageUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Check security level. If security is not Admin then redirect the user to the login page.
        if (Session["SecurityLevel"] != "A")
        {
            Response.Redirect("frmLogin.aspx");
        }
    }
    protected void btnAddUser_Click(object sender, EventArgs e)
    {
        //check to add a user to the database, if succesfull display success and refresh the gridView.
        if (clsDataLayer.SaveUser(Server.MapPath("PayrollSystem_DB.accdb"), txtUserName.Text, txtPassword.Text, ddlSecurityLevel.SelectedValue))
        {
            lblDisplay.Text = "The user was successfully added!";
            grdUsers.DataBind();
        }
        else
        {
            lblDisplay.Text = "The user was NOT added!";
        }
    }
}