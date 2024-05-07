﻿using System;
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
                    Profile p = new(Convert.ToInt32(data["Pid"]))
                    {

                        fname = data["fname"].ToString(),
                        lname = data["lname"].ToString(),
                        dob = Convert.ToDateTime(data["DoB"]),
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
                        Profile p = new(Convert.ToInt32(data["pid"]))
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
                        Profile p = new(Convert.ToInt32(data["pid"]))
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
                    Profile p = new(Convert.ToInt32(data["pid"]))
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
            cmd.CommandText = @"insert into profile (fname,lname, dob, gender, aol, username, sexual_orientation, bio, searching_for, interests, occupation, pictures, likes, matches, instagram, snapchat) values (@firstname,@lastname, @dob, @Gender, @AoL, @Username, @Sexual_Orientation, @Bio, @Searching_For, @Interests, @Occupation, @Pictures, @Likes, @Matches, @Instagram, @Snapchat)
";

            //adding parameters in a better way
            cmd.Parameters.AddWithValue("@Fname", NpgsqlDbType.Text, p.fname);
            cmd.Parameters.AddWithValue("@Lname", NpgsqlDbType.Text, p.lname);
            cmd.Parameters.AddWithValue("@DoB", NpgsqlDbType.Date, p.dob);
            cmd.Parameters.AddWithValue("@Gender", NpgsqlDbType.Text, p.gender);
            cmd.Parameters.AddWithValue("@AoL", NpgsqlDbType.Text, p.aol);
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
            cmd.CommandText = @"update profile set
    fname=@Fname,
    lname=@Lname,
    dob=@DoB,
    gender=@Gender,
    aol=@AoL,
    username=@Username,
    sexual_orientation=@Sexual_Orientation,
    bio=@Bio,
    searching_for=@Searching_For,
    interests=@Interests,
    occupation=@Occupation,
    pictures=@Pictures,
    likes=@Likes,
    matches=@Matches,
    snapchat=@Snapchat,
    instagram=@Instagram
    
where
pid = @Pid";


            cmd.Parameters.AddWithValue("@Fname", NpgsqlDbType.Text, p.fname);
            cmd.Parameters.AddWithValue("@Lname", NpgsqlDbType.Text, p.lname);
            cmd.Parameters.AddWithValue("@DoB", NpgsqlDbType.Date, p.dob);
            cmd.Parameters.AddWithValue("@Gender", NpgsqlDbType.Text, p.gender);
            cmd.Parameters.AddWithValue("@AoL", NpgsqlDbType.Text, p.aol);
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

           /* { "@Fname",fname},
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

