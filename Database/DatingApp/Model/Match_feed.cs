namespace DatingApp.Model
{
    public class Match_feed
    {
        //first thing we should do is to find another profile, make sure the profile is not either liked or matched.
    public int DisplayProfile() {  return 0; }
        //Add While loop
        //Get profile through repository of foreign ID
            //Check they are not in list of matches or likes(Consider making this a function for itself)
            //if True - find new ID, if False - continue
        //await Liking or disliking of profile - API
        //if like call IsLike function
            //continue
        //if dislike run again
   
    public bool IsMatch() { return false; }
        //pull foreign ID from liked persons liked and check if like is mutual
        //if true create match and push it through repository
        //delete like on both IDs in Repository
        //if false return false

    public bool IsLike(string s) { return false; }
        //check if like is match call IsMatch function
        //if return false add like to like list through repository
            //return false
        //if true return true
    }

    //testing 
}
