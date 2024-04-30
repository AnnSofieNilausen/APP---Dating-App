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