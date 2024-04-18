using System;
using APApiDbS2024InClass.Model;
using Npgsql;
using NpgsqlTypes;

namespace APApiDbS2024InClass.DataRepository
{
    public class Repository : BaseRepository
    {
        //Get a list of students
        public List<Profile> GetProfiles()
        {
            //creating empty list to fill it from database
            var profiles = new List<Profile>();

            //create a new connection for database
            var dbConn = new NpgsqlConnection(ConnectionString);

            //creating an SQL command
            var cmd = dbConn.CreateCommand();
            cmd.CommandText = "select * from student";

            //call the base method to get data
            var data = GetData(dbConn, cmd);

            if (data != null)
            {
                while (data.Read()) //every time loop runs it reads next like from fetched rows
                {
                    Profile s = new Profile(Convert.ToInt32(data["id"]))
                    {
                        FName = data["FName"].ToString(),
                        LName = data["LName"].ToString(),
                        DOB = Convert.ToDateTime(data["dob"]),
                        Email = data["email"].ToString(),
                        Gender = data["Gender"].ToString(),
                        AoL = data["AoL"].ToString(),
                        Username = data["Username"].ToString(),
                        Sexual_Orientation = data["Sexual_Orientation"].ToString(),
                        Bio = data["Bio"].ToString(),
                        Searching_For = data["Searching_For"].ToString(),
                        Interests = data["Interests"].ToString(),
                        Occupation = data["Interests"].ToString(),
                        Pictures = data["Pictures"].ToString(),
                        Likes = data["Likes"].ToString(),
                        Matches = data["Matches"].ToString()



                    };

                    profiles.Add(s);

                }

                return profiles;
            }

            return null;
        }

        //Get a single student using Id
        public Profile GetStudentById(int id)
        {
            //creating empty list to fill it from database
            var students = new List<Profile>();

            //create a new connection for database
            var dbConn = new NpgsqlConnection(ConnectionString);

            //creating an SQL command
            var cmd = dbConn.CreateCommand();
            cmd.CommandText = $"select * from student where id = {id}";

            //call the base method to get data
            var data = GetData(dbConn, cmd);

            if (data != null)
            {
                if (data.Read()) //if there is any data for given id
                {
                    Profile s = new Profile(Convert.ToInt32(data["id"]))
                    {
                        FName = data["firstname"].ToString(),
                        LName = data["lastname"].ToString(),
                        DOB = Convert.ToDateTime(data["dob"]),
                        Email = data["email"].ToString(),
                        Gender = data["phone"].ToString()
                    };

                    return s;

                }

                return null;
            }

            return null;
        }

        //add a new student
        public bool InsertStudent(Profile s)
        {
            var dbConn = new NpgsqlConnection(ConnectionString);
            var cmd = dbConn.CreateCommand();
            cmd.CommandText = @"
insert into student
(firstname,lastname, studyprogramid, dob, email, phone)
values
(@firstname,@lastname, @studyprogramid, @dob, @email, @phone)
";

            //adding parameters in a better way
            cmd.Parameters.AddWithValue("@firstname", NpgsqlDbType.Text, s.FName);
            cmd.Parameters.AddWithValue("@lastname", NpgsqlDbType.Text, s.LName);
            cmd.Parameters.AddWithValue("@dob", NpgsqlDbType.Date, s.DOB);
            cmd.Parameters.AddWithValue("@email", NpgsqlDbType.Text, s.Email);
            cmd.Parameters.AddWithValue("@phone", NpgsqlDbType.Text, s.Gender);

            //will return true if all goes well
            bool result = InsertData(dbConn, cmd);

            return result;
        }

        public bool UpdateProfile(Profile s)
        {
            var dbConn = new NpgsqlConnection(ConnectionString);
            var cmd = dbConn.CreateCommand();
            cmd.CommandText = @"
update student set
    firstname=@firstname,
    lastname=@lastname,
    studyprogramid=@studyprogramid,
    dob=@dob,
    email=@email,
    phone=@phone
where
id = @id";

            cmd.Parameters.AddWithValue("@firstname", NpgsqlDbType.Text, s.FName);
            cmd.Parameters.AddWithValue("@lastname", NpgsqlDbType.Text, s.LName);
            cmd.Parameters.AddWithValue("@dob", NpgsqlDbType.Date, s.DOB);
            cmd.Parameters.AddWithValue("@email", NpgsqlDbType.Text, s.Email);
            cmd.Parameters.AddWithValue("@phone", NpgsqlDbType.Text, s.Gender);
            cmd.Parameters.AddWithValue("@id", NpgsqlDbType.Integer, s.ID);

            bool result = UpdateData(dbConn, cmd);
            return result;
        }

        public bool DeleteStudent(int id)
        {
            var dbConn = new NpgsqlConnection(ConnectionString);
            var cmd = dbConn.CreateCommand();
            cmd.CommandText = @"
delete from student
where id = @id
";

            //adding parameters in a better way
            cmd.Parameters.AddWithValue("@id", NpgsqlDbType.Integer, id);

            //will return true if all goes well
            bool result = DeleteData(dbConn, cmd);

            return result;
        }

    }
}

