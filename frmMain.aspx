<%/*******************************************************
   * Programmer Jason Rhoads
   * CIS 407A
   * 03/22/15
   * The main form that has links to
   * frmPersonnel to add a new employee
   * frmSalaryCalculator to calculate an employees salary
*********************************************************/
%>


<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmMain.aspx.cs" Inherits="frmMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Image ID="Image1" runat="server" EnableTheming="False" ImageUrl="~/Images/CIS407A_iLab_ACITLogo.jpg" />
        <br />
        <asp:Panel ID="Panel1" runat="server" Height="350px" style="margin-top: 0px" Width="500px">
            <asp:ImageButton ID="imgbtnCalculator" runat="server" Height="144px" ImageUrl="~/Images/calculator.jpg" Width="154px" PostBackUrl="~/frmSalaryCalculator.aspx" />
            &nbsp;&nbsp;
            <asp:LinkButton ID="linkbtnCalculator" runat="server" PostBackUrl="~/frmSalaryCalculator.aspx">Annual Salary Calculator</asp:LinkButton>
            <br />
            <br />
            <br />
            <asp:ImageButton ID="imgbtnNewEmployee" runat="server" Height="129px" ImageUrl="~/Images/personnel.jpg" Width="155px" PostBackUrl="~/frmPersonnel.aspx" />
            &nbsp;&nbsp;
            <asp:LinkButton ID="linkbtnNewEmployee" runat="server" PostBackUrl="~/frmPersonnel.aspx">Add New Employee</asp:LinkButton>
            <br />
            <br />
            <asp:ImageButton ID="imgbtnViewUserActivity" runat="server" Height="149px" ImageUrl="~/Images/user_activity.jpg" PostBackUrl="~/frmUserActivity.aspx" Width="148px" />
            &nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="linkbtnViewUserActivity" runat="server" PostBackUrl="~/frmUserActivity.aspx">View User Activity</asp:LinkButton>
            <br />
            <br />
            <asp:ImageButton ID="imgbtnViewPersonnel" runat="server" Height="125px" ImageUrl="~/Images/ViewPersonnel.jpg" PostBackUrl="~/frmViewPersonnel.aspx" Width="146px" />
            &nbsp;&nbsp;&nbsp; <asp:LinkButton ID="linkbtnViewPersonnel" runat="server" PostBackUrl="~/frmViewPersonnel.aspx">View Personnel</asp:LinkButton>
            <br />
            <br />
            <asp:ImageButton ID="imgbtnSearch" runat="server" Height="117px" ImageUrl="~/Images/searchPersonnel.jpg" PostBackUrl="~/frmSearchPersonnel.aspx" Width="145px" />
            &nbsp;<asp:LinkButton ID="linkbtnSearch" runat="server" PostBackUrl="~/frmSearchPersonnel.aspx">Search Personnel</asp:LinkButton>
            <br />
            <br />
            <asp:ImageButton ID="imgbtnEditEmployees" runat="server" Height="99px" ImageUrl="~/Images/editPersonnel.jpg" PostBackUrl="~/frmEditPersonnel.aspx" Width="143px" />
            &nbsp;<asp:LinkButton ID="linkbtnEditEmployees" runat="server" PostBackUrl="~/frmEditPersonnel.aspx">Edit Personnel</asp:LinkButton>
            <br />
            &nbsp;<br />
            <asp:ImageButton ID="imgbtnManageUsers" runat="server" Height="104px" ImageUrl="~/Images/ManageUsers.jpg" PostBackUrl="~/frmManageUsers.aspx" Width="139px" />
            &nbsp;
            <asp:LinkButton ID="linkbtnManageUsers" runat="server" PostBackUrl="~/frmManageUsers.aspx">Manage Users</asp:LinkButton>
            <br />
        </asp:Panel>
        <br />
    
    </div>
    </form>
</body>
</html>
