/*
 * Author: Geetha, Linden
 * Date: July 06, 2015
 * Usage: File used to interact with database and get the details of package, product and suppliers
 * 
 * */
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TravelData
{
    public static class ProductSupplierDB
    {
        // get all products and suppliers from joined tables
        public static List<ProductSupplier> GetAllProductSupplier()
        {
            List<ProductSupplier> productSupplierList = new List<ProductSupplier>();
            //Get connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            string selectStatement = "SELECT ProductSupplierId, p.ProductId, s.SupplierId, p.ProdName as ProdName, s.SupName as SupName FROM Products p, " +
                                    "Suppliers s, Products_Suppliers ps " +
                                    "WHERE p.ProductId = ps.ProductId AND s.SupplierId = ps.SupplierId AND " +
                                    "ps.ProductSupplierId = productSupplierId";           

             SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
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
                     productSupplier.ProdName = reader["ProdName"].ToString();
                     productSupplier.SupName = reader["SupName"].ToString();
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
    }
}
