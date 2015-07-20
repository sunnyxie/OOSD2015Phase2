/*
 * Author: Geetha, Linden
 * Date: July 06, 2015
 * Usage: File used to interact with database and get the details of product and suppliers
 * 
 * */
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;

namespace TravelData
{
    public static class ProductSupplierDB
    {
        // Author: Linden
        public static List<ProductSupplier> GetProductSuppliers()
        {
            List<ProductSupplier> productSuppliers = new List<ProductSupplier>();
            string qrySelect = "SELECT ps.ProductSupplierId, ps.ProductId, p.ProdName, ps.SupplierId, s.SupName " +
                "FROM Products_Suppliers ps, Products p, Suppliers s " +
                "WHERE ps.ProductId = p.ProductId AND ps.SupplierId = s.SupplierId";
            using (SqlConnection dbConn = TravelExpertsDB.GetConnection())
            {
                using (SqlCommand cmdSelect = new SqlCommand(qrySelect, dbConn))
                {
                    try
                    {
                        dbConn.Open();
                        SqlDataReader dbReader = cmdSelect.ExecuteReader();
                        while (dbReader.Read())
                        {
                            ProductSupplier productSupplier = new ProductSupplier();
                            productSupplier.ProductSupplierId = Convert.ToInt32(dbReader["ProductSupplierId"]);
                            productSupplier.ProductId = Convert.ToInt32(dbReader["ProductId"]);
                            productSupplier.SupplierId = Convert.ToInt32(dbReader["SupplierId"]);
                            productSupplier.ProdName = Convert.ToString(dbReader["ProdName"]);
                            productSupplier.SupName = Convert.ToString(dbReader["SupName"]);
                            productSuppliers.Add(productSupplier);
                        }
                        dbReader.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        dbConn.Close();
                    }
                }
            }
            return productSuppliers;
        }

        // Author: Linden
        public static List<ProductSupplier> GetProductSuppliersByPackage(int packageId)
        {
            List<ProductSupplier> productSuppliers = new List<ProductSupplier>();
            string qrySelect = "SELECT ps.ProductSupplierId, ps.ProductId, p.ProdName, ps.SupplierId, s.SupName " +
                "FROM Packages_Products_Suppliers pps, Products_Suppliers ps, Products p, Suppliers s " +
                "WHERE pps.PackageId = @PackageId AND pps.ProductSupplierId = ps.ProductSupplierId AND ps.ProductId = p.ProductId AND ps.SupplierId = s.SupplierId";
            using (SqlConnection dbConn = TravelExpertsDB.GetConnection())
            {
                using (SqlCommand cmdSelect = new SqlCommand(qrySelect, dbConn))
                {
                    cmdSelect.Parameters.AddWithValue("@PackageId", packageId);
                    try
                    {
                        dbConn.Open();
                        SqlDataReader dbReader = cmdSelect.ExecuteReader();
                        while (dbReader.Read())
                        {
                            ProductSupplier productSupplier = new ProductSupplier();
                            productSupplier.ProductSupplierId = Convert.ToInt32(dbReader["ProductSupplierId"]);
                            productSupplier.ProductId = Convert.ToInt32(dbReader["ProductId"]);
                            productSupplier.SupplierId = Convert.ToInt32(dbReader["SupplierId"]);
                            productSupplier.ProdName = Convert.ToString(dbReader["ProdName"]);
                            productSupplier.SupName = Convert.ToString(dbReader["SupName"]);
                            productSuppliers.Add(productSupplier);
                        }
                        dbReader.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        dbConn.Close();
                    }
                }
            }
            return productSuppliers;
        }
        // Author: Linden
        // get all products and suppliers from joined tables
        public static List<ProductSupplier> GetProductSupplierbyProdIdSupId(int productId, int supplierId)
        {
            List<ProductSupplier> productSupplierList = new List<ProductSupplier>();
            //Get connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            string selectStatement = "SELECT ProductSupplierId, ProductId, SupplierId " +
                                     "FROM Products_Suppliers " +
                                     "WHERE ProductId = @ProductId AND SupplierId = @SupplierId";

             SqlCommand selectCommand = new SqlCommand(selectStatement, connection);

             selectCommand.Parameters.AddWithValue("@ProductId",productId);
             selectCommand.Parameters.AddWithValue("@SupplierId", supplierId);
             try
             {
                 connection.Open();
                 //Read the data from the query result
                 SqlDataReader reader = selectCommand.ExecuteReader();
                 //get the result and set it in productsupplier object
                 while (reader.Read())
                 {
                     ProductSupplier productSupplier = new ProductSupplier();
                     productSupplier.ProductSupplierId = Convert.ToInt32(reader["ProductSupplierId"]);
                     productSupplier.ProductId = Convert.ToInt32(reader["ProductId"]);
                     productSupplier.SupplierId = Convert.ToInt32(reader["SupplierId"]);
                     productSupplierList.Add(productSupplier);
                 }
                 reader.Close();
             }
             //catch (ConstraintException ex) // Added to temporarily resolve conflicts with unused tables
             //{
             //    string qryAlter = "ALTER TABLE [Packages_Products_Suppliers] DROP CONSTRAINT [Packages_Products_Supplie_FK01]";
             //    SqlCommand cmdAlter = new SqlCommand(qryAlter, connection);
             //    cmdAlter.ExecuteNonQuery();
             //}
             // NOTE: Doesn't work as it should, instead run the following queries before running:
             // "ALTER TABLE Packages_Products_Suppliers DROP CONSTRAINT Packages_Products_Supplie_FK01"
             // "ALTER TABLE BookingDetails DROP CONSTRAINT FK_BookingDetails_Products_Suppliers"
             catch (SqlException ex)
             {
                 throw ex;
             }
            finally
            {
                connection.Close();
            }
            //return the productSupplierList
            return productSupplierList;
        }

