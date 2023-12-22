<%/************************************************
   * Programmer Jason Rhoads
   * CIS 407A
   * 03/29/15
   * Displays employee information from tblPersonnel
***************************************************/
%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmViewPersonnel.aspx.cs" Inherits="frmViewPersonnel" %>

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
        <asp:GridView ID="grdViewPersonnel" runat="server">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
