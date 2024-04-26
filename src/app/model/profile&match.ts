export interface UserProfile {
   pid: bigint;
   fname: string;
   lname?: string;       // '?' indicates that the property is optional and can be null
   dob: Date;
   gender: string;
   aol: string;
   username: string;
   sexualOrientation: string;
   bio?: string;         // Optional
   searchingFor?: string; // Optional
   interests?: string;    // Optional
   occupation?: string;   // Optional
   pictures?: any;        // Type 'any' can be replaced with a more specific type if known
   likes?: bigint;        // Optional
   matches?: bigint;      // Optional
 }
 
// PotentialMatch might contain profile information
// that you'd display when listing potential matches.
export interface PotentialMatch {
   pid: bigint;  // Unique identifier for the profile
   fname: string;
   lname?: string;
   dob: Date;
   gender: string;
   aol: string;
   username: string;
   sexualOrientation: string;
   bio?: string;
   searchingFor?: string;
   interests?: string;
   occupation?: string;
   pictures?: any; // Replace 'any' with a more specific type if known, such as Blob or string if it's a URL
   // Other properties from Profile that are relevant to showing potential matches
 }
 
 // MutualMatch would include information relevant to a match where
 // both users have liked each other. It may have a subset of properties
 // from the Profile that are relevant to show for a mutual match.
 export interface MutualMatch {
   matchId: bigint; // Identifier for the match
   pid1: bigint;    // Profile ID of the first user
   pid2: bigint;    // Profile ID of the second user
   fname: string;
   lname?: string;
   username: string;
   pictures?: any; // Again, replace 'any' with the type you use for pictures
   // Possibly other profile information relevant to a match view
 }
 
 