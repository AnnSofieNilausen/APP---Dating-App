﻿
/*Eliminated this feature as it increased complexity unnecesarily
 * reason: implementation out of scope
 *
 */
using System;
using Npgsql;
using DatingApp.DataRepository;
using System.Collections.Generic;
using DatingApp.DataRepository.BaseRepo;
using DatingApp.Model.P;
namespace DatingApp.Model.Reg
{
    public class Userregistration : BaseRepository
    {
        BaseRepository baserepo = new();
        public Userregistration()
        {
        }

        //method to register a new user
        public bool registeruser(Profile p, String Password)
        {
            //validation to ensure at least one social media account is provided
            if (string.IsNullOrEmpty(p.Instagram) && string.IsNullOrEmpty(p.Snapchat))
            {
                throw new ArgumentException("at least one social media account (instagram or snapchat) must be provided.");
            }

            //prepare the sql query using parameters to insert user data into the database.
            string query = @"
            insert into profile 
            (fname, lname, dob, gender, aol, username, sexual_orientation, 
            bio, searching_for, interests, occupation, pictures, instagram, snapchat) 
            values 
            (@fname, @lname, @dob, @gender, @aol, @username, @sexualorientation, 
            @bio, @searchingfor, @interests, @occupation, @pictures, @instagram, @snapchat)

            Insert into login (username, password) values (@username, @password)";

            //create a dictionary to hold sql parameters
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@fname", p.Fname},
                {"@lname", p.Lname?? ""},
                {"@dob", p.Dob},
                {"@gender", p.Gender},
                {"@aol", p.Aol},
                {"@username", p.Username},
               {"@password", Password},
                {"@sexualorientation", p.Sexualorientation?? ""},
                {"@bio", p.Bio?? ""},
                {"@searchingfor", p.Searchingfor},
                {"@interests", p.Interests?? ""},
                {"@occupation", p.Occupation?? ""},
                {"@pictures", p.Pictures?? ""},
                {"@instagram", p.Instagram ?? ""},
                {"@snapchat", p.Snapchat ?? ""}
            };

           //execute the sql query to register the user and return the result as true if the operation affected at least one row.
            return baserepo.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
