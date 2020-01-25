<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Cognizant_FSD.Employee.Edit" %>
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
            <asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="SearchButton_Click" />
        </div>
        <div>
            <table>
                <tr>
                    <td>Emp Id</td>
                    <td>
                        <asp:TextBox ID="EmpNoTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>First Name</td>
                    <td>
                        <asp:TextBox ID="FirstNameTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Last Name</td>
                    <td>
                        <asp:TextBox ID="LastNameTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Department</td>
                    <td>
                        <asp:TextBox ID="DeptTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="SaveButton" runat="server" Text="Save" OnClick="SaveButton_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
