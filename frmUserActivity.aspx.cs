/*******************************************************
   * Programmer Jason Rhoads
   * CIS 407A
   * 03/22/15
   * frmUserActivity formats and calls upon clsDataLayer 
   * to get the recent user activity and add the current
   * usage and saves/binds it to the database.
*********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Check security level. If security is not Admin then redirect the user to the login page.
        if (Session["SecurityLevel"] != "A")
        {
            Response.Redirect("frmLogin.aspx");
        }

        if (!Page.IsPostBack)
        {
            // Declares the DataSet
            dsUserActivity myDataSet = new dsUserActivity();
            // Fill the dataset with what is returned from the function
            myDataSet = clsDataLayer.GetUserActivity(Server.MapPath("PayrollSystem_DB.accdb"));
            // Sets the DataGrid to the DataSource based on the table
            grdUserActivity.DataSource = myDataSet.Tables["tblUserActivity"];
            // Binds the DataGrid
            grdUserActivity.DataBind();
        }
    }
}