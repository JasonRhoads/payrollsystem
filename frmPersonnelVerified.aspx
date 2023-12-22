<%/******************************************************
   * Programmer Jason Rhoads
   * CIS 407A
   * 03/22/15
   * Gathers input from frmPersonnel when the page loads
   * and shows the input in a text box
********************************************************/
%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmPersonnelVerified.aspx.cs" Inherits="frmPersonnelVerified" %>

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
        <br />
        <asp:Panel ID="Panel1" runat="server" Height="2500px" Width="650px">
            <asp:Label ID="Label1" runat="server" Text="Information To Submit"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="txtVerifiedInfo" runat="server" Height="100px" TextMode="MultiLine" Width="400px"></asp:TextBox>
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
