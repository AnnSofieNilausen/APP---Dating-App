export interface Profile {
  pid: number;  // Ensure consistency in how this is used across your application
  Fname: string;
  Lname?: string;
  Dob: Date;
  Gender: string;
  Aol: string;
  Username: string;
  Sexualorientation: string;
  Bio?: string;
  Searchingfor?: string;
  Interests?: string;
  Occupation?: string;
  Pictures?: string;  // Consider defining what 'pictures' are, such as string[]
  Likes?: number;
  Matches?: number;
  Instagram?: string;  // Optional Instagram handle
  Snapchat?: string;  // Optional Snapchat handle
}
