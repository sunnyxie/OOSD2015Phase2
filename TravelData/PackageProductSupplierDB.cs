/**
 * Author:Geetha
 * Date: July 06, 2015
 * Usage: File to interact with database to get details about package, product and suppliers
 * */
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelData
{
    public static class PackageProductSupplierDB
    {
        //Method to get the Package, Product and Suppliers details
        public static List<PackageProductSupplier> GetAllPackageProductSupplier()
        {
            List<PackageProductSupplier> packageProductSupplierList = new List<PackageProductSupplier>();

            //Get connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            //selectquery to retrieve data from the package, product and supplier
            string selectStatement = "SELECT pkg.PackageId AS PackageId, PkgName, PkgDesc, PkgStartDate, PkgEndDate,PkgBasePrice, " +
                                        "PkgAgencyCommission,pps.ProductSupplierId AS ProductSupplierId , " + 
                                        "p.ProductId AS ProductId, ProdName, s.SupplierId AS SupplierId,SupName " +
                                        "FROM Packages pkg " +
                                        "INNER JOIN Packages_Products_Suppliers pps ON pkg.PackageId = pps.PackageId " +
                                        "INNER JOIN Products_Suppliers ps ON ps.ProductSupplierId = pps.ProductSupplierId " +
                                        "INNER JOIN Products p ON p.ProductId = ps.ProductId " +
                                        "INNER JOIN Suppliers s ON s.SupplierId = ps.SupplierId";

            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            try
            {
                //open connection and read the data form the query result
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                //get the result and set it in the packageproductsupplier object
                while (reader.Read())
                {
                    PackageProductSupplier packageProductSupplier = new PackageProductSupplier();
                    packageProductSupplier.PackageId = Convert.ToInt32(reader["PackageId"]);
                    packageProductSupplier.PkgName = reader["PkgName"].ToString();
                    packageProductSupplier.PkgDes = reader["PkgDesc"].ToString();
                    packageProductSupplier.PkgStartDate = (DateTime)reader["PkgStartDate"];
                    packageProductSupplier.PkgEndDate = (DateTime)reader["PkgEndDate"];
                    packageProductSupplier.PkgBasePrice = Convert.ToDecimal(reader["PkgBasePrice"]);
                    packageProductSupplier.PkgAgencyCommission = Convert.ToDecimal(reader["PkgAgencyCommission"]);
                    packageProductSupplier.ProductSupplierId = Convert.ToInt32(reader["ProductSupplierId"]);
                    packageProductSupplier.ProductId = Convert.ToInt32(reader["ProductId"]);
                    packageProductSupplier.SupplierId = Convert.ToInt32(reader["SupplierId"]);
                    packageProductSupplier.ProdName = reader["ProdName"].ToString();
                    packageProductSupplier.SupName = reader["SupName"].ToString();
                    packageProductSupplierList.Add(packageProductSupplier);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                //close connection
                connection.Close();
            }
            //return the packageproductsupplier list
            return packageProductSupplierList;
        }       
    }
}
