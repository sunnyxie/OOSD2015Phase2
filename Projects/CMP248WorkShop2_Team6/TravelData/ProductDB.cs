/*
 * Author: Linden, Sunny, Geetha
 * Date: July 07, 2015
 * Usage: Database access object for Product table.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelData
{
    public static class ProductDB
    {
        // get all products from database, sorted for display
        public static List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string qrySelect =
                "SELECT ProductId, ProdName " +
                "FROM Products " + 
                "ORDER BY ProductId"; // selected columns from Products table
            SqlCommand cmdSelect = new SqlCommand(qrySelect, dbConn);
            try
            {
                dbConn.Open();
                SqlDataReader dbReader = cmdSelect.ExecuteReader();
                while (dbReader.Read())
                {
                    Product product = new Product();
                    product.ProductId = Convert.ToInt32(dbReader["ProductId"]);
                    product.ProdName = Convert.ToString(dbReader["ProdName"]);
                    products.Add(product);
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
            return products;
        }
        
        // get single product from database by productId
        public static Product GetProduct(int productId)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();

            string selectStatement = "SELECT ProductId, ProdName from Products p " +
                                     "WHERE ProductId = @ProductId";
            
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ProductId", productId);
            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);

                if (reader.Read())
                {
                    Product product = new Product();  
                    product.ProductId = Convert.ToInt32(reader["ProductId"]);
                    product.ProdName = reader["ProdName"].ToString();
                    return product;
                }
                else
                {
                    return null;
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
        }

        //Method to add the product to the product table
        public static void AddProduct(Product product)
        {
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string qryInsert = "INSERT Products (ProdName) VALUES (@ProdName)";
            SqlCommand cmdInsert = new SqlCommand(qryInsert, dbConn);
            cmdInsert.Parameters.AddWithValue("@ProdName", product.ProdName);
            try
            {
                dbConn.Open();
                cmdInsert.ExecuteNonQuery();
                //string qrySelect = "SELECT IDENT_CURRENT('Products') from Products";
                //SqlCommand cmdSelect = new SqlCommand(qrySelect, dbConn);
                //int productId = Convert.ToInt32(cmdSelect.ExecuteScalar());
                //return productId;
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

        //Method to update the product by passing old and new values of product details
        public static bool UpdateProduct(Product oldProduct, Product newProduct)
        {
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            //string qryUpdate = "UPDATE Products SET ProductId = @NewProductId, ProdName = @NewProdName " +
            string qryUpdate = "UPDATE Products SET ProdName = @NewProdName " +
                                     "WHERE ProductId = @OldProductId AND ProdName = @OldProdName";
            SqlCommand cmdUpdate = new SqlCommand(qryUpdate, dbConn);
            cmdUpdate.Parameters.AddWithValue("@OldProductId", oldProduct.ProductId);
            cmdUpdate.Parameters.AddWithValue("@OldProdName", oldProduct.ProdName);
            //cmdUpdate.Parameters.AddWithValue("@NewProductId", newProduct.ProductId);
            cmdUpdate.Parameters.AddWithValue("@NewProdName", newProduct.ProdName);
            try
            {
                dbConn.Open();
                return cmdUpdate.ExecuteNonQuery() > 0; // return true if there were any affected rows
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

        //Method to delete the product from product table by passing all values of product details
        public static bool DeleteProduct(Product product)
        {
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string qryDelete = "DELETE FROM Products " +
                                     "WHERE ProductId = @ProductId AND ProdName = @ProdName";
            SqlCommand cmdDelete = new SqlCommand(qryDelete, dbConn);
            cmdDelete.Parameters.AddWithValue("@ProductId", product.ProductId);
            cmdDelete.Parameters.AddWithValue("@ProdName", product.ProdName);
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
