/*
 * Author: Geetha, Linden
 * Date: July 07, 2015
 * Usage: Validation for Package Maintenance
 * 
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMP248WorkShop2_Team6
{
    /// <summary>
    /// Provides static methods for validating data.
    /// </summary>
    public static class Validator
    {
        private static string title = "Entry Error";

        /// <summary>
        /// The title that will appear in dialog boxes.
        /// </summary>
        public static string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        /// <summary>
        /// Checks whether the user entered data into a text box.
        /// </summary>
        /// <param name="textBox">The text box control to be validated.</param>
        /// <returns>True if the user has entered data.</returns>
        public static bool IsPresent(Control control)
        {
            if (control.GetType().ToString() == "System.Windows.Forms.TextBox")
            {
                TextBox textBox = (TextBox)control;
                if (textBox.Text == "")
                {
                    MessageBox.Show(textBox.Tag + " is a required field.", Title);
                    textBox.Focus();
                    return false;
                }
            }
            else if (control.GetType().ToString() == "System.Windows.Forms.ComboBox")
            {
                ComboBox comboBox = (ComboBox)control;
                if (comboBox.SelectedIndex == -1)
                {
                    MessageBox.Show(comboBox.Tag + " is a required field.", "Entry Error");
                    comboBox.Focus();
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Checks whether the user entered a decimal value into a text box.
        /// </summary>
        /// <param name="textBox">The text box control to be validated.</param>
        /// <returns>True if the user has entered a decimal value.</returns>
        public static bool IsDecimal(TextBox textBox)
        {
            try
            {
                Convert.ToDecimal(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag + " must be a decimal number.", Title);
                textBox.Focus();
                return false;
            }
        }

        /// <summary>
        /// Checks whether the user entered an int value into a text box.
        /// </summary>
        /// <param name="textBox">The text box control to be validated.</param>
        /// <returns>True if the user has entered an int value.</returns>
        public static bool IsInt32(TextBox textBox)
        {
            try
            {
                Convert.ToInt32(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag + " must be an integer.", Title);
                textBox.Focus();
                return false;
            }
        }

        /// <summary>
        /// Checks whether the user entered a value within a specified range into a text box.
        /// </summary>
        /// <param name="textBox">The text box control to be validated.</param>
        /// <param name="min">The minimum value for the range.</param>
        /// <param name="max">The maximum value for the range.</param>
        /// <returns>True if the user has entered a value within the specified range.</returns>
        public static bool IsWithinRange(TextBox textBox, decimal min, decimal max)
        {
            decimal number = Convert.ToDecimal(textBox.Text);
            if (number < min || number > max)
            {
                MessageBox.Show(textBox.Tag + " must be between " + min.ToString()
                    + " and " + max.ToString() + ".", Title);
                textBox.Focus();
                return false;
            }
            return true;
        }

        //Method to check the Package End Date must be later than Package Start Date
        public static bool DateCheck(DateTime pkgStartDate, DateTime pkgEndDate)
        {          
            TimeSpan difference = pkgEndDate.Subtract(pkgStartDate); // Subtract dates to get duration.
            int days = difference.Days;
            if (days < 0) // Single day events are allowed. Maybe we want to offer day trips.
            {
                MessageBox.Show("Package End Date must be later than Package Start Date");
                return false;
            }
            else
                return true;
        }

        //Validation for PackageAgencyCommission field, Commission shouldn't be greater than package base price
        public static bool ValidateCommission(TextBox textBox, string name, decimal pkgAgencyCommission, decimal pkgBasePrice)
        {            
            if (pkgBasePrice < pkgAgencyCommission)
            {
                MessageBox.Show(name + " can not be greater than Package Base Price");
                textBox.Focus();
                return false;
            }                    
            else
                return true;           
        }

        //Method to check for positive integer
        public static bool IsPositive(TextBox textBox)
        {
            decimal number = Convert.ToDecimal(textBox.Text);
            if (number < 0) // Allow zero, in case baseprice or commission are zero for either a free promotion or non-commission package.
            {
                MessageBox.Show(textBox.Tag + " must be an positive integer.", Title);
                textBox.Focus();
                return false;
            }
            else
                return true;
        }

        // Validator for database indices, which start at 1
        public static bool IsPositiveOverZero(TextBox textBox)
        {
            decimal number = Convert.ToDecimal(textBox.Text);
            if (number <= 0) // Do not allow zero, database IDs start at 1
            {
                MessageBox.Show(textBox.Tag + " must be an positive integer over zero.", Title);
                textBox.Focus();
                return false;
            }
            else
                return true;
        }
    }
}