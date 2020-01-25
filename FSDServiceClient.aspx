<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FSDServiceClient.aspx.cs" Inherits="Cognizant_FSD.FSDServiceClient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox runat="server" ID="txtName"></asp:TextBox>&nbsp;&nbsp;
            <asp:Button ID="btnHTTP" runat="server" Text="HTTP" OnClick="btnHTTP_Click" />
            <asp:Button ID="btnTCP" runat="server" Text="TCP" OnClick="btnTCP_Click" />&nbsp;<br />
            <asp:Label ID="lblHello" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lblbProgram" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
