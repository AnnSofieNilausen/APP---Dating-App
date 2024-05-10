
/*Eliminated this feature as it increased complexity unnecesarily
 * reason: implementation out of scope
 *
 */
using system;
using npgsql;
using datingapp.datarepository;
using system.collections.generic;
using DatingApp.DataRepository.BaseRepo;
using DatingApp.Model.P;

namespace datingapp.model.Reg
{
    public class userregistration : BaseRepository
    {
        public userregistration()
        {
        }

        //method to register a new user
        public bool registeruser(Profile p)
        {
            //validation to ensure at least one social media account is provided
            if (p.Instagram.isnullorempty && p.Snapchat.isnullorempty)
            {
                throw new argumentexception("at least one social media account (instagram or snapchat) must be provided.");
            }

            //prepare the sql query using parameters to insert user data into the database.
            string query = @"
            insert into profile 
            (fname, lname, dob, gender, aol, username, password, sexual_orientation, 
            bio, searching_for, interests, occupation, pictures, instagram, snapchat) 
            values 
            (@fname, @lname, @dob, @gender, @aol, @username, @password, @sexualorientation, 
            @bio, @searchingfor, @interests, @occupation, @pictures, @instagram, @snapchat)";

            //create a dictionary to hold sql parameters
            dictionary<string, object> parameters = new dictionary<string, object>
            {
                {"@fname", p.fname},
                {"@lname", p.lname?? ""},
                {"@dob", p.dob},
                {"@gender", p.gender},
                {"@aol", p.aol},
                {"@username", p.username},
               {"@password", p.password},
                {"@sexualorientation", p.sexualorientation?? ""},
                {"@bio", p.bio?? ""},
                {"@searchingfor", p.searchingfor},
                {"@interests", p.interests?? ""},
                {"@occupation", p.occupation?? ""},
                {"@pictures", p.pictures?? ""},
                {"@instagram", p.instagram ?? ""},
                {"@snapchat", p.snapchat ?? ""}
            };

           //execute the sql query to register the user and return the result as true if the operation affected at least one row.
            return BaseRepository.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
