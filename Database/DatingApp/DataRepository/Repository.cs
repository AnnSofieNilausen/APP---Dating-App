using System;
using DatingApp.Model;
using Npgsql;
using NpgsqlTypes;
using DatingApp.Model.P;

namespace DatingApp.DataRepository
{
    public class Repository : BaseRepository
    {
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
                    Profile p = new Profile(Convert.ToInt32(data["pid"]))
                    {

                        fname = data["fname"].ToString(),
                        lname = data["lname"].ToString(),
                        dob = Convert.ToDateTime(data["dob"]),
                        gender = data["gender"].ToString(),
                        aol = data["aol"].ToString(),
                        username = data["username"].ToString(),
                        sexualOrientation = data["sexual_orientation"].ToString(),
                        bio = data["bio"].ToString(),
                        searchingFor = data["searching_for"].ToString(),
                        interests = data["interests"].ToString(),
                        occupation = data["occupation"].ToString(),
                        pictures = data["pictures"].ToString(),
                        likes = Convert.ToInt32(data["likes"]),
                        matches = Convert.ToInt32(data["matches"]),
                        instagram = data["instagram"].ToString(),
                        snapchat = data["snapchat"].ToString()


                    };


                    profiles.Add(p);

                    profiles.Add(p);


                }

                return profiles;
            }

            return null;
        }

        //Get a single profile using Id but without sensitive information
        //match = true, get match information incl. social media
        //match = false, get profile with limited information
        public Profile GetSafeProfileById(int id, bool match)
        {
            //creating empty list to fill it from database
            var profile = new List<Profile>();

            //create a new connection for database
            var dbConn = new NpgsqlConnection(ConnectionString);

            //creating an SQL command
            var cmd = dbConn.CreateCommand();
            cmd.CommandText = $"select * from  where pid = {id}";

            //call the base method to get data
            var data = GetData(dbConn, cmd);

            if (data != null)
            {
                if (data.Read()) //if there is any data for given id
                {
                    if (match)
                    {
                        Profile p = new Profile(Convert.ToInt32(data["pid"]))
                        {
                 
                            fname = data["fname"].ToString(),
                            lname = data["lname"].ToString(),
                            dob = Convert.ToDateTime(data["dob"]),
                            gender = data["gender"].ToString(),
                            aol = data["aol"].ToString(),                                                       
                            bio = data["bio"].ToString(),                            
                            interests = data["interests"].ToString(),
                            occupation = data["occupation"].ToString(),
                            pictures = data["pictures"].ToString(),
                            instagram = data["instagram"].ToString(),
                            snapchat = data["snapchat"].ToString()
                        };
                        return p;
                    }
                    else
                    {
                        Profile p = new Profile(Convert.ToInt32(data["pid"]))
                        {
           
                            fname = data["fname"].ToString(),
                            lname = data["lname"].ToString(),
                            dob = Convert.ToDateTime(data["dob"]),
                            gender = data["gender"].ToString(),
                            aol = data["aol"].ToString(),
                            bio = data["bio"].ToString(),
                            searchingFor = data["searching_for"].ToString(),
                            interests = data["interests"].ToString(),
                            occupation = data["occupation"].ToString(),
                            pictures = data["pictures"].ToString(),                          
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
            //creating empty list to fill it from database
            var profile = new List<Profile>();

            //create a new connection for database
            var dbConn = new NpgsqlConnection(ConnectionString);

            //creating an SQL command
            var cmd = dbConn.CreateCommand();
            cmd.CommandText = $"select * from Profile where pid = {id}";

            //call the base method to get data
            var data = GetData(dbConn, cmd);

            if (data != null)
            {
                if (data.Read()) //if there is any data for given id
                {
                    Profile p = new Profile(Convert.ToInt32(data["pid"]))
                    {
                
                        fname = data["fname"].ToString(),
                        lname = data["lname"].ToString(),
                        dob = Convert.ToDateTime(data["dob"]),
                        gender = data["gender"].ToString(),
                        aol = data["aol"].ToString(),
                        username = data["username"].ToString(),
                        sexualOrientation = data["sexual_orientation"].ToString(),
                        bio = data["bio"].ToString(),
                        searchingFor = data["searching_for"].ToString(),
                        interests = data["interests"].ToString(),
                        occupation = data["occupation"].ToString(),
                        pictures = data["pictures"].ToString(),
                        likes = Convert.ToInt32(data["likes"]),
                        matches = Convert.ToInt32(data["matches"]),
                        instagram = data["instagram"].ToString(),
                        snapchat = data["snapchat"].ToString()
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
            cmd.CommandText = @"insert into Profile (fname,lname, dob, gender, aol, username, sexual_orientation, bio, searching_for, interests, occupation, pictures, likes, matches, instagram, snapchat) values (@firstname,@lastname, @dob, @gender, @aol, @username, @sexual_orientation, @bio, @searching_for, @interests, @occupation, @pictures, @likes, @matches, @instagram, @snapchat)
";

            //adding parameters in a better way
            cmd.Parameters.AddWithValue("@pid", NpgsqlDbType.Integer, p.ID);
            cmd.Parameters.AddWithValue("@fname", NpgsqlDbType.Text, p.fname);
            cmd.Parameters.AddWithValue("@lname", NpgsqlDbType.Text, p.lname);
            cmd.Parameters.AddWithValue("@dob", NpgsqlDbType.Date, p.dob);
            cmd.Parameters.AddWithValue("@gender", NpgsqlDbType.Text, p.gender);
            cmd.Parameters.AddWithValue("@aol", NpgsqlDbType.Text, p.aol);
            cmd.Parameters.AddWithValue("@username", NpgsqlDbType.Text, p.username);
            cmd.Parameters.AddWithValue("@sexual_orientation", NpgsqlDbType.Text, p.sexualOrientation);
            cmd.Parameters.AddWithValue("@bio", NpgsqlDbType.Text, p.bio);
            cmd.Parameters.AddWithValue("@searching_for", NpgsqlDbType.Text, p.searchingFor);
            cmd.Parameters.AddWithValue("@interests", NpgsqlDbType.Text, p.interests);
            cmd.Parameters.AddWithValue("@occupation", NpgsqlDbType.Text, p.occupation);
            cmd.Parameters.AddWithValue("@pictures", NpgsqlDbType.Bytea, p.pictures);
            cmd.Parameters.AddWithValue("@likes", NpgsqlDbType.Bigint, p.likes);
            cmd.Parameters.AddWithValue("@matches", NpgsqlDbType.Bigint, p.matches);
            cmd.Parameters.AddWithValue("@instagram", NpgsqlDbType.Text, p.instagram);
            cmd.Parameters.AddWithValue("@snapchat", NpgsqlDbType.Text, p.snapchat);
            

            //will return true if all goes well
            bool result = InsertData(dbConn, cmd);

            return result;
        }

        public bool UpdateProfile(Profile p)
        {
            var dbConn = new NpgsqlConnection(ConnectionString);
            var cmd = dbConn.CreateCommand();
            cmd.CommandText = @"update profile set
    fname=@fname,
    lname=@lname,
    dob=@dob,
    gender=@gender,
    aol=@aol,
    username=@username,
    sexual_orientation=@sexual_orientation,
    bio=@bio,
    searching_for=@searching_for,
    interests=@interests,
    occupation=@occupation,
    pictures=@pictures,
    likes=@likes,
    matches=@matches,
    snapchat=@snapchat,
    instagram=@instagram
    
where
pid = @pid";

            cmd.Parameters.AddWithValue("@pid", NpgsqlDbType.Integer, p.ID);
            cmd.Parameters.AddWithValue("@fname", NpgsqlDbType.Text, p.fname);
            cmd.Parameters.AddWithValue("@lname", NpgsqlDbType.Text, p.lname);
            cmd.Parameters.AddWithValue("@dob", NpgsqlDbType.Date, p.dob);
            cmd.Parameters.AddWithValue("@gender", NpgsqlDbType.Text, p.gender);
            cmd.Parameters.AddWithValue("@aol", NpgsqlDbType.Text, p.aol);
            cmd.Parameters.AddWithValue("@username", NpgsqlDbType.Text, p.username);
            cmd.Parameters.AddWithValue("@sexual_orientation", NpgsqlDbType.Text, p.sexualOrientation);
            cmd.Parameters.AddWithValue("@bio", NpgsqlDbType.Text, p.bio);
            cmd.Parameters.AddWithValue("@searching_for", NpgsqlDbType.Text, p.searchingFor);
            cmd.Parameters.AddWithValue("@interests", NpgsqlDbType.Text, p.interests);
            cmd.Parameters.AddWithValue("@occupation", NpgsqlDbType.Text, p.occupation);
            cmd.Parameters.AddWithValue("@pictures", NpgsqlDbType.Bytea, p.pictures);
            cmd.Parameters.AddWithValue("@likes", NpgsqlDbType.Bigint, p.likes);
            cmd.Parameters.AddWithValue("@matches", NpgsqlDbType.Bigint, p.matches);
            cmd.Parameters.AddWithValue("@instagram", NpgsqlDbType.Text, p.instagram);
            cmd.Parameters.AddWithValue("@snapchat", NpgsqlDbType.Text, p.snapchat);

           /* { "@fname",fname},
                { "@lname", lname},
                { "@dob", dob},
                { "@gender", gender},
                { "@aol", aol},
                { "@username", username},
                { "@SexualOrientation", sexualOrientation},
                { "@bio", bio},
                { "@SearchingFor", searchingFor},
                { "@interests", interests},
                { "@occupation", occupation},
                { "@pictures", pictures},
                { "@instagram", instagram ?? ""},
                { "@snapchat", snapchat ?? ""}
           */
            bool result = UpdateData(dbConn, cmd);
            return result;
        } 

        public bool DeleteProfile(int id)
        {
            var dbConn = new NpgsqlConnection(ConnectionString);
            var cmd = dbConn.CreateCommand();
            cmd.CommandText = @"delete from Profile where pid = @pid";

            //adding parameters in a better way
            cmd.Parameters.AddWithValue("@pid", NpgsqlDbType.Integer, id);

            //will return true if all goes well
            bool result = DeleteData(dbConn, cmd);

            return result;
        }

    }
}

