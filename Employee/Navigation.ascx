<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navigation.ascx.cs" Inherits="Cognizant_FSD.Employee.Navigation" %>
<div>
    <asp:Label ID="IndexLabel" runat="server" Text="Home"></asp:Label>
    <asp:HyperLink ID="IndexMenu" runat="server" NavigateUrl="~/Employee/EmpLst.aspx">Home</asp:HyperLink>
    |
    <asp:Label ID="NewLabel" runat="server" Text="New"></asp:Label>
    <asp:HyperLink ID="NewMenu" runat="server" NavigateUrl="~/Employee/new.aspx">New</asp:HyperLink>
    |
    <asp:Label ID="EditLabel" runat="server" Text="Edit"></asp:Label>
    <asp:HyperLink ID="EditMenu" runat="server" NavigateUrl="~/Employee/edit.aspx">Edit</asp:HyperLink>
    |
    <asp:Label ID="DeleteLabel" runat="server" Text="Delete"></asp:Label>
    <asp:HyperLink ID="DeleteMenu" runat="server" NavigateUrl="~/Employee/delete.aspx">Delete</asp:HyperLink>
</div>

