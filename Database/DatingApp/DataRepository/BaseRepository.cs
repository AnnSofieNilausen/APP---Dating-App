using Npgsql;
using System;
namespace DatingApp.DataRepository
    {
        public class BaseRepository
        {
            protected const string ConnectionString = "Host=localhost; Port=5432; Database=DatingApp; Username=postgres; Password=yourPassword;";

            protected NpgsqlDataReader? GetData(NpgsqlConnection conn, NpgsqlCommand cmd)
            {
                conn.Open();
                return cmd.ExecuteReader();
            }

            protected bool InsertData(NpgsqlConnection conn, NpgsqlCommand cmd)
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }

            protected bool UpdateData(NpgsqlConnection conn, NpgsqlCommand cmd)
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }

            protected bool DeleteData(NpgsqlConnection conn, NpgsqlCommand cmd)
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
        }
    }

