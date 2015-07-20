/*
 * Author: Linden
 * Date: 2015/07/17
 * Usage: Data access object for Package table
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Data access class for Package table
/// </summary>
[DataObject(true)]
public static class PackageDB
{
    // Method to retreive package details for the particular packageId
    [DataObjectMethod(DataObjectMethodType.Select)]
    public static List<Package> GetPackagesByCustomer(int customerId)
    {
        List<Package> packages = new List<Package>();
        string qrySelect = "SELECT p.PackageId, p.PkgName, p.PkgStartDate, p.PkgEndDate, p.PkgDesc, p.PkgBasePrice, p.PkgAgencyCommission " +
            "FROM Customers c, Bookings j1, BookingDetails j2, Packages_Products_Suppliers j3, Packages p " +
            "WHERE c.CustomerId = @CustomerId AND " +
            "c.CustomerId = j1.CustomerId AND " +
            "j1.BookingId = j2.BookingId AND " +
            "j2.ProductSupplierId = j3.ProductSupplierId AND " +
            "j3.PackageId = p.PackageId";
        using (SqlConnection dbConn = TravelExpertsDB.GetConnection())
        {
            using (SqlCommand cmdSelect = new SqlCommand(qrySelect, dbConn))
            {
                cmdSelect.Parameters.AddWithValue("@CustomerId", customerId);
                try
                {
                    dbConn.Open();
                    SqlDataReader dbReader = cmdSelect.ExecuteReader();
                    while (dbReader.Read())
                    {
                        Package package = new Package();
                        package.PackageId = Convert.ToInt32(dbReader["PackageId"]);
                        package.PkgName = Convert.ToString(dbReader["PkgName"]);
                        package.PkgStartDate = Convert.ToDateTime(dbReader["PkgStartDate"]);
                        package.PkgEndDate = Convert.ToDateTime(dbReader["PkgEndDate"]);
                        package.PkgDesc = Convert.ToString(dbReader["PkgDesc"]);
                        package.PkgBasePrice = Convert.ToDecimal(dbReader["PkgBasePrice"]);
                        package.PkgAgencyCommission = Convert.ToDecimal(dbReader["PkgAgencyCommission"]);
                        packages.Add(package);
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    dbConn.Close();
                }
            }
        }
        return packages;
    }
}
