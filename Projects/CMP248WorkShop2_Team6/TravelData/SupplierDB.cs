/*
 * Author: Geetha, Sunny Xie, Linden
 * Date: July 05, 2015
 * Description: File to interact with database to add, update, get and delete the supplier records
 * Added: insert or delete a Supplier's Product list.  <Jul 20>
 * 
 * */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelData
{
    public static class SupplierDB
    {
        // show the suppliers info for specific productID.
        public static List<Supplier> GetSuppliersByProduct(int productID)
        {
            List<Supplier> suppliers = new List<Supplier>();
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string qrySelect = "SELECT s.SupplierID, SupName "
                                   + "FROM Suppliers s "
                                   + "inner join Products_Suppliers ps ON ps.SupplierID = s.SupplierID "
                                   + "where ProductId= @ProductID "
                                   + "ORDER BY s.SupplierID";
            SqlCommand cmdSelect =
                new SqlCommand(qrySelect, dbConn);
            cmdSelect.Parameters.AddWithValue("@ProductID", productID);
            try
            {
                dbConn.Open();
                SqlDataReader dbReader = cmdSelect.ExecuteReader();
                while (dbReader.Read())
                {
                    Supplier supplier = new Supplier();
                    supplier.SupplierId = Convert.ToInt32(dbReader["SupplierID"]);
                    supplier.SupName = Convert.ToString(dbReader["SupName"]);
                    suppliers.Add(supplier);
                    /*
                    //string[] row1 = new string[] { id.ToString(), name };
                    int rowid = supplierDataGridView.Rows.Add(id.ToString(), name);

                    if (rowid % 2 == 1)
                    {
                        // set background color for specific rows
                        supplierDataGridView.Rows[rowid].DefaultCellStyle.BackColor = Color.LightBlue;
                    }
                    */
                }
                //OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql, connection);
                //DataSet ds = new DataSet();
                // supplierDataGridView.DataSource = reader;



                //supplierDataGridView.DataMember = "Authors_table";
                //supplierDataGridView.BindingContext();
                //supplierDataGridView.EditMode = DataGridViewEditMode.EditOnEnter;
            }
            catch (SqlException ex)
            {
                //MessageBox.Show(ex.Message, ex.GetType().ToString());
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
            return suppliers;
        }


        //Method to get the supplier from the supplier table
        public static Supplier GetSupplier(int supplierId)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();

            string selectStatement = "SELECT SupplierId, SupName from Suppliers s " +
                                     "WHERE SupplierId = @SupplierId";

            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@SupplierId", supplierId);
            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);

                if (reader.Read())
                {
                    Supplier supplier = new Supplier();
                    supplier.SupplierId = Convert.ToInt32(reader["SupplierId"]);
                    supplier.SupName = reader["SupName"].ToString();
                    return supplier;
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

        //Method to add the supplier to the supplier table
        public static void AddSupplier(Supplier supplier)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string insertStatement = "INSERT Suppliers (SupplierId, SupName) VALUES (@SupplierId, @SupName)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue("@SupplierId", supplier.SupplierId);
            insertCommand.Parameters.AddWithValue("@SupName",supplier.SupName);
            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                //string selectStatement = "SELECT IDENT_CURRENT('Suppliers') from Suppliers";
                //SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
                //int supplierId = Convert.ToInt32(selectCommand.ExecuteScalar());
                //return supplierId;
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

        //Method to update the supplier by passing old and new values of supplier details
        public static bool UpdateSupplier(Supplier oldSupplier, Supplier newSupplier)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string updateStatement = "UPDATE Suppliers SET SupplierId = @NewSupplierId, SupName = @NewSupName " +
                                     "WHERE SupplierId = @OldSupplierId AND SupName = @OldSupName";
            SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue("@OldSupplierId", oldSupplier.SupplierId);
            updateCommand.Parameters.AddWithValue("@OldSupName" , oldSupplier.SupName);
            updateCommand.Parameters.AddWithValue("@NewSupplierId", newSupplier.SupplierId);
            updateCommand.Parameters.AddWithValue("@NewSupName", newSupplier.SupName);
            try
            {

                connection.Open();
                int count = updateCommand.ExecuteNonQuery(); //get the count of updated fields
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

        //Method to delete the supplier from supplier table by passing all values of supplier details
        public static bool DeleteSupplier(Supplier supplier)
        {
            ProductSupplierDB.DeleteProductSuppliersBySupplier(supplier.SupplierId); // Delete links first to satisfy constraints
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string deleteStatement = "DELETE FROM Suppliers " +
                                     "WHERE SupplierId = @SupplierId AND SupName = @SupName";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue("@SupplierId", supplier.SupplierId);
            deleteCommand.Parameters.AddWithValue("@SupName", supplier.SupName);
            
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

        // get all suppliers from Supplier database
        public static List<Supplier> GetAllSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>();
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement =
                            "SELECT SupplierId, SupName " +
                            "FROM Suppliers " +
                            "ORDER BY SupplierId"; 
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            try
            {
                connection.Open();
                SqlDataReader dbReader = selectCommand.ExecuteReader();
                while (dbReader.Read())
                {
                    Supplier supplier = new Supplier();
                    supplier.SupplierId = Convert.ToInt32(dbReader["SupplierId"]);
                    supplier.SupName = Convert.ToString(dbReader["SupName"]);
                    suppliers.Add(supplier);
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
            return suppliers;
        }

        // Sunny Xie added.
        // show the products the supplier offer
        public static List<Product> GetProductsBySupplierId(int supplierID)
        {
            List<Product> products = new List<Product>();
            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string qrySelect = " select pr.ProductId, ProdName from Products_Suppliers ps "
            + "inner join Products pr on ps.ProductId = pr.ProductId where SupplierId =@supplierID "
                                   + "ORDER BY ps.ProductId";
            SqlCommand cmdSelect =
                new SqlCommand(qrySelect, dbConn);
            cmdSelect.Parameters.AddWithValue("@supplierID", supplierID);
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
                    /*
                    //string[] row1 = new string[] { id.ToString(), name };
                    int rowid = supplierDataGridView.Rows.Add(id.ToString(), name);

                    if (rowid % 2 == 1)
                    {
                        // set background color for specific rows
                        supplierDataGridView.Rows[rowid].DefaultCellStyle.BackColor = Color.LightBlue;
                    }
                    */
                }

            }
            catch (SqlException ex)
            {
                //MessageBox.Show(ex.Message, ex.GetType().ToString());
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
            return products;
        }

        // update the supplier 's product list. 
        public static bool UpdateSupplierProductList(int supplierId, List<int> newProducts)
        {
            List<Product> oldList = GetProductsBySupplierId(supplierId);
            List<Int32> oldProducts = new List<Int32>();
            foreach (Product pro in oldList)
            {
                oldProducts.Add(pro.ProductId);
            }

            SqlConnection dbConn = TravelExpertsDB.GetConnection();
            string qrySelect = " Insert into Products_Suppliers Values(@prid, @sid)";
            string qryDelete = "Delete from Products_Suppliers where ProductId = @productid and SupplierId = @supplierid ";
            foreach (int proId in newProducts)
            {
                bool ContainsInOldList = false;
                foreach (int oldProId in oldProducts)
                {
                    if (proId == oldProId)
                    {
                        ContainsInOldList = true;
                        break;
                    }
                }

                if (!ContainsInOldList)
                {

                    SqlCommand cmdSelect =
                        new SqlCommand(qrySelect, dbConn);
                    cmdSelect.Parameters.AddWithValue("@prid", proId);
                    cmdSelect.Parameters.AddWithValue("@sid", supplierId);
                    try
                    {
                        dbConn.Open();
                        cmdSelect.ExecuteNonQuery();

                    }
                    catch (SqlException ex)
                    {
                        //MessageBox.Show(ex.Message, ex.GetType().ToString());
                        throw ex;
                    }
                    finally
                    {
                        dbConn.Close();
                    }
                }
            }

            // delete non exists Products
            foreach (int proId in oldProducts)
            {
                bool ContainsInNewList = false;
                foreach (int newProId in newProducts)
                {
                    if (proId == newProId)
                    {
                        ContainsInNewList = true;
                        break;
                    }
                }

                if (!ContainsInNewList)
                {

                    SqlCommand cmdSelect =
                        new SqlCommand(qryDelete, dbConn);
                    cmdSelect.Parameters.AddWithValue("@productid", proId);
                    cmdSelect.Parameters.AddWithValue("@supplierid", supplierId);
                    try
                    {
                        dbConn.Open();
                        cmdSelect.ExecuteNonQuery();

                    }
                    catch (SqlException ex)
                    {
                        //MessageBox.Show(ex.Message, ex.GetType().ToString());
                        throw ex;
                    }
                    finally
                    {
                        dbConn.Close();
                    }
                }
            }

            return true;
        }
    }
}
