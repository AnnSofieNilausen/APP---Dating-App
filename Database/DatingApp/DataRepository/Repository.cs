using System;
using DatingApp.Model;
using Npgsql;
using NpgsqlTypes;
using DatingApp.Model.P;
using DatingApp.Model.Conversion;

namespace DatingApp.DataRepository
{
    public class Repository : BaseRepository
    {
        public ConvertFromDB convertFromDB = new();
        //Get a list of Profiles
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
                    Profile p = new(convertFromDB.convertToInt(data["pid"]))
                    {

                        Fname = convertFromDB.convertToString(data["fname"]),
                        Lname = convertFromDB.convertToString(data["lname"]),
                        Dob = Convert.ToDateTime(data["dob"]),
                        Gender = convertFromDB.convertToString(data["gender"]),
                        Aol = convertFromDB.convertToString(data["aol"]),
                        Username = convertFromDB.convertToString(data["username"]),
                        Sexualorientation = convertFromDB.convertToString(data["sexual_orientation"]),
                        Bio = convertFromDB.convertToString(data["bio"]),
                        Searchingfor = convertFromDB.convertToString(data["searching_for"]),
                        Interests = convertFromDB.convertToString(data["interests"]),
                        Occupation = convertFromDB.convertToString(data["occupation"]),
                        Pictures = convertFromDB.convertToString(data["pictures"]),
                        Likes = convertFromDB.convertToInt(data["likes"]),
                        Matches = convertFromDB.convertToInt(data["matches"]),
                        Instagram = convertFromDB.convertToString(data["instagram"]),
                        Snapchat = convertFromDB.convertToString(data["instagram"])
                    };


                    profiles.Add(p);

                    profiles.Add(p);


                }

