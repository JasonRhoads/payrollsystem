/*******************************************************
   * Programmer Jason Rhoads
   * CIS 407A
   * 04/16/15
   * frmLogin determins the authentication of the users
   * trying to access the system, now with greater authentication
*********************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        //Create a new user login
        dsUser dsUserLogin;
        //determine the security level
        string SecurityLevel;
        // Verify login
        dsUserLogin = clsDataLayer.VerifyUser(Server.MapPath("PayrollSystem_DB.accdb"),
        Login1.UserName, Login1.Password);
        // determine authentication
        if (dsUserLogin.tblUserLogin.Count < 1)
        {
            e.Authenticated = false;
            // Autentication has failed
            // Send an email informing the user that their login was incorrect and send an email to the developers
            if (clsBusinessLayer.SendEmail("jasrhoads@gmail.com",
            "receiver@receiverdomain.com", "", "", "Login Incorrect",
            "The login failed for UserName: " + Login1.UserName +
            " Password: " + Login1.Password))
            {
                Login1.FailureText = Login1.FailureText +
                " Your incorrect login information was sent to receiver@receiverdomain.com";
            }
    
            return;
        }
        // Get SecurityLevel
        SecurityLevel = dsUserLogin.tblUserLogin[0].SecurityLevel.ToString();
        // Test SecurityLevel
        switch (SecurityLevel)
        {
            case "A":
                //Administrator privliges
                e.Authenticated = true;
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, false);
                Session["SecurityLevel"] = "A";
                break;
            case "U":
                //User privliges 
                e.Authenticated = true;
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, false);
                Session["SecurityLevel"] = "U";
                break;
            default:
                e.Authenticated = false;
                break;
        }
    }
}