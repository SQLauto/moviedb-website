using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.DB
{
    public static class DBExtensions
    {
        public static SqlDataReader ExecuteQuery(this SqlConnection connection, string query)
        {
            using (var command = new SqlCommand(query, connection))
            {
                return command.ExecuteReader();
            }
        }

        public static SqlDataReader ExecuteStoredProcedure(this SqlConnection connection, string procedureName, List<SqlParameter> parameters = null)
        {
            using (var command = new SqlCommand(procedureName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters.ToArray());
                }
                return command.ExecuteReader();
            }
        }

        public static DataSet ExecuteStoredProcedureDataSet(this SqlConnection connection, string procedureName, List<SqlParameter> parameters = null)
        {
            using (var command = new SqlCommand(procedureName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters.ToArray());
                }

                using (var dataAdapter = new SqlDataAdapter(command))
                {
                    var dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);

                    return dataSet;
                }
            }
        }

        public static int GetInt32(this SqlDataReader reader, string columnName)
        {
            return reader.GetInt32(reader.GetOrdinal(columnName));
        }

        public static int GetInt32(this DataRow row, string columnName)
        {
            return row.Field<int>(columnName);
        }

        public static string GetString(this SqlDataReader reader, string columnName)
        {
            return reader.GetString(reader.GetOrdinal(columnName));
        }

        public static string GetString(this DataRow row, string columnName)
        {
            return row.Field<string>(columnName);
        }
    }
}
