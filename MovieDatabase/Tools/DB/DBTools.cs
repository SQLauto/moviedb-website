using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.DB
{
    public static class DBTools
    {
        public static SqlConnection GetConnection(string connectionName)
        {
            var connection = new SqlConnection();
            var connectionString = ConfigurationManager.ConnectionStrings[connectionName];
            if (connectionString != null)
            {
                connection.ConnectionString = connectionString.ConnectionString;
                connection.Open();

                return connection;
            }

            return null;
        }
    }
}
