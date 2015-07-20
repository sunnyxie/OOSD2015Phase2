/*
 * Author: Geetha, Linden, Sunny
 * Date: July 05, 2015
 * Description: Database connection object
 */
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class TravelExpertsDB
{
	// Global DB Connection Function
    public static SqlConnection GetConnection()
    {
        string connectionString =
            "Data Source=localhost\\SqlExpress;Initial Catalog=TravelExperts;" +
            "Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        return connection;
    }
}
