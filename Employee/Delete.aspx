<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="Cognizant_FSD.Employee.Delete" %>

<%@ Register Src="~/Employee/Navigation.ascx" TagPrefix="uc1" TagName="Navigation" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Navigation runat="server" ID="Navigation" />
        <div>
            Employee Id
            <asp:TextBox ID="EmpSearchBox" runat="server"></asp:TextBox>
            <asp:Button ID="DeleteButton" runat="server" Text="Delete" OnClick="SearchButton_Click" />
        </div>
    </form>
</body>
</html>
