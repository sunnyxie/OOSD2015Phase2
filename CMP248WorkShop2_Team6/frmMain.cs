/*
 * Author: Geetha
 * Date: July 06, 2015
 * Usage: Main Form to run the application
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

namespace CMP248WorkShop2_Team6
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        //Method to show PackageProductSupplier table
        private void btnPackageProdSuppTable_Click(object sender, EventArgs e)
        {
            Form packageProductSupplierForm = new frmPackageProductSupplier();
            packageProductSupplierForm.Show();
        }
        //Method to show PackageMaintenance
        private void btnPackageMaintenance_Click(object sender, EventArgs e)
        {
            Form packageForm = new frmPackageMaintenance();
            packageForm.Show();
        }
        //Method to show SupplierMaintenance
        private void btnSupplierMaintenance_Click(object sender, EventArgs e)
        {
            Form supplierForm = new frmSupplierMaintenance();
            supplierForm.Show();
        }
        //Method to showProductMaintenance
        private void btnProdMaintenance_Click(object sender, EventArgs e)
        {
            Form productForm = new frmProductMaintenance();
            productForm.Show();
        }
        //Method to close the application.
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
