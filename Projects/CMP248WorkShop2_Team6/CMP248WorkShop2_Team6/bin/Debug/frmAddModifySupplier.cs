/*
 * Author : Geetha
 * Date: July 05, 2015
 * Usage: File to add or modify supplier details
 * 
 * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelData;

namespace CMP248WorkShop2_Team6
{
    public partial class frmAddModifySupplier : Form
    {
        public frmAddModifySupplier()
        {
            InitializeComponent();
        }

        public bool addSupplier;
        public Supplier supplier;

        //Method to validate supplier data
        private bool IsValidData()
        {
            return 
                Validator.IsPresent(txtSupplierId) &&
                Validator.IsInt32(txtSupplierId) &&
                Validator.IsPositiveOverZero(txtSupplierId) &&   //Validate SupplierId
                    Validator.IsPresent(txtSupName);    //Validate SupplierName
        }

        //Get the user entered supplier details and save it in supplier object
        private void PutSupplierData(Supplier supplier)
        {
            supplier.SupplierId = Convert.ToInt32(txtSupplierId.Text);
            supplier.SupName = txtSupName.Text;
        }

        //Method to display supplier
        private void DisplaySupplier()
        {
            txtSupplierId.Text = supplier.SupplierId.ToString();
            txtSupName.Text = supplier.SupName;
        }

        //Method to add/modify supplier details
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (addSupplier)
                {
                    supplier = new Supplier();
                    this.PutSupplierData(supplier);
                    try
                    {
                        //supplier.SupplierId = SupplierDB.AddSupplier(supplier);
                        SupplierDB.AddSupplier(supplier);
                        this.DialogResult = DialogResult.OK;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message,ex.GetType().ToString());
                    }
                }
                else    //modify
                {
                    Supplier newSupplier = new Supplier();
                    newSupplier.SupplierId = supplier.SupplierId;
                    this.PutSupplierData(newSupplier);
                    try
                    {
                        if(!SupplierDB.UpdateSupplier(supplier, newSupplier))
                        {
                            MessageBox.Show("Another user has updated or deleted that supplier.","Database Error");
                            this.DialogResult = DialogResult.Retry;
                        }
                        else
                        {
                            supplier = newSupplier;
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    }
                }

            }
        }

        //Method to cancel the supplier maintenance application
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Method to load the supplier details on loading the form and display titles according to add or modify
        private void frmAddModifySupplier_Load(object sender, EventArgs e)
        {
            if (addSupplier)
            {
                this.Text = "Add Supplier";
            }
            else
            {
                this.Text = "Modify Supplier";
                this.DisplaySupplier();
            }
        }

    }
}
