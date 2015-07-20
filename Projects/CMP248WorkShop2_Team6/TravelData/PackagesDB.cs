/*
 * Author : Geetha
 * Date: July 07, 2015
 * Usage: File contains the databaseadd, modify, delete function for packages
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
    public static class PackagesDB
    {
        //Method to retreive package details for the particular packageId
        public static Packages GetPackages(int packageId)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();

            string selectStatement = "SELECT PackageId, PkgName, PkgStartDate, PkgEndDate, PkgDesc, PkgBasePrice, PkgAgencyCommission " +
                                     "FROM Packages " +
                                     "WHERE PackageId = @PackageId";

            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@PackageId", packageId);
            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);

                if (reader.Read())
                {
                    Packages packages = new Packages();
                    packages.PackageId = Convert.ToInt32(reader["PackageId"]);
                    packages.PkgName = reader["PkgName"].ToString();
                    packages.PkgStartDate = (DateTime)reader["PkgStartDate"];
                    packages.PkgEndDate = (DateTime)reader["PkgEndDate"];
                    packages.PkgDesc = reader["PkgDesc"].ToString();
                    packages.PkgBasePrice = Convert.ToDecimal(reader["PkgBasePrice"]);
                    packages.PkgAgencyCommission = Convert.ToDecimal(reader["PkgAgencyCommission"]);
                    return packages;
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

        //Method to add new package details to database and returns the generated packageId
        public static int AddPackage(Packages packages)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string insertStatement =
                "INSERT Packages " +
                "(PkgName, PkgStartDate, PkgEndDate, PkgDesc, PkgBasePrice, PkgAgencyCommission) " +
                "VALUES (@PkgName, @PkgStartDate, @PkgEndDate, @PkgDesc,@PkgBasePrice,@PkgAgencyCommission)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue("@PkgName", packages.PkgName);
            insertCommand.Parameters.AddWithValue("@PkgStartDate", packages.PkgStartDate);
            insertCommand.Parameters.AddWithValue("@PkgEndDate", packages.PkgEndDate);
            insertCommand.Parameters.AddWithValue("@PkgDesc", packages.PkgDesc);
            insertCommand.Parameters.AddWithValue("@PkgBasePrice", packages.PkgBasePrice);
            insertCommand.Parameters.AddWithValue("@PkgAgencyCommission", packages.PkgAgencyCommission);
            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                string selectStatement =
                    "SELECT IDENT_CURRENT('Packages') FROM Packages"; // After adding package, get current ID
                SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
                int packageId = Convert.ToInt32(selectCommand.ExecuteScalar());
                return packageId;
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
        //Method to update package by giving newpackage and oldpackage details
        public static bool UpdatePackage(Packages oldPackages, Packages newPackages)            
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string updateStatement =
                "UPDATE Packages SET " +    
                "PkgName = @NewPkgName, " +
                "PkgStartDate = @NewPkgStartDate, " +
                "PkgEndDate = @NewPkgEndDate, " +
                "PkgDesc = @NewPkgDesc, " +
                "PkgBasePrice = @NewPkgBasePrice, " +
                "PkgAgencyCommission = @NewPkgAgencyCommission " +
                "WHERE PkgName = @OldPkgName " +
                "AND PkgStartDate = @OldPkgStartDate " +
                "AND PkgEndDate = @OldPkgEndDate " +
                "AND PkgDesc = @OldPkgDesc " +
                "AND PkgBasePrice = @OldPkgBasePrice " +
                "AND PkgAgencyCommission = @OldPkgAgencyCommission ";
            SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
                
            updateCommand.Parameters.AddWithValue("@NewPkgName", newPackages.PkgName);
            updateCommand.Parameters.AddWithValue("@NewPkgStartDate", newPackages.PkgStartDate);
            updateCommand.Parameters.AddWithValue("@NewPkgEndDate", newPackages.PkgEndDate);
            updateCommand.Parameters.AddWithValue("@NewPkgDesc", newPackages.PkgDesc);
            updateCommand.Parameters.AddWithValue("@NewPkgBasePrice", newPackages.PkgBasePrice);
            updateCommand.Parameters.AddWithValue("@NewPkgAgencyCommission", newPackages.PkgAgencyCommission);
            updateCommand.Parameters.AddWithValue("@OldPkgName", oldPackages.PkgName);
            updateCommand.Parameters.AddWithValue("@OldPkgStartDate", oldPackages.PkgStartDate);
            updateCommand.Parameters.AddWithValue("@OldPkgEndDate", oldPackages.PkgEndDate);
            updateCommand.Parameters.AddWithValue("@OldPkgDesc", oldPackages.PkgDesc);
            updateCommand.Parameters.AddWithValue("@OldPkgBasePrice", oldPackages.PkgBasePrice);
            updateCommand.Parameters.AddWithValue("@OldPkgAgencyCommission", oldPackages.PkgAgencyCommission);
                     
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

        //Method to delete packages by all package details
        public static bool DeletePackage(Packages packages)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string deleteStatement =
                            "DELETE FROM Packages " +
                            "WHERE PkgName = @PkgName " +
                            "AND PkgStartDate = @PkgStartDate " +
                            "AND PkgEndDate = @PkgEndDate " +
                            "AND PkgDesc = @PkgDesc " +
                            "AND PkgBasePrice = @PkgBasePrice " +
                            "AND PkgAgencyCommission = @PkgAgencyCommission ";

            SqlCommand deleteCommand =
                new SqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue("@PkgName", packages.PkgName);
            deleteCommand.Parameters.AddWithValue("@PkgStartDate", packages.PkgStartDate);
            deleteCommand.Parameters.AddWithValue("@PkgEndDate", packages.PkgEndDate);
            deleteCommand.Parameters.AddWithValue("@PkgDesc", packages.PkgDesc);
            deleteCommand.Parameters.AddWithValue("@PkgBasePrice", packages.PkgBasePrice);
            deleteCommand.Parameters.AddWithValue("@PkgAgencyCommission", packages.PkgAgencyCommission);
                
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
    }
}
