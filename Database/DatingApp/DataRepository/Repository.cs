using System;
using DatingApp.Model;
using Npgsql;
using NpgsqlTypes;

namespace DatingApp.DataRepository
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
            cmd.CommandText = "select * from profile";

            //call the base method to get data
            var data = GetData(dbConn, cmd);

            if (data != null)
            {
                while (data.Read()) //every time loop runs it reads next like from fetched rows
                {
                    Profile s = new Profile(Convert.ToInt32(data["id"]))
                    {

                        FName = data["Fname"].ToString(),
                        LName = data["Lname"].ToString(),
                        DOB = Convert.ToDateTime(data["DoB"]),
                        gender = data["Gender"].ToString(),
                        AoL = data["AoL"].ToString(),
                        username = data["Username"].ToString()
                        sexualOrientation = data["Sexual_Orientation"].ToString(),
                        bio = data["Bio"].ToString(),
                        searchingFor = data["Searching_For"].ToString(),
                        interests = data["Interests"].ToString(),
                        occupation = data["Occupation"].ToString(),
                        pictures = data["Pictures"].ToString(),
                        likes = data["Likes"].ToString(),
                        matches = data["Matches"].ToString(),
                        instagram = data["Instagram"].ToString(),
                        snapchat = data["Snapchat"].ToString()


                    };

                    students.Add(s);

                }

                return students;
            }

            return null;
        }

        //Get a single student using Id
        public Profile GetProfileById(int id)
        {
            //creating empty list to fill it from database
            var profile = new List<Profile>();

            //create a new connection for database
            var dbConn = new NpgsqlConnection(ConnectionString);

            //creating an SQL command
            var cmd = dbConn.CreateCommand();
            cmd.CommandText = $"select * from profile where Pid = {id}";

            //call the base method to get data
            var data = GetData(dbConn, cmd);

            if (data != null)
            {
                if (data.Read()) //if there is any data for given id
                {
                    Profile s = new Profile(Convert.ToInt32(data["Pid"]))
                    {
                        FName = data["Fname"].ToInt()
                        FName = data["Fname"].ToString(),
                        LName = data["Lname"].ToString(),
                        DOB = Convert.ToDateTime(data["DoB"]),
                        gender = data["Gender"].ToString(),
                        AoL = data["AoL"].ToString(),
                        username = data["Username"].ToString()
                        sexualOrientation = data["Sexual_Orientation"].ToString(),
                        bio = data["Bio"].ToString(),
                        searchingFor = data["Searching_For"].ToString(),
                        interests = data["Interests"].ToString(),
                        occupation = data["Occupation"].ToString(),
                        pictures = data["Pictures"].ToString(),
                        likes = data["Likes"].ToString(),
                        matches = data["Matches"].ToString(),
                        instagram = data["Instagram"].ToString(),
                        snapchat = data["Snapchat"].ToString()
                    };

                    return s;

                }

                return null;
            }

            return null;
        }

        //add a new student
        public bool InsertProfile(Profile p)
        {
            var dbConn = new NpgsqlConnection(ConnectionString);
            var cmd = dbConn.CreateCommand();
            cmd.CommandText = @"
insert into Profile
(Fname,Lname, DoB, Gender, AoL, Username, Sexual_Orientation, Bio, Searching_For, Interests, Occupation, Pictures, Likes, Matches, Instagram, Snapchat)
values
(@firstname,@lastname, @dob, @Gender, @AoL, @Username, @Sexual_Orientation, @Bio, @Searching_For, @Interests, @Occupation, @Pictures, @Likes, @Matches, @Instagram, @Snapchat)
";

            //adding parameters in a better way
            cmd.Parameters.AddWithValue("@Pid", NpgsqlDbType.Integer, p.ID);
            cmd.Parameters.AddWithValue("@Fname", NpgsqlDbType.Text, p.FirstName);
            cmd.Parameters.AddWithValue("@Lname", NpgsqlDbType.Text, p.LastName);
            cmd.Parameters.AddWithValue("@DoB", NpgsqlDbType.Date, p.DOB);
            cmd.Parameters.AddWithValue("@Gender", NpgsqlDbType.Text, p.gender);
            cmd.Parameters.AddWithValue("@AoL", NpgsqlDbType.Text, p.AoL);
            cmd.Parameters.AddWithValue("@Username", NpgsqlDbType.Text, p.username);
            cmd.Parameters.AddWithValue("@Sexual_Orientation", NpgsqlDbType.Text, p.sexualOrientation);
            cmd.Parameters.AddWithValue("@Bio", NpgsqlDbType.Text, p.bio);
            cmd.Parameters.AddWithValue("@Searching_For", NpgsqlDbType.Text, p.searchingFor);
            cmd.Parameters.AddWithValue("@Interests", NpgsqlDbType.Text, p.interests);
            cmd.Parameters.AddWithValue("@Occupation", NpgsqlDbType.Text, p.occupation);
            cmd.Parameters.AddWithValue("@Pictures", NpgsqlDbType.Bytea, p.pictures);
            cmd.Parameters.AddWithValue("@Likes", NpgsqlDbType.Bigint, p.likes);
            cmd.Parameters.AddWithValue("@Matches", NpgsqlDbType.Bigint, p.matches);
            cmd.Parameters.AddWithValue("@Instagram", NpgsqlDbType.Text, p.instagram);
            cmd.Parameters.AddWithValue("@Snapchat", NpgsqlDbType.Text, p.snapchat);
            

            //will return true if all goes well
            bool result = InsertData(dbConn, cmd);

            return result;
        }

        public bool UpdateProfile(Profile p)
        {
            var dbConn = new NpgsqlConnection(ConnectionString);
            var cmd = dbConn.CreateCommand();
            cmd.CommandText = @"
update profile set
    Fname=@Fname,
    Lname=@Lname,
    DoB=@DoB,
    Gender=@Gender,
    Username=@Username
where
id = @id";

            cmd.Parameters.AddWithValue("@Pid", NpgsqlDbType.Integer, p.ID);
            cmd.Parameters.AddWithValue("@Fname", NpgsqlDbType.Text, p.FirstName);
            cmd.Parameters.AddWithValue("@Lname", NpgsqlDbType.Text, p.LastName);
            cmd.Parameters.AddWithValue("@DoB", NpgsqlDbType.Date, p.DOB);
            cmd.Parameters.AddWithValue("@Gender", NpgsqlDbType.Text, p.gender);
            cmd.Parameters.AddWithValue("@AoL", NpgsqlDbType.Text, p.AoL);
            cmd.Parameters.AddWithValue("@Username", NpgsqlDbType.Text, p.username);
            cmd.Parameters.AddWithValue("@Sexual_Orientation", NpgsqlDbType.Text, p.sexualOrientation);
            cmd.Parameters.AddWithValue("@Bio", NpgsqlDbType.Text, p.bio);
            cmd.Parameters.AddWithValue("@Searching_For", NpgsqlDbType.Text, p.searchingFor);
            cmd.Parameters.AddWithValue("@Interests", NpgsqlDbType.Text, p.interests);
            cmd.Parameters.AddWithValue("@Occupation", NpgsqlDbType.Text, p.occupation);
            cmd.Parameters.AddWithValue("@Pictures", NpgsqlDbType.Bytea, p.pictures);
            cmd.Parameters.AddWithValue("@Likes", NpgsqlDbType.Bigint, p.likes);
            cmd.Parameters.AddWithValue("@Matches", NpgsqlDbType.Bigint, p.matches);
            cmd.Parameters.AddWithValue("@Instagram", NpgsqlDbType.Text, p.instagram);
            cmd.Parameters.AddWithValue("@Snapchat", NpgsqlDbType.Text, p.snapchat);

            { "@Fname", fname},
                { "@Lname", lname},
                { "@DoB", dob},
                { "@Gender", gender},
                { "@AoL", AoL},
                { "@Username", username},
                { "@SexualOrientation", sexualOrientation},
                { "@Bio", bio},
                { "@SearchingFor", searchingFor},
                { "@Interests", interests},
                { "@Occupation", occupation},
                { "@Pictures", pictures},
                { "@Instagram", instagram ?? ""},
                { "@Snapchat", snapchat ?? ""}
            bool result = UpdateData(dbConn, cmd);
            return result;
        }

        public bool DeleteProfile(int id)
        {
            var dbConn = new NpgsqlConnection(ConnectionString);
            var cmd = dbConn.CreateCommand();
            cmd.CommandText = @"
delete from Profile
where Pid = @id
";

            //adding parameters in a better way
            cmd.Parameters.AddWithValue("@id", NpgsqlDbType.Integer, id);

            //will return true if all goes well
            bool result = DeleteData(dbConn, cmd);

            return result;
        }

    }
}

