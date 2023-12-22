//Programmer Jason Rhoads
//CIS 407A
//03/14/15
//The code for when btnCalculateSalary is clicked in the frmSalaryCalculator page

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmSalaryCalculator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCalculateSalary_Click(object sender, EventArgs e)
    {
        //create double variables needed
        double hours = 0;
        double payRate = 0;
        double annualSalary = 0;

        //create String variables for hours and pay rate
        String sHours = "0";
        String sPayRate = "0";

        //get input from user
        sHours = txtAnnualHours.Text;
        sPayRate = txtPayRate.Text;

        //convert the String variables to double variables
        hours = Convert.ToDouble(sHours);
        payRate = Convert.ToDouble(sPayRate);

        //calcualte annual salary
        annualSalary = hours * payRate;

        //display output
        lblAnnualSalary.Text = "Annual Salary is " + annualSalary.ToString("C");
    }
}