/*
 * Author: Geetha, Linden, Sunny
 * Date: July 05, 2015
 * Description: File to interact with database to add, update, get and delete the supplier records
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
    }
}
