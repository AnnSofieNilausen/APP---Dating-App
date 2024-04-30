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