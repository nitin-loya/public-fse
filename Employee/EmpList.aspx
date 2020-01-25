<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpList.aspx.cs" Inherits="Cognizant_FSD.Employee.EmpList" %>

<%@ Register Src="~/Employee/Navigation.ascx" TagPrefix="uc1" TagName="Navigation" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Navigation runat="server" id="Navigation" />
        <div>
            <asp:GridView ID="EmpGrid" runat="server" EmptyDataText="No employees defined."></asp:GridView>
        </div>
    </form>
</body>
</html>
