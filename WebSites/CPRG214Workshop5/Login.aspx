<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" Runat="Server">
    <form id="login" runat="server" defaultbutton="btnLogin" defaultfocus="txtUserName">

        <asp:Label ID="lblError" runat="server" CssClass="validator"></asp:Label>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblUserName" runat="server" Text="User Name : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server" CausesValidation="True"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="User Name is required." CssClass="validator" ControlToValidate="txtUserName" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPassword" runat="server" Text="Password : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="password" CausesValidation="True"></asp:TextBox>  
                    <asp:RequiredFieldValidator ID="ReqPassword" runat="server" ErrorMessage="Password is required" ControlToValidate="txtPassword" Display="Dynamic" CssClass="validator"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                </td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                </td>
            </tr>
            <tr aria-invalid="false">
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Registration.aspx">Register here</asp:HyperLink>  
                </td>                  
            </tr>
        </table>       
    </form>
</asp:Content>

