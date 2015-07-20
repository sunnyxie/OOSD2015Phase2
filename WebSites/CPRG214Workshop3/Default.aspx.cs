/*
 * Author: Sunny Xie, Geetha and Linden 
 * Date: July 15, 2015
 * Usage: The data access class to retrieve or Update Customer details
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = ""; // Clear old error messages whenever page (re)loads
    }

    // method triggered by form update (Before)
    protected void ObjectDataSource2_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        e.AffectedRows = Convert.ToInt32(e.ReturnValue);
    }

    // method triggered by form update (After)
    protected void frmCustomer_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
    {
        if (e.Exception != null)
        {
            lblError.Text = "A database error has occurred.<br />" + e.Exception.Message;
            if (e.Exception.InnerException != null)
                lblError.Text += "<br />Message: " + e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
            e.KeepInEditMode = true;
        }
        else if (e.AffectedRows == 0)
        {
            lblError.Text = "Another user may have updated that Customer. Please try again.";
        }
    }
    // mainly check the Emails fields when Click Update to update the customer record
    protected void frmCustomer_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {
        string homePhone = e.NewValues["CustHomePhone"].ToString();
        string busPhone = e.NewValues["CustBusPhone"].ToString();
        homePhone = homePhone.Trim();
        busPhone = busPhone.Trim();

        if (homePhone == "")
        {
            lblError.Text = "Home Phone field need a telephone No.";
            e.Cancel = true;
            return;
        }
        /*
        if (busPhone == "")
        {
            lblError.Text = "Bus Phone field need a telephone No.";
            e.Cancel = true;
            return;
        }
        */
        if (PhonesValidate(ref homePhone))
        {
            e.NewValues["CustHomePhone"] = homePhone;
        }
        else
        {
            e.Cancel = true;
            lblError.Text = "Home Phone field need a valid telephone No.";
        }

        if (PhonesValidate(ref busPhone, true))
        {
            e.NewValues["CustBusPhone"] = busPhone;
        }
        else
        {
            e.Cancel = true;
            // e.KeepInEditMode = true;
            lblError.Text = "Bus Phone field need a valid telephone No.";
        }
    }

    // use regular expression Replace to validate the phone Nos and return (403)999-9999 format phone No
    // to the parameter(ref)
    private static bool PhonesValidate(ref string phoneNo, bool allowEmpty = false)
    {
        string pat = @"^((\d{3})(\d{3})(\d{4}))$";
        string pat2 = @"^(\d{3})(\.|_|-|\s*)(\d{3})(\.|_|-|\s*)(\d{4})$";
        string pat3 = @"^(\((\d{3})\)(\d{3})(\d{4}))$";
        string pat4 = @"^(\((\d{3})\)(\d{3})-(\d{4}))$";

        // Instantiate the regular expression object.
        Regex r = new Regex(pat4, RegexOptions.IgnoreCase);

        // Match the regular expression pattern against a text string.
        Match m = r.Match(phoneNo);
        if (m.Success || (allowEmpty && phoneNo == ""))
        {
            return true;
        }

        string replacement = "($2)$3-$4";
        // Match the regular expression pattern against a text string and replace.
        string ll = Regex.Replace(phoneNo, pat, replacement);

        if (ll != phoneNo)
        {
            phoneNo = ll;
            return true;
        }
        else   // the second match
        {
            ll = Regex.Replace(phoneNo, pat3, replacement);
            if (ll != phoneNo)
            {
                phoneNo = ll;
                return true;
            }

            ll = Regex.Replace(phoneNo, pat4, replacement);
            if (ll != phoneNo)
            {
                phoneNo = ll;
                return true;
            }

            replacement = "($1)$3-$5";
            ll = Regex.Replace(phoneNo, pat2, replacement);

            if (ll != phoneNo)
            {
                phoneNo = ll;
                return true;
            }
        }

        return false;
    }
}