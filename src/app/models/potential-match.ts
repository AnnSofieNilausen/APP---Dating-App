export interface PotentialMatch {
    pid: bigint;  // Unique identifier for the profile
    Fname: string;
    Lname?: string;
    Dob: Date;
    Gender: string;
    Aol: string;
    Username: string;
    SexualOrientation: string;
    Bio?: string;
    SearchingFor?: string;
    Interests?: string;
    Occupation?: string;
    Pictures?: any; // Replace 'any' with a more specific type if known, such as Blob or string if it's a URL
    // Other properties from Profile that are relevant to showing potential matches
  }