        //written by Linden
        //Method to delete the product_supplier relation based on productId
        public static bool DeleteLinksByProduct(int productId)
        {
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string qryDelete = "DELETE FROM Products_Suppliers " +
                                     "WHERE ProductId = @ProductId";
            SqlCommand cmdDelete = new SqlCommand(qryDelete, dbConn);
            cmdDelete.Parameters.AddWithValue("@ProductId", productId);
            try
            {
                dbConn.Open();
                return cmdDelete.ExecuteNonQuery() > 0;
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
        //Written by Geetha -- start

        //Method to get productsupplier record based on productsupplierId
        public static List<ProductSupplier> GetProductSupplierByProductSupplierId(int productSupplierId)
        {
            List<ProductSupplier> productSupplierList = new List<ProductSupplier>();
            //Get connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            string selectStatement = "SELECT ProductSupplierId, ProductId, SupplierId " +
                                     "FROM Products_Suppliers " +
                                     "WHERE ProductSupplierId = @ProductSupplierId";

            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);

            selectCommand.Parameters.AddWithValue("@ProductSupplierId", productSupplierId);
            try
            {
                connection.Open();
                //Read the data from the selectCommand query result
                SqlDataReader reader = selectCommand.ExecuteReader();
                //get the result and set it in productsupplier object
                while (reader.Read())
                {
                    ProductSupplier productSupplier = new ProductSupplier();
                    productSupplier.ProductSupplierId = Convert.ToInt32(reader["ProductSupplierId"]);
                    productSupplier.ProductId = Convert.ToInt32(reader["ProductId"]);
                    productSupplier.SupplierId = Convert.ToInt32(reader["SupplierId"]);
                    productSupplierList.Add(productSupplier);
                }
                reader.Close();
            }

            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            //return the productSupplierList
            return productSupplierList;
        }

        //Method to add the product to the product table
        public static bool AddProductSupplier(int productId, int supplierId)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string qryInsert = "INSERT Products_Suppliers (ProductId, SupplierId) VALUES (@ProductId, @SupplierId)";
            SqlCommand cmdInsert = new SqlCommand(qryInsert, connection);
            cmdInsert.Parameters.AddWithValue("@ProductId", productId);
            cmdInsert.Parameters.AddWithValue("@SupplierId", supplierId);
            try
            {
                connection.Open();
                int count = cmdInsert.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        //Method to update productsupplier by giving new and old proudctsupplier details
        public static bool UpdateProductSupplier(ProductSupplier oldProductSupplier, ProductSupplier productSupplier)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string updateStatement =
                "UPDATE Products_Suppliers SET " +
                "ProductId = @ProductId, " +
                "SupplierId = @SupplierId " +
                "WHERE ProductSupplierId = @OldProductSupplierId " +
                "AND ProductId = @OldProductId " +
                "AND SupplierId = @OldSupplierId";
            SqlCommand updateCommand = new SqlCommand(updateStatement, connection);

            updateCommand.Parameters.AddWithValue("@ProductId", productSupplier.ProductId);
            updateCommand.Parameters.AddWithValue("@SupplierId", productSupplier.SupplierId);
            updateCommand.Parameters.AddWithValue("@OldProductSupplierId", oldProductSupplier.ProductSupplierId);
            updateCommand.Parameters.AddWithValue("@OldProductId", oldProductSupplier.ProductId);
            updateCommand.Parameters.AddWithValue("@OldSupplierId", oldProductSupplier.SupplierId);

            try
            {
                connection.Open();
                int count = updateCommand.ExecuteNonQuery();    //get count of updated field
                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        //Method to delete the Productsupplier
        public static bool DeleteProductSupplier(int productSupplierId)
        {
            PackageProductSupplierDB.DeletePackageProductSupplierByProductSupplier(productSupplierId);
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string deleteStatement =
                            "DELETE FROM Products_Suppliers " +
                            "WHERE ProductSupplierId = @ProductSupplierId ";


            SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue("@ProductSupplierId", productSupplierId);

            try
            {
                connection.Open();
                int count = deleteCommand.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        //Method to get the count of productsupplier record based on productId and supplierId
        public static int CheckProductSupplier(int productId, int supplierId)
        {
            int pscount = 0;
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string countStatement = "SELECT COUNT(ProductSupplierId) FROM Products_Suppliers " + 
                             "WHERE ProductId = @ProductId and SupplierId = @SupplierId";

            SqlCommand countCommand = new SqlCommand(countStatement, connection);
            countCommand.Parameters.AddWithValue("@ProductId", productId);
            countCommand.Parameters.AddWithValue("@SupplierId", supplierId);

            try
            {
                connection.Open();
                //int pscount = countCommand.ExecuteScalar();
                 SqlDataReader pscountReader = countCommand.ExecuteReader();
                 
                 if (pscountReader.Read())
                 {
                    pscount = Convert.ToInt32(pscountReader["COUNT(*)"].ToString());
                     return pscount;
                 }
                 
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return pscount;
        }      
        //Written by Geetha -- end
    }
}
