/**
 * Author: Geetha, Linden
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
        // Author: Geetha
        // Method to get the Package, Product and Suppliers details
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

        // Author: Linden
        // Insert Package->ProductSupplier link
        public static bool InsertPackageProductSupplier(int packageId, int productSupplierId)
        {
            string qryInsert = "INSERT Packages_Products_Suppliers (PackageId, ProductSupplierId) VALUES (@PackageId, @ProductSupplierId)";
            using (SqlConnection dbConn = TravelExpertsDB.GetConnection())
            {
                using (SqlCommand cmdInsert = new SqlCommand(qryInsert, dbConn))
                {
                    cmdInsert.Parameters.AddWithValue("@PackageId", packageId);
                    cmdInsert.Parameters.AddWithValue("@ProductSupplierId", productSupplierId);
                    try
                    {
                        dbConn.Open();
                        return cmdInsert.ExecuteNonQuery() > 0; // return true if there were any affected rows
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
        }

        // Author: Linden
        // Delete Package->ProductSupplier link
        public static bool DeletePackageProductSupplier(int packageId, int productSupplierId)
        {
            string qryDelete = "DELETE FROM Packages_Products_Suppliers WHERE PackageId = @PackageId AND ProductSupplierId = @ProductSupplierId";
            using (SqlConnection dbConn = TravelExpertsDB.GetConnection())
            {
                using (SqlCommand cmdDelete = new SqlCommand(qryDelete, dbConn))
                {
                    cmdDelete.Parameters.AddWithValue("@PackageId", packageId);
                    cmdDelete.Parameters.AddWithValue("@ProductSupplierId", productSupplierId);
                    try
                    {
                        dbConn.Open();
                        return cmdDelete.ExecuteNonQuery() > 0; // return true if there were any affected rows
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
        }

        // Author: Linden
        // Delete all links for Package
        public static bool DeletePackageProductSuppliersByPackage(int packageId)
        {
            string qryDelete = "DELETE FROM Packages_Products_Suppliers WHERE PackageId = @PackageId";
            using (SqlConnection dbConn = TravelExpertsDB.GetConnection())
            {
                using (SqlCommand cmdDelete = new SqlCommand(qryDelete, dbConn))
                {
                    cmdDelete.Parameters.AddWithValue("@PackageId", packageId);
                    try
                    {
                        dbConn.Open();
                        return cmdDelete.ExecuteNonQuery() > 0; // return true if there were any affected rows
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
        }

        // Author: Linden
        // Delete all links for Package
        public static bool DeletePackageProductSuppliersByProductSupplier(int productSupplierId)
        {
            string qryDelete = "DELETE FROM Packages_Products_Suppliers WHERE ProductSupplierId = @ProductSupplierId";
            using (SqlConnection dbConn = TravelExpertsDB.GetConnection())
            {
                using (SqlCommand cmdDelete = new SqlCommand(qryDelete, dbConn))
                {
                    cmdDelete.Parameters.AddWithValue("@ProductSupplierId", productSupplierId);
                    try
                    {
                        dbConn.Open();
                        return cmdDelete.ExecuteNonQuery() > 0; // return true if there were any affected rows
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
        }

        // Author: Linden
        // Delete Package->ProductSupplier->Product link
        public static bool DeletePackageProductSuppliersByProduct(int productId)
        {
            string qryDelete = "DELETE pps FROM Packages_Products_Suppliers pps, Products_Suppliers ps " +
                "WHERE ps.ProductId = @ProductId AND pps.ProductSupplierId = ps.ProductSupplierId";
            using (SqlConnection dbConn = TravelExpertsDB.GetConnection())
            {
                using (SqlCommand cmdDelete = new SqlCommand(qryDelete, dbConn))
                {
                    cmdDelete.Parameters.AddWithValue("@ProductId", productId);
                    try
                    {
                        dbConn.Open();
                        return cmdDelete.ExecuteNonQuery() > 0; // return true if there were any affected rows
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
        }

        // Author: Linden
        // Delete Package->ProductSupplier->Supplier link
        public static bool DeletePackageProductSuppliersBySupplier(int supplierId)
        {
            string qryDelete = "DELETE pps FROM Packages_Products_Suppliers pps, Products_Suppliers ps " +
                "WHERE ps.SupplierId = @SupplierId AND pps.ProductSupplierId = ps.ProductSupplierId";
            using (SqlConnection dbConn = TravelExpertsDB.GetConnection())
            {
                using (SqlCommand cmdDelete = new SqlCommand(qryDelete, dbConn))
                {
                    cmdDelete.Parameters.AddWithValue("@SupplierId", supplierId);
                    try
                    {
                        dbConn.Open();
                        return cmdDelete.ExecuteNonQuery() > 0; // return true if there were any affected rows
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
        }
    }
}
