using System;
using DatingApp.Model;
using Npgsql;
using NpgsqlTypes;
using DatingApp.Model.P;
using DatingApp.Model.Conversion;
using DatingApp.DataRepository.BaseRepo;

namespace DatingApp.DataRepository
{
    public class Repository : BaseRepository
    {
        public ConvertFromDB convertFromDB = new();
        //Get a list of Profiles
        //Returns a list of profiles
        public List<Profile> GetProfiles()
        {
            var profiles = new List<Profile>();

            var dbConn = new NpgsqlConnection(ConnectionString);

            
            var cmd = dbConn.CreateCommand();
            cmd.CommandText = "select * from profile";

            
            var data = GetData(dbConn, cmd);

            if (data != null)
            {
                while (data.Read()) 
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
            var dbConn = new NpgsqlConnection(ConnectionString);

            var cmd = dbConn.CreateCommand();
            cmd.CommandText = $"select * from profile where pid = {id}";

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

        //get Full profile with all information for a given ID
        public Profile GetProfileById(int id)
        { 

            var dbConn = new NpgsqlConnection(ConnectionString);

            var cmd = dbConn.CreateCommand();
            cmd.CommandText = $"select * from profile where pid = {id}";

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

        //adds a new profile to the database
        public bool InsertProfile(Profile p)
        {
            var dbConn = new NpgsqlConnection(ConnectionString);
            var cmd = dbConn.CreateCommand();
            cmd.CommandText = @"insert into profile (fname, lname, dob, gender, aol, username, sexual_orientation, bio, searching_for, interests, occupation, pictures, likes, matches, instagram, snapchat) values (@firstname,@lastname, @Dob, @Gender, @AoL, @Username, @Sexual_Orientation, @Bio, @Searching_For, @Interests, @Occupation, @Pictures, @Likes, @Matches, @Instagram, @Snapchat)
";

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
            cmd.Parameters.AddWithValue("@Pictures", NpgsqlDbType.Text , p.Pictures);
            cmd.Parameters.AddWithValue("@Likes", NpgsqlDbType.Integer, p.Likes);
            cmd.Parameters.AddWithValue("@Matches", NpgsqlDbType.Integer, p.Matches);
            cmd.Parameters.AddWithValue("@Instagram", NpgsqlDbType.Text, p.Instagram);
            cmd.Parameters.AddWithValue("@Snapchat", NpgsqlDbType.Text, p.Snapchat);
            

            //return true if succesful
            bool result = InsertData(dbConn, cmd);

            return result;
        }

        //updates a profile in the database and returns true or false
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
    sexual_orientation=@Sexual_Orientation,
    Bio=@Bio,
    searching_for=@Searching_For,
    Interests=@Interests,
    Occupation=@Occupation

    
where
pid = @pid";

            cmd.Parameters.AddWithValue("@pid", NpgsqlDbType.Integer, p.ID);
            cmd.Parameters.AddWithValue("@Fname", NpgsqlDbType.Text, p.Fname);
            cmd.Parameters.AddWithValue("@Lname", NpgsqlDbType.Text, p.Lname);
            cmd.Parameters.AddWithValue("@DoB", NpgsqlDbType.Date, p.Dob);
            cmd.Parameters.AddWithValue("@Gender", NpgsqlDbType.Text, p.Gender);
            cmd.Parameters.AddWithValue("@AoL", NpgsqlDbType.Text, p.Aol);
            cmd.Parameters.AddWithValue("@Sexual_Orientation", NpgsqlDbType.Text, p.Sexualorientation);
            cmd.Parameters.AddWithValue("@Bio", NpgsqlDbType.Text, p.Bio);
            cmd.Parameters.AddWithValue("@Searching_For", NpgsqlDbType.Text, p.Searchingfor);
            cmd.Parameters.AddWithValue("@Interests", NpgsqlDbType.Text, p.Interests);
            cmd.Parameters.AddWithValue("@Occupation", NpgsqlDbType.Text, p.Occupation);
            

            bool result = UpdateData(dbConn, cmd);
            return result;
        } 

        //Deletes profile from database
        public bool DeleteProfile(string username)
        {
            var dbConn = new NpgsqlConnection(ConnectionString);
            var cmd = dbConn.CreateCommand();
            cmd.CommandText = @"delete from profile where username = @Pid;
                                delete from login where username = @Pid;";


            cmd.Parameters.AddWithValue("@Pid", NpgsqlDbType.Text, username);

            //on succes return true
            bool result = DeleteData(dbConn, cmd);

            return result;
        }

    }
}

