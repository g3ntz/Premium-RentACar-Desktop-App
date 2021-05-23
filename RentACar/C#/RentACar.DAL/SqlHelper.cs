using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace RentACar.DAL
{
    class SqlHelper
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["RentACarConnectionString"].ConnectionString;

        public static string ConnectionString
        {
            get
            {
                return connectionString != "" ? connectionString : ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            }
            set { connectionString = ConfigurationManager.ConnectionStrings[value].ConnectionString; }
        }

        public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
                return connection;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static SqlCommand Command(SqlConnection connection, string cmdText, CommandType commandType)
        {
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.CommandType = commandType;
            return command;
        }

        public static void AddParameter(SqlCommand command, string parameterName, object value)
        {
            SqlParameter parameter = command.CreateParameter();
            parameter.ParameterName = parameterName;
            if (value != null)
            {
                if (value is DateTime)
                {
                    if (DateTime.Parse(value.ToString()) <= DateTime.Parse("1/01/1900"))
                        value = null;
                }
            }

            parameter.Value = value ?? DBNull.Value;
            command.Parameters.Add(parameter);
        }

        public static void AddParameter(SqlCommand command, string parameterName, object value, ParameterDirection direction)
        {
            SqlParameter parameter = command.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.Direction = direction; 
            if (value != null)
            {
                if (value is DateTime)
                {
                    if (DateTime.Parse(value.ToString()) <= DateTime.Parse("1/01/1900"))
                        value = null;
                }
            }

            parameter.Value = value ?? DBNull.Value;
            command.Parameters.Add(parameter);
        }
    }
}
