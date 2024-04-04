using Npgsql;

namespace APApiDbS2024InClass.DataRepository
{
    public class BaseRepository
    {
        protected const string ConnectionString = "Host=localhost:5432;Username=postgres;Password=;Database=AppProgDb";

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

