/*******************************************************
   * Programmer Jason Rhoads
   * CIS 407A
   * 04/16/15
   * clsBusinessLayer.cs sends an email and returns true
   * when the email was sent successfuly and returns false
   * otherwise
*********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
// **** Add the following at the top of the class file,
// Use the System.Net.Mail library to be able to send MailMessages. 
using System.Net.Mail;


public class clsBusinessLayer
{
	public clsBusinessLayer()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //**** Add the following code inside the body of public class clsBusinessLayer ****
    public static bool SendEmail(string Sender, string Recipient, string bcc, string cc,
    string Subject, string Body)
    {
        //Try to send a new message using the parameters passed to the function.
        try
        {
            // Create a new message
            MailMessage MyMailMessage = new MailMessage();
            // Establish the sender
            MyMailMessage.From = new MailAddress(Sender);
            // Establish the recipient
            MyMailMessage.To.Add(new MailAddress(Recipient));
            // If the blind carbon copy, bcc, is not null and not empty then add a new BCC
            if (bcc != null && bcc != string.Empty)
            {
                // Add a BCC email to the message
                MyMailMessage.Bcc.Add(new MailAddress(bcc));
            }
            // If the carbon copy, cc, is not null and not empty then add a new CC
            if (cc != null && cc != string.Empty)
            {
                // Add a CC email to the message
                MyMailMessage.CC.Add(new MailAddress(cc));
            }
            // Set the subject line from subject the parameter
            MyMailMessage.Subject = Subject;
            // Set the body from the body parameter
            MyMailMessage.Body = Body;
            // Set the body of the email to HTML
            MyMailMessage.IsBodyHtml = true;
            // The priority of the mail message is normal
            MyMailMessage.Priority = MailPriority.Normal;
            // The mail is sent via local host through SMTP4DEV
            SmtpClient MySmtpClient = new SmtpClient("localhost");
            //The appropriate ports would be placed here when using an actual mail server.
            //SMTP Port = 25;
            //Generic IP host = "127.0.0.1";
            // Send the email
            MySmtpClient.Send(MyMailMessage);
            // The email has been sent
            return true;
        }
        catch (Exception ex)
        {
            //If an email cannot be sent return false
            return false;
        }
    }      
}
