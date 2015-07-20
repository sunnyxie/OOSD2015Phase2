/*
 * Author : Geetha
 * Date: July 07, 2015
 * Usage: File used for search, add, modify, delete the package
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
    public partial class frmPackageMaintenance : Form
    {
        public frmPackageMaintenance()
        {
            InitializeComponent();
        }

        private Packages packages;
       
        //Method to view the package details by packageId
        private void btnGetPackage_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(txtPackageId) &&
                Validator.IsInt32(txtPackageId) &&
                Validator.IsPositiveOverZero(txtPackageId))
            {
                int packageId = Convert.ToInt32(txtPackageId.Text);
                this.GetPackages(packageId);
                if (packages == null)
                {
                    MessageBox.Show("No Packages found with this ID. Try again.", "PackageId not found");
                    this.ClearControls();
                }
                else
                {
                    this.DisplayPackages();
                }
            }
        }
        //Method to call the databaselayer to get the package details
        private void GetPackages(int packageId)
        {
            packages = PackagesDB.GetPackages(packageId);
        }

        //Method to clear all package details fields
        private void ClearControls()
        {
            txtPackageId.Text = "";
            txtPkgAgencyCommission.Text = "";
            txtPkgBasePrice.Text = "";
            txtPkgDesc.Text = "";
            txtPkgEndDate.Text = "";
            txtPkgStartDate.Text = "";
            txtPkgName.Text = "";
            dgvProductSupplierView.DataSource = new List<ProductSupplier>();
        }

        //Method to display package details
        private void DisplayPackages()
        {
            txtPackageId.Text = packages.PackageId.ToString();
            txtPkgAgencyCommission.Text = packages.PkgAgencyCommission.ToString();
            txtPkgBasePrice.Text = packages.PkgBasePrice.ToString();
            txtPkgDesc.Text = packages.PkgDesc.ToString();
            txtPkgEndDate.Text = packages.PkgEndDate.ToShortDateString();
            txtPkgStartDate.Text = packages.PkgStartDate.ToShortDateString();
            txtPkgName.Text = packages.PkgName.ToString();
            btnModify.Enabled = true;
            btnDelete.Enabled = true;
            dgvProductSupplierView.DataSource = ProductSupplierDB.GetProductSuppliersByPackage(packages.PackageId);
        }

        //Method to add package
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddModifyPackages addPackagesForm = new frmAddModifyPackages();
            addPackagesForm.addPackages = true;
            DialogResult result = addPackagesForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                packages = addPackagesForm.packages;
                txtPackageId.Text = packages.PackageId.ToString();
                this.DisplayPackages();
            }
        }

        //Method to modify package
        private void btnModify_Click(object sender, EventArgs e)
        {
            frmAddModifyPackages modifyPackagesForm = new frmAddModifyPackages();
            modifyPackagesForm.addPackages = false;
            modifyPackagesForm.packages = packages;
            DialogResult result = modifyPackagesForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                packages = modifyPackagesForm.packages;
                this.DisplayPackages();
            }
            else if (result == DialogResult.Retry)
            {
                this.GetPackages(packages.PackageId);
                if (packages != null)
                    this.DisplayPackages();
                else
                    this.ClearControls();
            }
        }

        //Method to delete package
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Delete " + packages.PkgName + "?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (!PackagesDB.DeletePackage(packages))
                    {
                        MessageBox.Show("Another user has updated or deleted " +
                                            "that Packages.", "Database Error");
                        this.GetPackages(packages.PackageId);
                        if (packages != null)
                            this.DisplayPackages();
                        else
                            this.ClearControls();
                    }
                    else
                        this.ClearControls();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
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
