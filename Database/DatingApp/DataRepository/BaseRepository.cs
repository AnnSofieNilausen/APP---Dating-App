using Npgsql;
using System;

using System.Collections.Generic;
using System.Data;


namespace DatingApp.DataRepository.BaseRepo
{
    public class BaseRepository
    {
        protected const string ConnectionString = "Host=localhost; Port=5432; Database=DatingApp; Username=postgres; Password=yourpassword;";

        //Database Connection to "get" data, can do other operations
        protected internal NpgsqlDataReader? GetData(NpgsqlConnection conn, NpgsqlCommand cmd)
        {

            conn.Open();
            return cmd.ExecuteReader();
        }



        //Database Connection to "insert" data, can do other operations
        protected internal bool InsertData(NpgsqlConnection conn, NpgsqlCommand cmd)
        {
            conn.Open();
            cmd.ExecuteNonQuery();
            return true;
        }


        //Database Connection to "Update" data, can do other operations
        protected internal bool UpdateData(NpgsqlConnection conn, NpgsqlCommand cmd)
        {
            conn.Open();
            cmd.ExecuteNonQuery();
            return true;
        }


        //Database Connection to "Delete" data, can do other operations
        protected internal bool DeleteData(NpgsqlConnection conn, NpgsqlCommand cmd)
        {
            conn.Open();
            cmd.ExecuteNonQuery();
            return true;
        }


        //Database Connection to "dynamically" get data, its just a way to infer parameters and return a reader
        public IEnumerable<IDataRecord> GetDataDyn(string query, Dictionary<string, object> parameters)
        {

            using var conn = new NpgsqlConnection(ConnectionString);
            {
                conn.Close();
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


        //Database Connection to "execute" any SQL function not needing a reader but just to be executed with only a count as return
        public int ExecuteNonQuery(string query, Dictionary<string, object> parameters)
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
    
  

