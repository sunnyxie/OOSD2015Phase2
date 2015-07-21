using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Customer login = new Customer();
        login.CustUserName = txtUserName.Text;
        login.CustPassword = txtPassword.Text;

        Customer customer = CustomerDB.GetLoginCredential(login);
        if (customer != null)
        {
            Session["Customer"] = customer;
            Response.Redirect("Confirmation.aspx");
        }

    }
}