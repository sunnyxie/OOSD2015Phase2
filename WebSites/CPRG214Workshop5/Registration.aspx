<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 44%;
            border-collapse: collapse;
        }
        .auto-style2 {
            width: 541px;
        }
        .auto-style3 {
            width: 541px;
            height: 27px;
        }
        .auto-style4 {
            height: 27px;
            width: 736px;
        }
        .auto-style5 {
            width: 736px;
        }
    .auto-style6 {
        color: #006666;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server" defaultbutton="btnRegister" defaultfocus="txtUserName">
    <h1 class="auto-style6">Welcome to Travel Experts</h1>
    <table class="auto-style1">
        <tr>
            <td class="auto-style3">
                <asp:Label ID="lblUserName" runat="server" Text="User Name : "></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqCustUserName" runat="server" CssClass="validator" Display="Dynamic" ErrorMessage="UserName is required." ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                <asp:Button ID="btnCheckUser" runat="server" OnClick="btnCheckUser_Click" Text="Check Availablity" CausesValidation="False" />
                <asp:Label ID="lblUserNameInfo" runat="server" AssociatedControlID="btnCheckUser" CssClass="validator"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lblPassword" runat="server" Text="Password : "></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:TextBox ID="txtPassword" runat="server" CausesValidation="True"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqCustPassword" runat="server" ControlToValidate="txtPassword" CssClass="validator" Display="Dynamic" ErrorMessage="Password is required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password : "></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:TextBox ID="txtConfirmPassword" runat="server" CausesValidation="True"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqCustConfirmPwd" runat="server" ControlToValidate="txtConfirmPassword" CssClass="validator" Display="Dynamic" ErrorMessage="Confirm Password is required."></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompConfirmPwd" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" CssClass="validator" Display="Dynamic" ErrorMessage="Password and ConfirmPassword should be same"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lblCustFirstName" runat="server" Text="First Name : "></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:TextBox ID="txtCustFirstName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqCustFirstName" runat="server" ControlToValidate="txtCustFirstName" CssClass="validator" Display="Dynamic" ErrorMessage="First Name is required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lblCustLastName" runat="server" Text="Last Name : "></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:TextBox ID="txtCustLastName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqCustLastName" runat="server" ControlToValidate="txtCustLastName" CssClass="validator" Display="Dynamic" ErrorMessage="Last Name is required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lblAddress" runat="server" Text="Address : "></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:TextBox ID="txtCustAddress" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqCustAddress" runat="server" ControlToValidate="txtCustAddress" CssClass="validator" Display="Dynamic" ErrorMessage="Address is required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lblCustCity" runat="server" Text="City : "></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:TextBox ID="txtCustCity" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqCustCity" runat="server" ControlToValidate="txtCustCity" CssClass="validator" Display="Dynamic" ErrorMessage="City is required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lblCustProv" runat="server" Text="Province : "></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:TextBox ID="txtCustProv" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqCustProv" runat="server" ControlToValidate="txtCustProv" CssClass="validator" Display="Dynamic" ErrorMessage="Province is required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lblCustPostal" runat="server" Text="Postal : "></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:TextBox ID="txtCustPostal" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqCustPostal" runat="server" ControlToValidate="txtCustPostal" CssClass="validator" Display="Dynamic" ErrorMessage="Postal code is required"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegCustPostal" runat="server" ErrorMessage="Postal code is not in valid format" ControlToValidate="txtCustPostal" CssClass="validator" Display="Dynamic" ValidationExpression="^[A-Z]\d[A-Z]\s?\d[A-Z]\d$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lblCustCountry" runat="server" Text="Country : "></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:TextBox ID="txtCustCountry" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqCustCountry" runat="server" ControlToValidate="txtCustCountry" CssClass="validator" Display="Dynamic" ErrorMessage="Country is required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lblCustHomePhone" runat="server" Text="Home Phone : "></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:TextBox ID="txtCustHomePhone" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqCustHomePhone" runat="server" ControlToValidate="txtCustHomePhone" CssClass="validator" Display="Dynamic" ErrorMessage="Home Phone is required"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegExCustHomePhone" runat="server" ControlToValidate="txtCustHomePhone" Display="Dynamic" ErrorMessage="Home Phone number must contain 10 digit" CssClass="validator" ValidationExpression="^\d{10}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lblCustBusPhone" runat="server" Text="Business Phone : "></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:TextBox ID="txtCustBusPhone" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegExCustBusPhone" runat="server" ControlToValidate="txtCustBusPhone" Display="Dynamic" ErrorMessage="Business Phone Number is not in valid format" CssClass="validator" ValidationExpression="^\d{10}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lblCustEmail" runat="server" Text="Email : "></asp:Label>               
            </td>
            <td class="auto-style5">
                <asp:TextBox ID="txtCustEmail" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegExCustEmail" runat="server" ControlToValidate="txtCustEmail" Display="Dynamic" ErrorMessage="Email is not in valid format." CssClass="validator" ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lblAgentId" runat="server" Text="Agent Id : "></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:TextBox ID="txtAgentId" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2" >
                <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
            </td>
            <td>
                <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
            </td>
            
        </tr>
    </table>
    </form>   

</asp:Content>

