/*
 * Author: Geetha, Linden, Sunny
 * Date: July 05, 2015
 * Description: Main application
 * 
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMP248WorkShop2_Team6
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmProductSupplier());
            //Application.Run(new frmSupplierMaintenance());
            //Application.Run(new frmPackageMaintenance());
            //Application.Run(new frmProductSupplierMaintenance());
            Application.Run(new frmMain());
        }
    }
}
