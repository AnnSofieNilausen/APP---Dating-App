
/*Eliminated this feature as it increased complexity unnecesarily
 * reason: implementation out of scope
 * 
//using system;
//using npgsql;
//using datingapp.datarepository;
//using system.collections.generic;

//namespace datingapp.model
//{
//    public class userregistration : baserepository
//    {
//        public userregistration()
//        {
//        }

//        method to register a new user
//        public bool registeruser(
//            string fname, string lname, datetime dob, string email, string phone,
//            string username, string password, string sexualorientation,
//            string bio, string searchingfor, string interests,
//            string occupation, string pictures, string instagram = null, string snapchat = null)
//        {
//            validation to ensure at least one social media account is provided
//            if (string.isnullorempty(instagram) && string.isnullorempty(snapchat))
//            {
//                throw new argumentexception("at least one social media account (instagram or snapchat) must be provided.");
//            }

//            prepare the sql query using parameters to insert user data into the database.
//            string query = @"
//            insert into profile 
//            (fname, lname, dob, email, phone, username, password, sexual_orientation, 
//            bio, searching_for, interests, occupation, pictures, instagram, snapchat) 
//            values 
//            (@fname, @lname, @dob, @email, @phone, @username, @password, @sexualorientation, 
//            @bio, @searchingfor, @interests, @occupation, @pictures, @instagram, @snapchat)";

//            create a dictionary to hold sql parameters
//            dictionary<string, object> parameters = new dictionary<string, object>
//            {
//                {"@fname", fname},
//                {"@lname", lname},
//                {"@dob", dob},
//                {"@email", email},
//                {"@phone", phone},
//                {"@username", username},
//                {"@password", password},
//                {"@sexualorientation", sexualorientation},
//                {"@bio", bio},
//                {"@searchingfor", searchingfor},
//                {"@interests", interests},
//                {"@occupation", occupation},
//                {"@pictures", pictures},
//                {"@instagram", instagram ?? ""},
//                {"@snapchat", snapchat ?? ""}
//            };

//            execute the sql query to register the user and return the result as true if the operation affected at least one row.
//            return executenonquery(query, parameters) > 0;
//        }
//    }
//}
*/