/*
 * Author: Geetha and Sunny
 * Date: July 15, 2015
 * Usage: The data access class to retrieve or Update Customer details
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Data access class for Customer table
/// </summary>
[DataObject(true)]
public static class CustomerDB
{
    //Get the list of Customer Name and CustomerId to bind with combo box
    [DataObjectMethod(DataObjectMethodType.Select)]
	public static List<Customer> GetCustomers()
	{
		List<Customer> customers = new List<Customer>();
        SqlConnection connection = TravelExpertsDB.GetConnection();
        string selectStatement = "SELECT CustomerId, CustFirstName, CustLastName " + 
                                 "FROM Customers ORDER BY CustFirstName";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);

        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            while (reader.Read())
            {
                Customer customer = new Customer();
                customer.CustomerId = (int)reader["CustomerId"];
                customer.CustFirstName = reader["CustFirstName"].ToString();
                customer.CustLastName = reader["CustLastName"].ToString();
                customer.CustName = customer.CustFirstName + " " + customer.CustLastName;
                customers.Add(customer);
            }
            reader.Close();

        }
        catch(SqlException ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
        return customers;
	}

    //Method to retrieve customer details by customerId.
    [DataObjectMethod(DataObjectMethodType.Select)]
    public static Customer GetCustomerById(int customerId)
    {
        SqlConnection connection = TravelExpertsDB.GetConnection();
        string selectStatement = "SELECT CustomerId, CustFirstName, CustLastName, CustAddress, " +
                                 "CustCity, CustProv, CustPostal, CustCountry, CustHomePhone, " +
                                 "CustBusPhone, CustEmail FROM Customers " +
                                 "WHERE CustomerId = @CustomerId";
        
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.Parameters.AddWithValue("@CustomerId", customerId);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                Customer customer = new Customer();
                customer.CustomerId = (int)reader["CustomerId"];
                customer.CustFirstName = reader["CustFirstName"].ToString();
                customer.CustLastName = reader["CustLastName"].ToString();
                customer.CustAddress = reader["CustAddress"].ToString();
                customer.CustCity = reader["CustCity"].ToString();
                customer.CustProv = reader["CustProv"].ToString();
                customer.CustPostal = reader["CustPostal"].ToString();
                customer.CustCountry = reader["CustCountry"].ToString();
                customer.CustHomePhone = reader["CustHomePhone"].ToString();
                customer.CustBusPhone = reader["CustBusPhone"].ToString();
                customer.CustEmail = reader["CustEmail"].ToString();
                return customer;
            }
            else
            {
                return null;
            }
        }
        catch(SqlException ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
    }

    //Method to update customer details
    [DataObjectMethod(DataObjectMethodType.Update)]
    public static int UpdateCustomer(Customer original_Customer, Customer customer)
        
    {                               
        SqlConnection connection = TravelExpertsDB.GetConnection();
        string updateStatement =
            "UPDATE Customers SET " +
            "CustFirstName = @CustFirstName, " +
            "CustLastName = @CustLastName, " +
            "CustAddress = @CustAddress, " +
            "CustCity = @CustCity, " +
            "CustProv = @CustProv, " +
            "CustPostal = @CustPostal, " +
            "CustCountry = @CustCountry, " +
            "CustHomePhone = @CustHomePhone, " +
            "CustBusPhone = @CustBusPhone, " +
            "CustEmail = @CustEmail " +
            "WHERE CustomerId = @original_CustomerId " +
            "AND CustFirstName = @original_CustFirstName " +
            "AND CustLastName = @original_CustLastName " +
            "AND CustAddress = @original_CustAddress " +
            "AND CustCity = @original_CustCity " +
            "AND CustProv = @original_CustProv " +
            "AND CustPostal = @original_CustPostal " +
            "AND CustCountry = @original_CustCountry " +
            "AND CustHomePhone = @original_CustHomePhone " +
            "AND CustBusPhone = @original_CustBusPhone " +
            "AND CustEmail = @original_CustEmail";

        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);

        updateCommand.Parameters.AddWithValue("@CustFirstName", customer.CustFirstName);
        updateCommand.Parameters.AddWithValue("@CustLastName", customer.CustLastName);
        updateCommand.Parameters.AddWithValue("@CustAddress", customer.CustAddress);
        updateCommand.Parameters.AddWithValue("@CustCity", customer.CustCity);
        updateCommand.Parameters.AddWithValue("@CustProv", customer.CustProv);
        updateCommand.Parameters.AddWithValue("@CustPostal", customer.CustPostal);
        updateCommand.Parameters.AddWithValue("@CustCountry", customer.CustCountry);
        updateCommand.Parameters.AddWithValue("@CustHomePhone", customer.CustHomePhone);
        updateCommand.Parameters.AddWithValue("@CustBusPhone", customer.CustBusPhone);
        updateCommand.Parameters.AddWithValue("@CustEmail", customer.CustEmail);

        updateCommand.Parameters.AddWithValue("@original_CustomerId", original_Customer.CustomerId);
        updateCommand.Parameters.AddWithValue("@original_CustFirstName", original_Customer.CustFirstName);
        updateCommand.Parameters.AddWithValue("@original_CustLastName", original_Customer.CustLastName);
        updateCommand.Parameters.AddWithValue("@original_CustAddress", original_Customer.CustAddress);
        updateCommand.Parameters.AddWithValue("@original_CustCity", original_Customer.CustCity);
        updateCommand.Parameters.AddWithValue("@original_CustProv", original_Customer.CustProv);
        updateCommand.Parameters.AddWithValue("@original_CustPostal", original_Customer.CustPostal);
        updateCommand.Parameters.AddWithValue("@original_CustCountry", original_Customer.CustCountry);
        updateCommand.Parameters.AddWithValue("@original_CustHomePhone", original_Customer.CustHomePhone);
        updateCommand.Parameters.AddWithValue("@original_CustBusPhone", original_Customer.CustBusPhone);
        updateCommand.Parameters.AddWithValue("@original_CustEmail", original_Customer.CustEmail == null ? "" : original_Customer.CustEmail);
        try
        {
            connection.Open();
            int updateCount = updateCommand.ExecuteNonQuery();
            if (updateCount > 0)
                return updateCount;
            else
                return 0;
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

}