<%/************************************************
   * Programmer Jason Rhoads
   * CIS 407A
   * 03/29/15
   * Enter the last name of the employee you wish to
   * search by. This is then passed to frmViewPersonnel
***************************************************/
%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmSearchPersonnel.aspx.cs" Inherits="frmSearchPersonnel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/CIS407A_iLab_ACITLogo.jpg" PostBackUrl="~/frmMain.aspx" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Search for employee by last name:"></asp:Label>
&nbsp;<asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" PostBackUrl="~/frmViewPersonnel.aspx" Text="Search" style="height: 26px" />
    
    </div>
    </form>
</body>
</html>
