using Npgsql;
using System;

using System.Collections.Generic;
using System.Data;


namespace DatingApp.DataRepository.BaseRepo
{
    public class BaseRepository
    {
        protected const string ConnectionString = "Host=localhost; Port=5432; Database=DatingApp2.0; Username=postgres; Password=yourpassword;";

        protected internal NpgsqlDataReader? GetData(NpgsqlConnection conn, NpgsqlCommand cmd)
        {

            conn.Open();
            return cmd.ExecuteReader();
        }

         
        protected internal bool InsertData(NpgsqlConnection conn, NpgsqlCommand cmd)
        {
            conn.Open();
            cmd.ExecuteNonQuery();
            return true;
        }

        protected internal bool UpdateData(NpgsqlConnection conn, NpgsqlCommand cmd)
        {
            conn.Open();
            cmd.ExecuteNonQuery();
            return true;
        }

        protected internal bool DeleteData(NpgsqlConnection conn, NpgsqlCommand cmd)
        {
            conn.Open();
            cmd.ExecuteNonQuery();
            return true;
        }

        protected IEnumerable<IDataRecord> GetDataDyn(string query, Dictionary<string, object> parameters)
        {
            using var conn = new NpgsqlConnection(ConnectionString);
            {
                using var cmd = new NpgsqlCommand(query, conn);
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
        protected internal int ExecuteNonQuery(string query, Dictionary<string, object> parameters)
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
    
  

