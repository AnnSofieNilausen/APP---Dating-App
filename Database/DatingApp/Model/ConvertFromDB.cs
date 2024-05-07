using Npgsql;
using NpgsqlTypes;

namespace DatingApp.Model.Conversion
{
    public class ConvertFromDB
    {
        //Converts From DB to Int and checks if null
        public int convertToInt(object x)
        {
            if (x == DBNull.Value) return 0;
            else
            {
                return Convert.ToInt32(x);
            }
        }

        //Converts From DB to String and checks if null
        public String? convertToString(object x)
        {
            if (x == DBNull.Value) return null;
            else
            {
                return x.ToString();
            }
            
        }

        //Converts From DB to DateTime and checks if null
        public DateTime? convertToDateTime(object x)
        {
            if (x == DBNull.Value) return null;
            else
            {
                return Convert.ToDateTime(x);
            }

        }
    }
}
