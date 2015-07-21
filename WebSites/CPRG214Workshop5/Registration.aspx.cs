using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{

    private Customer customer = new Customer();
    //bool userAvailablity = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["CustomerId"] != null)
            {
                int customerId = Convert.ToInt32(Session["CustomerId"]);
                txtUserName.Enabled = false;
                //customer = (Customer)Session["Customer"];
                customer = CustomerDB.GetCustomerDetails(customerId);
                this.DisplayCustomerDetails();
            }
        }
    }

    private void DisplayCustomerDetails()
    {
        txtUserName.Text = customer.CustUserName;
        //txtEditUserName.Text = customer.CustUserName;
        txtPassword.Text = customer.CustPassword;
        //txtConfirmPassword.Text = customer.CustConfirmPassword;
        txtConfirmPassword.Text = customer.CustPassword;
        txtCustFirstName.Text = customer.CustFirstName;
        txtCustLastName.Text = customer.CustLastName;
        txtCustAddress.Text = customer.CustAddress;
        txtCustCity.Text = customer.CustCity;
        txtCustProv.Text = customer.CustProv;
        txtCustPostal.Text = customer.CustPostal;
        txtCustCountry.Text = customer.CustCountry;
        txtCustHomePhone.Text = customer.CustHomePhone;
        txtCustBusPhone.Text = customer.CustBusPhone;
        txtCustEmail.Text = customer.CustEmail;
        txtAgentId.Text = customer.AgentId.ToString() == null ? "" : customer.AgentId.ToString();
    }


    //Method to register the customer details
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if(IsValid)
        {
            customer.CustUserName = txtUserName.Text;
            customer.CustPassword = txtPassword.Text;
            customer.CustConfirmPassword = txtConfirmPassword.Text;             
            customer.CustFirstName = txtCustFirstName.Text;
            customer.CustLastName = txtCustLastName.Text;
            customer.CustAddress = txtCustAddress.Text;
            customer.CustCity = txtCustCity.Text;
            customer.CustProv = txtCustProv.Text;
            customer.CustPostal = txtCustPostal.Text;
            customer.CustCountry = txtCustCountry.Text;
            customer.CustHomePhone = txtCustHomePhone.Text;
            customer.CustBusPhone = txtCustBusPhone.Text;
            customer.CustEmail = txtCustEmail.Text;
            //txtAgentId.Text = "-1";
            //customer.AgentId = Convert.ToInt32(txtAgentId.Text);
            customer.AgentId = -1;
            if (CustomerDB.CheckUserAvailablity(txtUserName.Text))
            {
                int customerId = CustomerDB.RegisterCustomer(customer);
                if (customerId > 0)
                    Response.Redirect("Confirmation.aspx");
                else
                    Response.Redirect("Registration.aspx");
            }
        }
    }

    //Method to clear the customer registration form
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtUserName.Text = "";
        txtPassword.Text = "";
        txtConfirmPassword.Text = "";
        txtCustFirstName.Text = "";
        txtCustLastName.Text = "";
        txtCustAddress.Text = "";
        txtCustCity.Text = "";
        txtCustProv.Text = "";
        txtCustPostal.Text = "";
        txtCustCountry.Text = "";
        txtCustHomePhone.Text = "";
        txtCustBusPhone.Text = "";
        txtCustEmail.Text = "";
        txtAgentId.Text = "";
    }

    protected void btnCheckUser_Click(object sender, EventArgs e)
    {
       // bool userAvailablity = CustomerDB.CheckUserAvailablity(txtUserName.Text);
        if (CustomerDB.CheckUserAvailablity(txtUserName.Text))
        {
            lblUserNameInfo.Text = "UserName already exists. Please try other.";
        }
        else
        {
            lblUserNameInfo.Text = "Proceed with your username";
        }        
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            customer.CustUserName = txtUserName.Text;
            customer.CustPassword = txtPassword.Text;
            customer.CustConfirmPassword = txtConfirmPassword.Text;
            customer.CustFirstName = txtCustFirstName.Text;
            customer.CustLastName = txtCustLastName.Text;
            customer.CustAddress = txtCustAddress.Text;
            customer.CustCity = txtCustCity.Text;
            customer.CustProv = txtCustProv.Text;
            customer.CustPostal = txtCustPostal.Text;
            customer.CustCountry = txtCustCountry.Text;
            customer.CustHomePhone = txtCustHomePhone.Text;
            customer.CustBusPhone = txtCustBusPhone.Text;
            customer.CustEmail = txtCustEmail.Text;
            customer.CustomerId = Convert.ToInt32(Session["CustomerId"]);
            //txtAgentId.Text = "-1";
            //customer.AgentId = Convert.ToInt32(txtAgentId.Text);
            customer.AgentId = -1;
            
            bool updateStatus = CustomerDB.UpdateCustomer(customer);
            if (updateStatus)
                Response.Redirect("Confirmation.aspx");
            else
                Response.Redirect("Registration.aspx");
            
        }
    }
}