<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%--
    Author: Linden, Geetha
    Written: 2015/07/17
--%>
<asp:Content ID="headContent" runat="server" ContentPlaceHolderID="headPlaceHolder">
</asp:Content>
<asp:Content ID="formContent" runat="server" ContentPlaceHolderID="formPlaceHolder">
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblFormHead" runat="server" Text="Customer Management"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Select Customer:"></asp:Label>
&nbsp;<asp:DropDownList ID="ddlCustomers" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1" DataTextField="CustName" DataValueField="CustomerId">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCustomers" TypeName="CustomerDB"></asp:ObjectDataSource>
        <br />
        <br />
        <asp:Label ID="lblCustHead" runat="server" Text="Customer Details:"></asp:Label>
        <br />
        <asp:FormView ID="frmCustomer" runat="server" DataSourceID="ObjectDataSource2" OnItemUpdated="frmCustomer_ItemUpdated" CssClass="custForm" OnItemUpdating="frmCustomer_ItemUpdating">
            <EditItemTemplate>
                <table>
                    <tr>
                        <td>CustomerId:</td>
                        <td><asp:TextBox ID="txtCustomerId" runat="server" Enabled="False" Text='<%# Bind("CustomerId") %>' /></td>
                    </tr>
                    <tr>
                        <td>CustFirstName:</td>
                        <td><asp:TextBox ID="txtCustFirstName" runat="server" Text='<%# Bind("CustFirstName") %>' CausesValidation="True" />
                            <asp:RequiredFieldValidator ID="ReqFirstName" runat="server" ControlToValidate="txtCustFirstName" Display="Dynamic" ErrorMessage="First Name is required." ForeColor="#CC3300"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>CustLastName:</td>
                        <td><asp:TextBox ID="txtCustLastName" runat="server" Text='<%# Bind("CustLastName") %>' CausesValidation="True" />
                            <asp:RequiredFieldValidator ID="ReqLastName" runat="server" ControlToValidate="txtCustLastName" Display="Dynamic" ErrorMessage="Last Name is required." ForeColor="#CC3300"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>CustAddress:</td>
                        <td><asp:TextBox ID="txtCustAddress" runat="server" Text='<%# Bind("CustAddress") %>' CausesValidation="True" />
                            <asp:RequiredFieldValidator ID="ReqAddress" runat="server" ControlToValidate="txtCustAddress" Display="Dynamic" ErrorMessage="Address is required." ForeColor="#CC3300"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>CustCity:</td>
                        <td><asp:TextBox ID="txtCustCity" runat="server" Text='<%# Bind("CustCity") %>' CausesValidation="True" />
                            <asp:RequiredFieldValidator ID="ReqCity" runat="server" ControlToValidate="txtCustCity" Display="Dynamic" ErrorMessage="City is required." ForeColor="#CC3300"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>CustProv:</td>
                        <td><asp:TextBox ID="txtCustProv" runat="server" Text='<%# Bind("CustProv") %>' CausesValidation="True" />
                            <asp:RequiredFieldValidator ID="ReqProv" runat="server" ControlToValidate="txtCustProv" Display="Dynamic" ErrorMessage="Province is required." ForeColor="#CC3300"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>CustPostal:</td>
                        <td><asp:TextBox ID="txtCustPostal" runat="server" Text='<%# Bind("CustPostal") %>' CausesValidation="True" />
                            <asp:RequiredFieldValidator ID="ReqPostal" runat="server" ControlToValidate="txtCustPostal" Display="Dynamic" ErrorMessage="Postal Code is required." ForeColor="#CC3300"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegExPostal" runat="server" ControlToValidate="txtCustPostal" Display="Dynamic" ErrorMessage="Postal Code must be valid." ForeColor="#CC3300" ValidationExpression="^[A-Z]\d[A-Z]\s?\d[A-Z]\d$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>CustCountry:</td>
                        <td><asp:TextBox ID="txtCustCountry" runat="server" Text='<%# Bind("CustCountry") %>' CausesValidation="True" />
                            <asp:RequiredFieldValidator ID="ReqCountry" runat="server" ControlToValidate="txtCustCountry" Display="Dynamic" ErrorMessage="Country is required." ForeColor="#CC3300"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td> CustHomePhone:</td>
                        <td><asp:TextBox ID="txtCustHomePhone" runat="server" Text='<%# Bind("CustHomePhone") %>' CausesValidation="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>CustBusPhone:</td>
                        <td><asp:TextBox ID="txtCustBusPhone" runat="server" Text='<%# Bind("CustBusPhone") %>' CausesValidation="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>CustEmail:</td>
                        <td><asp:TextBox ID="txtCustEmail" runat="server" Text='<%# Bind("CustEmail") %>' CausesValidation="True" />
                            <asp:RegularExpressionValidator ID="RegExEmail" runat="server" ControlToValidate="txtCustEmail" Display="Dynamic" ErrorMessage="Email is not in valid format." ForeColor="#CC3300" ValidationExpression="^.+@.+$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                      &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
           
            <ItemTemplate>
                <table>
                    <tr>                        
                        <td>CustomerId:</td>
                        <td><asp:Label ID="lblCustomerId" runat="server" Text='<%# Bind("CustomerId") %>' /></td>
                </tr>
                <tr>
                    <td>CustFirstName:</td>
                    <td> <asp:Label ID="lblCustFirstName" runat="server" Text='<%# Bind("CustFirstName") %>' /></td>
                </tr>
                <tr>
                    <td>CustLastName:</td>
                    <td><asp:Label ID="lblCustLastName" runat="server" Text='<%# Bind("CustLastName") %>' /></td>
                </tr>
                <tr>
                    <td>CustAddress:</td>
                    <td><asp:Label ID="lblCustAddress" runat="server" Text='<%# Bind("CustAddress") %>' /></td>
                </tr>
                <tr>
                    <td>CustCity:</td>
                    <td><asp:Label ID="lblCustCity" runat="server" Text='<%# Bind("CustCity") %>' /></td>
                </tr>
                <tr>
                    <td>CustProv:</td>
                    <td><asp:Label ID="lblCustProv" runat="server" Text='<%# Bind("CustProv") %>' /></td>
                </tr>
                    <tr>
                    <td>CustPostal:</td>
                    <td><asp:Label ID="lblCustPostal" runat="server" Text='<%# Bind("CustPostal") %>' /></td>
                </tr>
                    <tr>
                    <td>CustCountry:</td>
                    <td><asp:Label ID="lblCustCountry" runat="server" Text='<%# Bind("CustCountry") %>' /></td>
                </tr>
                    <tr>
                    <td>CustHomePhone:</td>
                    <td><asp:Label ID="lblCustHomePhone" runat="server" Text='<%# Bind("CustHomePhone") %>' /></td>
                </tr>
                <tr>
                    <td>CustBusPhone:</td>
                    <td><asp:Label ID="lblCustBusPhone" runat="server" Text='<%# Bind("CustBusPhone") %>' /></td>
                </tr>
                    <tr>
                    <td>CustEmail:</td>
                    <td><asp:Label ID="lblCustEmail" runat="server" Text='<%# Bind("CustEmail") %>' /></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
                    </td>
                </tr>                
                </table>
            </ItemTemplate>
        </asp:FormView>
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCustomerById" TypeName="CustomerDB" UpdateMethod="UpdateCustomer" ConflictDetection="CompareAllValues" DataObjectTypeName="Customer" OnUpdated="ObjectDataSource2_Updated">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlCustomers" Name="customerId" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="original_Customer" Type="Object" />
                <asp:Parameter Name="customer" Type="Object" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <br />
        <asp:Label ID="lblPackHead" runat="server" Text="Package Details:"></asp:Label>
        <br />
        <asp:GridView ID="gvPackage" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource3" CssClass="packForm" EmptyDataText="No Packages Found." ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:BoundField DataField="PackageId" HeaderText="PackageId" SortExpression="PackageId" />
                <asp:BoundField DataField="PkgName" HeaderText="PkgName" SortExpression="PkgName" />
                <asp:BoundField DataField="PkgStartDate" DataFormatString="{0:yyyy-MM-dd}" HeaderText="PkgStartDate" SortExpression="PkgStartDate" />
                <asp:BoundField DataField="PkgEndDate" DataFormatString="{0:yyyy-MM-dd}" HeaderText="PkgEndDate" SortExpression="PkgEndDate" />
                <asp:BoundField DataField="PkgDesc" HeaderText="PkgDesc" SortExpression="PkgDesc" />
                <asp:BoundField DataField="PkgBasePrice" HeaderText="PkgBasePrice" SortExpression="PkgBasePrice" />
                <asp:BoundField DataField="PkgAgencyCommission" HeaderText="PkgAgencyCommission" SortExpression="PkgAgencyCommission" />
            </Columns>
            <EmptyDataRowStyle HorizontalAlign="Center" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetPackagesByCustomer" TypeName="PackageDB">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlCustomers" Name="customerId" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        <br />
    
    </div>
    </form>
</asp:Content>
