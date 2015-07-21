<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" Runat="Server">
    <%if(Session["CustomerId"] != null) 
      {%>
        <h5 align="right">Hello <%--Session["CustName"]; --%></h5>
    <% }%>
    <div style="float:left">
        <ul class ="nav navbar-nav">
            <li>
                <a href="Home.aspx">Home</a>
                <%if(Session["CustomerId"] != null)
                  { %>
                <a href="Registration.aspx">Edit/Update Account</a> 
                <a href="Package">View Package and Booking Details</a>                
                <a href="login.aspx">Logout</a>
                <% } %>               
            </li>
        </ul>
    </div>

</asp:Content>

