
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
//            string Fname, string Lname, datetime Dob, string email, string phone,
//            string Username, string password, string sexualorientation,
//            string Bio, string searchingfor, string Interests,
//            string Occupation, string Pictures, string Instagram = null, string Snapchat = null)
//        {
//            validation to ensure at least one social media account is provided
//            if (string.isnullorempty(Instagram) && string.isnullorempty(Snapchat))
//            {
//                throw new argumentexception("at least one social media account (Instagram or Snapchat) must be provided.");
//            }

//            prepare the sql query using parameters to insert user data into the database.
//            string query = @"
//            insert into profile 
//            (Fname, Lname, Dob, email, phone, Username, password, sexual_orientation, 
//            Bio, searching_for, Interests, Occupation, Pictures, Instagram, Snapchat) 
//            values 
//            (@Fname, @Lname, @Dob, @email, @phone, @Username, @password, @sexualorientation, 
//            @Bio, @searchingfor, @Interests, @Occupation, @Pictures, @Instagram, @Snapchat)";

//            create a dictionary to hold sql parameters
//            dictionary<string, object> parameters = new dictionary<string, object>
//            {
//                {"@Fname", Fname},
//                {"@Lname", Lname},
//                {"@Dob", Dob},
//                {"@email", email},
//                {"@phone", phone},
//                {"@Username", Username},
//                {"@password", password},
//                {"@sexualorientation", sexualorientation},
//                {"@Bio", Bio},
//                {"@searchingfor", searchingfor},
//                {"@Interests", Interests},
//                {"@Occupation", Occupation},
//                {"@Pictures", Pictures},
//                {"@Instagram", Instagram ?? ""},
//                {"@Snapchat", Snapchat ?? ""}
//            };

//            execute the sql query to register the user and return the result as true if the operation affected at least one row.
//            return executenonquery(query, parameters) > 0;
//        }
//    }
//}
*/