<%/************************************************
   * Programmer Jason Rhoads
   * CIS 407A
   * 03/22/15
   * Enter hours and pay rate then push the 
   * calcuate salary button to get the annual salary
***************************************************/
%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmSalaryCalculator.aspx.cs" Inherits="frmSalaryCalculator" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/Images/CIS407A_iLab_ACITLogo.jpg" NavigateUrl ="~/frmMain.aspx"/>
        <br />
        <br />
    
        <asp:Label ID="Label1" runat="server" Text="Annual Hours:"></asp:Label>&nbsp;&nbsp; &nbsp;
        <asp:TextBox ID="txtAnnualHours" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Pay Rate:"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtPayRate" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnCalculateSalary" runat="server" OnClick="btnCalculateSalary_Click" Text="Calcualte Salary" />
        <br />
        <br />
        <asp:Label ID="lblAnnualSalary" runat="server" Text="$"></asp:Label>
    
    </div>
    </form>
</body>
</html>
