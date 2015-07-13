/*
 * Author : Geetha
 * Date: July 05, 2015
 * Usage: File to add/modify/delete/get supplier details
 * 
 * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelData;

namespace CMP248WorkShop2_Team6
{
    public partial class frmSupplierMaintenance : Form
    {
        public frmSupplierMaintenance()
        {
            InitializeComponent();
        }
        private Supplier supplier;

        //Method to get the supplier details by passing supplierid
        private void btnGetSupplier_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(txtSupplierId) &&
                Validator.IsInt32(txtSupplierId) &&
                Validator.IsPositiveOverZero(txtSupplierId))
            {
                //get supplier id
                int supplierId = Convert.ToInt32(txtSupplierId.Text);
                //Method to get the supplier details by passing supplier id
                this.GetSupplier(supplierId);
                if (supplier == null)
                {
                    MessageBox.Show("No Supplier found with this ID. Try again.", "SupplierId not found");
                    this.ClearControls();
                }
                else
                {
                    this.DisplaySupplier();
                }
            }
        }

        //Method to connect with dabase layer to get the supplier details
        private void GetSupplier(int supplierId)
        {
            supplier = SupplierDB.GetSupplier(supplierId);
        }

        //Method to clear all supplier fields
        private void ClearControls()
        {
            txtSupplierId.Text = "";
            txtSupName.Text = "";
        }

        //Method to display supplier details
        private void DisplaySupplier()
        {
            txtSupplierId.Text = supplier.SupplierId.ToString(); ;
            txtSupName.Text = supplier.SupName;
            btnModify.Enabled = true;
            btnDelete.Enabled = true;
        }     

        //Method to add supplier
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddModifySupplier addSupplierForm = new frmAddModifySupplier();
            addSupplierForm.addSupplier = true;
            DialogResult result = addSupplierForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                supplier = addSupplierForm.supplier;
                txtSupplierId.Text = supplier.SupplierId.ToString();
                this.DisplaySupplier();
            }
        }

        //Method to modify the existing supplier details
        private void btnModify_Click(object sender, EventArgs e)
        {
            frmAddModifySupplier modifySupplierForm = new frmAddModifySupplier();
            modifySupplierForm.addSupplier = false;
            modifySupplierForm.supplier = supplier;
            DialogResult result = modifySupplierForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                supplier = modifySupplierForm.supplier;
                if (supplier != null)
                {
                    this.DisplaySupplier();
                }
            }
            else if (result == DialogResult.Retry)
            {
                this.GetSupplier(supplier.SupplierId);
                if (supplier != null)
                    this.DisplaySupplier();
                else
                    this.ClearControls();
            }
        }

        //Method to delete the supplier
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Delete " + supplier.SupplierId+"?" ,
                                "Confirm Delete", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (!SupplierDB.DeleteSupplier(supplier))
                    {
                        MessageBox.Show("Another user has updated that supplier", "Database Error");
                        this.GetSupplier(supplier.SupplierId);
                        if (supplier != null)
                            this.DisplaySupplier();
                        else
                            this.ClearControls();
                    }
                    else
                        this.ClearControls();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,ex.GetType().ToString());
                }
            }
        }

        //Method to close the application
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
