<%/*************************************************
   * Programmer Jason Rhoads
   * CIS 407A
   * 03/22/15
   * Validates a new employee's information each 
   * field at a time, this is then sent to 
   * frmPersonnelVerified though a Session object
****************************************************/
%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmPersonnel.aspx.cs" Inherits="frmPersonnel" %>

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
        <asp:Panel ID="Panel1" runat="server" Height="185px" HorizontalAlign="Left" Width="458px">
            <asp:Label ID="Label1" runat="server" Text="First Name:" width="80px"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtFirstName" runat="server" width="128px"></asp:TextBox>
            &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName" ErrorMessage="First name can not be blank" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Last Name:" width="80px"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtLastName" runat="server" width="128px"></asp:TextBox>
            &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName" ErrorMessage="Last name can not be blank" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Pay Rate:" width="80px"></asp:Label>
            &nbsp;&nbsp; &nbsp;<asp:TextBox ID="txtPayRate" runat="server" width="128px"></asp:TextBox>
&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPayRate" ErrorMessage="Pay rate can not be blank" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Start Date:" width="80px"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtStartDate" runat="server" Width="128px"></asp:TextBox>
            &nbsp;&nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtStartDate" ErrorMessage="Needs to be in date format" ForeColor="Red" ValidationExpression="^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$"></asp:RegularExpressionValidator>
            <br />
            <asp:Label ID="Label5" runat="server" Text="End Date:" width="80px"></asp:Label>
            &nbsp;&nbsp; &nbsp;<asp:TextBox ID="txtEndDate" runat="server" Width="128px"></asp:TextBox>
            &nbsp;&nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEndDate" ErrorMessage="Needs to be in date format" ForeColor="Red" ValidationExpression="^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$"></asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:Button ID="btnSubmit" runat="server" Height="26px" OnClick="btnSubmit_Click" Text="Submit" />
            &nbsp;&nbsp;</asp:Panel>
    
    </div>
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
    </form>
</body>
</html>
