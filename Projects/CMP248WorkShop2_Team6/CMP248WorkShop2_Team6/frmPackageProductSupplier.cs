/*
 * Author: Geetha
 * Date: July 06, 2015
 * Usage: File to display data from 3 relational tables
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
    public partial class frmPackageProductSupplier : Form
    {
        public frmPackageProductSupplier()
        {
            InitializeComponent();
        }

        List<PackageProductSupplier> packageProductSupplierList = null;

        //Method to get the PackageProductSupplierList by relating 3 tables and display the list in datagrid view
        private void frmPackageProductSupplier_Load(object sender, EventArgs e)
        {
            packageProductSupplierList = PackageProductSupplierDB.GetAllPackageProductSupplier();
            packageProductSupplierDataGridView.DataSource = packageProductSupplierList;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
