using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace DatingApp.DataRepository
{
    public class BaseRepository
    {
        // This string connects to the database.
        internal const string ConnectionString = $"Host=localhost; Port=5432; Database=DatingApp; Username=postgres; Password=yourPassword;";
        NpgsqlConnectionStringBuilder

        /// <summary>
        /// Executes a SELECT SQL command with parameters and returns the data as a stream of IDataRecord.
        /// </summary>
        /// <param name="query">The parameterized SQL query string.</param>
        /// <param name="parameters">The parameters to use in the query.</param>
        /// <returns>An enumerable of IDataRecord, allowing for reading results one row at a time.</returns>
        protected IEnumerable<IDataRecord> GetData(string query, Dictionary<string, object> parameters)
        {
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    // Add parameters to the command.
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Executes an INSERT, UPDATE, or DELETE SQL command with parameters.
        /// </summary>
        /// <param name="query">The parameterized SQL command string.</param>
        /// <param name="parameters">The parameters to use in the command.</param>
        /// <returns>The number of rows affected by the command.</returns>
        protected int ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    // Add parameters to the command.
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }

                    conn.Open();

                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
