<%/*******************************************************
   * Programmer Jason Rhoads
   * CIS 407A
   * 04/12/15
   * frmLogin requires users to enter in login credintals
   * before they are allowed to access the system.
*********************************************************/
%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmLogin.aspx.cs" Inherits="frmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            text-align: left;
        }
    </style>
</head>
<body style="text-align: center">
    <form id="form1" runat="server" >
    <div class="auto-style1">
    
        <div class="auto-style2">
            <div class="auto-style2">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/CIS407A_iLab_ACITLogo.jpg" style="text-align: center" />
            <br />
            <br />
            <br />
            <br />
            </div>
        <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/frmMain.aspx" style="text-align: center; height: 132px; width: 460px; float: none;" OnAuthenticate="Login1_Authenticate" TitleText="Please enter your UserName and Password in order to log in to the system.">
        </asp:Login>
    
        </div>
    
    </div>
    </form>
</body>
</html>
