<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="login" runat="server" defaultbutton="btnLogin" defaultfocus="txtUserName">
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
        </table>
        <%-- 
        <asp:Table ID="Table1" runat="server" Width="517px">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblUserName" runat="server" Text="User Name : "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtUserName" runat="server" CausesValidation="True"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReqUserName" runat="server" ErrorMessage="User Name is required." CssClass="validator" ControlToValidate="txtUserName" Display="Dynamic"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblPassword" runat="server" Text="Password : "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="password" CausesValidation="True"></asp:TextBox>  
                    <asp:RequiredFieldValidator ID="ReqPassword" runat="server" ErrorMessage="Password is required" ControlToValidate="txtPassword" Display="Dynamic" CssClass="validator"></asp:RequiredFieldValidator>                
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="btnLogin" runat="server" Text="Login" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>--%>
    </form>
</asp:Content>