                return profiles;
            }

            return null;
        }

        //Get a single profile using Id but without sensitive information
        //Match = true, get match information incl. social media
        //Match = false, get profile with limited information
        public Profile GetSafeProfileById(int id, bool match)
        {
            //create a new connection for database
            var dbConn = new NpgsqlConnection(ConnectionString);

            //creating an SQL command
            var cmd = dbConn.CreateCommand();
            cmd.CommandText = $"select * from profile where pid = {id}";

            //call the base method to get data
            var data = GetData(dbConn, cmd);

            if (data != null)
            {
                if (data.Read()) //if there is any data for given id
                {
                    if (match)
                    {
                        Profile p = new(convertFromDB.convertToInt(data["pid"]))
                        {
                            Fname = convertFromDB.convertToString(data["fname"]),
                            Lname = convertFromDB.convertToString(data["lname"]),
                            Dob = Convert.ToDateTime(data["dob"]),
                            Gender = convertFromDB.convertToString(data["gender"]),
                            Aol = convertFromDB.convertToString(data["aol"]),                            
                            Bio = convertFromDB.convertToString(data["bio"]),                            
                            Interests = convertFromDB.convertToString(data["interests"]),
                            Occupation = convertFromDB.convertToString(data["occupation"]),
                            Pictures = convertFromDB.convertToString(data["pictures"]),                            
                            Instagram = convertFromDB.convertToString(data["instagram"]),
                            Snapchat = convertFromDB.convertToString(data["instagram"])
                        };
                        return p;
                    }
                    else
                    {
                        Profile p = new(convertFromDB.convertToInt(data["pid"]))
                        {

                            Fname = convertFromDB.convertToString(data["fname"]),
                            Lname = convertFromDB.convertToString(data["lname"]),
                            Dob = Convert.ToDateTime(data["dob"]),
                            Gender = convertFromDB.convertToString(data["gender"]),
                            Aol = convertFromDB.convertToString(data["aol"]),
                            Bio = convertFromDB.convertToString(data["bio"]),                            
                            Interests = convertFromDB.convertToString(data["interests"]),
                            Occupation = convertFromDB.convertToString(data["occupation"]),
                            Pictures = convertFromDB.convertToString(data["pictures"])
                            
                        };
                        return p;
                    }

                }

                return null;
            }

            return null;
        }
        //get matchfeed or matched profile(removed sensitive info)
        public Profile GetProfileById(int id)
        { 
            //create a new connection for database
            var dbConn = new NpgsqlConnection(ConnectionString);
            
            //creating an SQL command
            var cmd = dbConn.CreateCommand();
            cmd.CommandText = $"select * from profile where pid = {id}";

            //call the base method to get data
            var data = GetData(dbConn, cmd);

            if (data != null)
            {
                if (data.Read()) //if there is any data for given id
                {
                    Profile p = new(convertFromDB.convertToInt(data["pid"]))
                    {
                
                        Fname = convertFromDB.convertToString(data["fname"]),
                        Lname = convertFromDB.convertToString(data["lname"]),
                        Dob = Convert.ToDateTime(data["dob"]),
                        Gender = convertFromDB.convertToString(data["gender"]),
                        Aol = convertFromDB.convertToString(data["aol"]),
                        Username = convertFromDB.convertToString(data["username"]),
                        Sexualorientation = convertFromDB.convertToString(data["sexual_orientation"]),
                        Bio = convertFromDB.convertToString(data["bio"]),
                        Searchingfor = convertFromDB.convertToString(data["searching_for"]),
                        Interests = convertFromDB.convertToString(data["interests"]),
                        Occupation = convertFromDB.convertToString(data["occupation"]),
                        Pictures = convertFromDB.convertToString(data["pictures"]),
                        Likes = convertFromDB.convertToInt(data["likes"]),
                        Matches = convertFromDB.convertToInt(data["matches"]),
                        Instagram = convertFromDB.convertToString(data["instagram"]),
                        Snapchat = convertFromDB.convertToString(data["instagram"])
                    };

                    return p;

                }

                return null;
            }

            return null;
        }
        //add a new profile
        public bool InsertProfile(Profile p)
        {
            var dbConn = new NpgsqlConnection(ConnectionString);
            var cmd = dbConn.CreateCommand();
            cmd.CommandText = @"insert into profile (fname, lname, dob, gender, aol, username, sexual_orientation, bio, searching_for, interests, occupation, pictures, likes, matches, instagram, snapchat) values (@firstname,@lastname, @Dob, @Gender, @AoL, @Username, @Sexual_Orientation, @Bio, @Searching_For, @Interests, @Occupation, @Pictures, @Likes, @Matches, @Instagram, @Snapchat)
";

            //adding parameters in a better way
            cmd.Parameters.AddWithValue("@Fname", NpgsqlDbType.Text, p.Fname);
            cmd.Parameters.AddWithValue("@Lname", NpgsqlDbType.Text, p.Lname);
            cmd.Parameters.AddWithValue("@DoB", NpgsqlDbType.Date, p.Dob);
            cmd.Parameters.AddWithValue("@Gender", NpgsqlDbType.Text, p.Gender);
            cmd.Parameters.AddWithValue("@AoL", NpgsqlDbType.Text, p.Aol);
            cmd.Parameters.AddWithValue("@Username", NpgsqlDbType.Text, p.Username);
            cmd.Parameters.AddWithValue("@Sexual_Orientation", NpgsqlDbType.Text, p.Sexualorientation);
            cmd.Parameters.AddWithValue("@Bio", NpgsqlDbType.Text, p.Bio);
            cmd.Parameters.AddWithValue("@Searching_For", NpgsqlDbType.Text, p.Searchingfor);
            cmd.Parameters.AddWithValue("@Interests", NpgsqlDbType.Text, p.Interests);
            cmd.Parameters.AddWithValue("@Occupation", NpgsqlDbType.Text, p.Occupation);
            cmd.Parameters.AddWithValue("@Pictures", NpgsqlDbType.Bytea, p.Pictures);
            cmd.Parameters.AddWithValue("@Likes", NpgsqlDbType.Bigint, p.Likes);
            cmd.Parameters.AddWithValue("@Matches", NpgsqlDbType.Bigint, p.Matches);
            cmd.Parameters.AddWithValue("@Instagram", NpgsqlDbType.Text, p.Instagram);
            cmd.Parameters.AddWithValue("@Snapchat", NpgsqlDbType.Text, p.Snapchat);
            

            //will return true if all goes well
            bool result = InsertData(dbConn, cmd);

            return result;
        }

        public bool UpdateProfile(Profile p)
        {
            var dbConn = new NpgsqlConnection(ConnectionString);
            var cmd = dbConn.CreateCommand();
            cmd.CommandText = @"update profile set
    Fname=@Fname,
    Lname=@Lname,
    Dob=@DoB,
    Gender=@Gender,
    Aol=@AoL,
    Username=@Username,
    sexual_orientation=@Sexual_Orientation,
    Bio=@Bio,
    searching_for=@Searching_For,
    Interests=@Interests,
    Occupation=@Occupation,
    Pictures=@Pictures,
    Likes=@Likes,
    Matches=@Matches,
    Snapchat=@Snapchat,
    Instagram=@Instagram
    
where
pid = @Pid";


            cmd.Parameters.AddWithValue("@Fname", NpgsqlDbType.Text, p.Fname);
            cmd.Parameters.AddWithValue("@Lname", NpgsqlDbType.Text, p.Lname);
            cmd.Parameters.AddWithValue("@DoB", NpgsqlDbType.Date, p.Dob);
            cmd.Parameters.AddWithValue("@Gender", NpgsqlDbType.Text, p.Gender);
            cmd.Parameters.AddWithValue("@AoL", NpgsqlDbType.Text, p.Aol);
            cmd.Parameters.AddWithValue("@Username", NpgsqlDbType.Text, p.Username);
            cmd.Parameters.AddWithValue("@Sexual_Orientation", NpgsqlDbType.Text, p.Sexualorientation);
            cmd.Parameters.AddWithValue("@Bio", NpgsqlDbType.Text, p.Bio);
            cmd.Parameters.AddWithValue("@Searching_For", NpgsqlDbType.Text, p.Searchingfor);
            cmd.Parameters.AddWithValue("@Interests", NpgsqlDbType.Text, p.Interests);
            cmd.Parameters.AddWithValue("@Occupation", NpgsqlDbType.Text, p.Occupation);
            cmd.Parameters.AddWithValue("@Pictures", NpgsqlDbType.Bytea, p.Pictures);
            cmd.Parameters.AddWithValue("@Likes", NpgsqlDbType.Bigint, p.Likes);
            cmd.Parameters.AddWithValue("@Matches", NpgsqlDbType.Bigint, p.Matches);
            cmd.Parameters.AddWithValue("@Instagram", NpgsqlDbType.Text, p.Instagram);
            cmd.Parameters.AddWithValue("@Snapchat", NpgsqlDbType.Text, p.Snapchat);

           /* { "@Fname",Fname},
                { "@Lname", Lname},
                { "@DoB", Dob},
                { "@Gender", Gender},
                { "@AoL", AoL},
                { "@Username", Username},
                { "@SexualOrientation", Sexualorientation},
                { "@Bio", Bio},
                { "@SearchingFor", Searchingfor},
                { "@Interests", Interests},
                { "@Occupation", Occupation},
                { "@Pictures", Pictures},
                { "@Instagram", Instagram ?? ""},
                { "@Snapchat", Snapchat ?? ""}
           */
            bool result = UpdateData(dbConn, cmd);
            return result;
        } 

        public bool DeleteProfile(int id)
        {
            var dbConn = new NpgsqlConnection(ConnectionString);
            var cmd = dbConn.CreateCommand();
            cmd.CommandText = @"delete from profile where pid = @Pid";

            //adding parameters in a better way
            cmd.Parameters.AddWithValue("@Pid", NpgsqlDbType.Integer, id);

            //will return true if all goes well
            bool result = DeleteData(dbConn, cmd);

            return result;
        }

    }
}

